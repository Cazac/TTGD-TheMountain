using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

///////////////
/// <summary>
///     
/// TM_PlayerController_UI controles the UI shown to the player
/// 
/// </summary>
///////////////

public class TM_HomeMenuController_Fire : MonoBehaviour
{
    ////////////////////////////////

    public static TM_HomeMenuController_Fire Instance;

    ////////////////////////////////

    [Header("Home Base Menus")]
    public GameObject Fire_Panel;

    ////////////////////////////////

    [Header("Fire")]
    public GameObject burnableItem_Prefab;
    public GameObject burnablesContentContainer_GO;
    private TM_BurnableItemTab currentSelectedBurnable_Tab;
    public Button burnItem_Button;

    ////////////////////////////////

    [Header("Descriptions")]
    public Image selectedIcon_Image;
    public TextMeshProUGUI selectedBurnName_Text;
    public TextMeshProUGUI selectedBurnDesc_Text;
    public TextMeshProUGUI selectedEffect_Text;
    public TextMeshProUGUI selectedButton_Text;

    [Header("Description Panels")]
    public GameObject Empty_Panel;
    public GameObject Full_Panel;

    ////////////////////////////////

    public Image progressBar_Image;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////// - Fire UI

    public void FireMenu_OpenUI()
    {
        //Turn On Panel
        TM_PlayerMenuController_UI.Instance.Fire_Panel.SetActive(true);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Remove Items
        Empty_Panel.SetActive(true);
        Full_Panel.SetActive(false);
        currentSelectedBurnable_Tab = null;
        selectedButton_Text.text = "Burn";

        //Setup
        Refresh_BurnableItemsList();
        Refresh_BurnButton();
    }

    public void FireMenu_CloseUI()
    {
        //Turn Off Panel
        TM_PlayerMenuController_UI.Instance.Fire_Panel.SetActive(false);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();



        //Load Stuff ???


    }

    ///////////////////////////////////////////////////////

    public void Button_SelectBurnable(TM_BurnableItemTab burnableTab)
    {
        if (currentSelectedBurnable_Tab == burnableTab)
        {
            //Remove Items
            Empty_Panel.SetActive(true);
            Full_Panel.SetActive(false);
            currentSelectedBurnable_Tab = null;
            selectedButton_Text.text = "Burn";
        }
        else
        {
            //Set Item
            Empty_Panel.SetActive(false);
            Full_Panel.SetActive(true);
            currentSelectedBurnable_Tab = burnableTab;
            selectedButton_Text.text = "Burn " + burnableTab.currentBurnableItem.itemName;

            //Set Values
            selectedIcon_Image.gameObject.SetActive(true);
            selectedIcon_Image.sprite = burnableTab.currentBurnableItem.itemIcon;
            selectedBurnName_Text.text = burnableTab.currentBurnableItem.itemName;
            selectedBurnDesc_Text.text = burnableTab.currentBurnableItem.itemDesc;
      


            if (burnableTab.currentBurnableItem.burn_FireEffect == 1)
            {
                selectedEffect_Text.text = "Heat Value: " + burnableTab.currentBurnableItem.burn_FireValue +
                   "<br>Effect: Exploding Puppies";
            }
            else
            {
                selectedEffect_Text.text = "Heat Value: " + burnableTab.currentBurnableItem.burn_FireValue + 
                    "<br>Effect: None";
            }
        }

        //Refresh Burn Button Status
        Refresh_BurnButton();
    }

    public void Button_Fire_BurnItem()
    {
        //Add BurnValue
        TM_PlayerController_Stats.Instance.ChangeFire_Current(currentSelectedBurnable_Tab.currentBurnableItem.burn_FireValue);

        //Play SFX
        TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.burningItem_SFX);

        //Apply Effect



        //Remove Item
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem(currentSelectedBurnable_Tab.currentBurnableItem.itemName);

        //Refresh Fire Burnables
        Refresh_BurnableItemsList();
    }

    ///////////////////////////////////////////////////////

    private void Refresh_BurnableItemsList()
    {
        //Burnable Lists
        List<TM_ItemUI> itemsBurnable_List = new List<TM_ItemUI>();
        List<TM_ItemUI> itemsBurnableFiltered_List = new List<TM_ItemUI>();


        //Remove Old List Values
        foreach (Transform oldItem in burnablesContentContainer_GO.transform)
        {
            Destroy(oldItem.gameObject);
        }

        //Find Slots in Toolbar
        foreach (GameObject itemSlot in TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().isBurnable)
                {
                    itemsBurnable_List.Add(slot.ItemSlot_GetItem());
                }
            }
        }

        //Find Slots in Inventory
        foreach (GameObject itemSlot in TM_PlayerMenuController_Inventory.Instance.playerItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().isBurnable)
                {
                    itemsBurnable_List.Add(slot.ItemSlot_GetItem());
                }
            }
        }


        bool canPass = false;
        TM_ItemUI mergingItem = null;
        TM_ItemUI removalItem_Basic = null;
        TM_ItemUI removalItem_Listed = null;

        //Merge Items
        while (canPass == false)
        {
            for (int i = 0; i < itemsBurnable_List.Count; i++)
            {
                foreach (TM_ItemUI item in itemsBurnable_List)
                {
                    if (itemsBurnable_List[i] != item)
                    {
                        if (itemsBurnable_List[i].itemName == item.itemName && itemsBurnable_List[i].currentDurablity == item.currentDurablity)
                        {
                            //Set Item Removal
                            removalItem_Basic = item;
                            removalItem_Listed = itemsBurnable_List[i];

                            mergingItem = new TM_ItemUI(item.original_SO);
                            mergingItem.currentStackSize = item.currentStackSize;
                            mergingItem.currentStackSize += itemsBurnable_List[i].currentStackSize;

                            //itemsBurnableFiltered_List.Add(mergingItem);

                

                            //Skip Loops, A Match Was Found
                            goto BreakLoops;
                        }
                    }
                }

                //Clear For next round
                mergingItem = null;
            }

            //Made the Full Loop, without using the goto, Break Out of loop
            canPass = true;

            //Goto Pointer
            BreakLoops:

            //Add and Remove Merged Items
            if (removalItem_Basic != null && removalItem_Listed != null & mergingItem != null)
            {
                itemsBurnable_List.Remove(removalItem_Basic);
                itemsBurnable_List.Remove(removalItem_Listed);
                itemsBurnable_List.Add(mergingItem);
            }
        }

        //Create and Fill Prefabs
        foreach (TM_ItemUI item in itemsBurnable_List)
        {
            //Get Objects
            GameObject newItem = Instantiate(burnableItem_Prefab, burnablesContentContainer_GO.transform);
            TM_BurnableItemTab burnableTab = newItem.GetComponent<TM_BurnableItemTab>();

            //Set Info
            burnableTab.currentBurnableItem = item;
            burnableTab.RefreshTab();
        }
    }

    private void Refresh_BurnButton()
    {
        if (currentSelectedBurnable_Tab != null)
        {
            burnItem_Button.interactable = true;
        }
        else
        {
            burnItem_Button.interactable = false;
        }
    }



    ///////////////////////////////////////////////////////




   

    ///////////////////////////////////////////////////////
}

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

public class TM_PlayerMenuController_Fire : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Fire Instance;

    ////////////////////////////////

    [Header("Home Base Menus")]
    public GameObject Fire_Panel;

    ////////////////////////////////

    [Header("Fire")]
    public GameObject burnableItem_Prefab;
    public GameObject burnablesContentContainer_GO;
    private GameObject currentSelectedBurnable_GO;
    public Button burnItem_Button;


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
        //Tunr On Panel
        Fire_Panel.SetActive(true);

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Setup
        Refresh_BurnableItemsList();
        Refresh_BurnButton();
    }

    public void FireMenu_CloseUI()
    {
        //Tunr Off Panel
        Fire_Panel.SetActive(false);

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();



        //Load Stuff ???


    }

    ///////////////////////////////////////////////////////

    public void Button_SelectBurnable(TM_BurnableItemTab burnableTab)
    {
        if (currentSelectedBurnable_GO == burnableTab.gameObject)
        {
            currentSelectedBurnable_GO = null;
        }
        else
        {
            print("Test Code: Setting");
            currentSelectedBurnable_GO = burnableTab.gameObject;
        }

        //Refresh Burn Button Status
        Refresh_BurnButton();
    }

    public void Button_Fire_BurnItem()
    {

    }

    ///////////////////////////////////////////////////////

    private void Refresh_BurnableItemsList()
    {
        //Burnable Lists
        List<TM_ItemUI_Base> itemsBurnable_List = new List<TM_ItemUI_Base>();
        List<TM_ItemUI_Base> itemsBurnableFiltered_List = new List<TM_ItemUI_Base>();


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

            if (slot.currentItem != null)
            {
                if (slot.currentItem.IsBurnable)
                {
                    itemsBurnable_List.Add(slot.currentItem);
                }
            }
        }

        //Find Slots in Inventory
        foreach (GameObject itemSlot in TM_PlayerMenuController_Inventory.Instance.playerItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.currentItem != null)
            {
                if (slot.currentItem.IsBurnable)
                {
                    itemsBurnable_List.Add(slot.currentItem);
                }
            }
        }


        bool canPass = false;
        TM_ItemUI_Base mergingItem = null;
        TM_ItemUI_Base removalItem_Basic = null;
        TM_ItemUI_Base removalItem_Listed = null;

        //Merge Items
        while (canPass == false)
        {
            for (int i = 0; i < itemsBurnable_List.Count; i++)
            {
                foreach (TM_ItemUI_Base item in itemsBurnable_List)
                {
                    if (itemsBurnable_List[i] != item)
                    {
                        if (itemsBurnable_List[i].ItemName == item.ItemName && itemsBurnable_List[i].CurrentDurablity == item.CurrentDurablity)
                        {
                            //Set Item Removal
                            removalItem_Basic = item;
                            removalItem_Listed = itemsBurnable_List[i];

                            //Set Merge Item
                            mergingItem = item;
                            mergingItem.CurrentStackSize += itemsBurnable_List[i].CurrentStackSize;

                            //Skip Loops, A Match Was Found
                            goto BreakLoops;
                        }
                    }
                }
            }

            //Made the Full Loop, Break Out
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
        foreach (TM_ItemUI_Base item in itemsBurnable_List)
        {
            GameObject newItem = Instantiate(burnableItem_Prefab, burnablesContentContainer_GO.transform);

            //Fill Out Info
            newItem.transform.Find("Item Name Text").GetComponent<TextMeshProUGUI>().text = item.ItemName;
            newItem.transform.Find("Item Count Text").GetComponent<TextMeshProUGUI>().text = "x " + item.CurrentStackSize.ToString();
            //newItem.transform.Find("Item Desc Text").GetComponent<TextMeshProUGUI>().text = item.ItemDesc;
            newItem.transform.Find("Item BG").transform.Find("Item Icon").GetComponent<Image>().sprite = item.ItemIcon;
        }
    }

    private void Refresh_BurnButton()
    {
        if (currentSelectedBurnable_GO != null)
        {
            burnItem_Button.interactable = true;
        }
        else
        {
            burnItem_Button.interactable = false;
        }
    }

    ///////////////////////////////////////////////////////
}

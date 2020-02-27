﻿using System.Collections;
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
    private TM_BurnableItemTab currentSelectedBurnable_Tab;
    public Button burnItem_Button;

    ////////////////////////////////

    [Header("New Stuff")]
    public Image selectedIcon_Image;
    public TextMeshProUGUI selectedBurnName_Text;
    public TextMeshProUGUI selectedBurnDesc_Text;
    public TextMeshProUGUI selectedEffect_Text;


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
        if (currentSelectedBurnable_Tab == burnableTab)
        {
            currentSelectedBurnable_Tab = null;

            //Remove Image
            selectedIcon_Image.gameObject.SetActive(false);
            selectedBurnName_Text.text = "";
            selectedBurnDesc_Text.text = "";
            selectedEffect_Text.text = "";
        }
        else
        {
            currentSelectedBurnable_Tab = burnableTab;

            //Set Image
            selectedIcon_Image.gameObject.SetActive(true);
            selectedIcon_Image.sprite = burnableTab.currentBurnableItem.itemIcon;
            selectedBurnName_Text.text = burnableTab.currentBurnableItem.itemName;
            selectedBurnDesc_Text.text = burnableTab.currentBurnableItem.itemDesc;
            selectedEffect_Text.text = "- ???";





        }

        //Refresh Burn Button Status
        Refresh_BurnButton();
    }

    public void Button_Fire_BurnItem()
    {
        print("Test Code: Burning!");

        //Add BurnValue


        TM_PlayerController_Stats.Instance.ChangeFire_Current(10);





        //Remove ITem






        //Find Slots in Toolbar
        foreach (GameObject itemSlot in TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();


            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == currentSelectedBurnable_Tab.currentBurnableItem.itemName)
                {

                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    Refresh_BurnableItemsList();
                    return;
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
                if (slot.ItemSlot_GetItem().itemName == currentSelectedBurnable_Tab.currentBurnableItem.itemName)
                {

                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    Refresh_BurnableItemsList();
                    return;
                }
            }
        }


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




                   






                            mergingItem = item;
                            mergingItem.currentStackSize += itemsBurnable_List[i].currentStackSize;

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

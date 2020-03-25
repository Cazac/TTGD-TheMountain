using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_PlayerController_Movement takes input and moves the player.
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Inventory : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Inventory Instance;

    ////////////////////////////////

    [Header("Item Slots")]
    public GameObject[] toolbarItemSlots_Array;
    public GameObject[] playerItemSlots_Array;

    ////////////////////////////////

    public int currentToolbarPosition;
    public bool isHoldingItem;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        //Set First Item By Default
        Toolbar_MoveSelector_SetHover(0);
    }


    private void Update()
    {
        LookForInventoryKeys();

    }
    ///////////////////////////////////////////////////////

    public TM_ItemUI[] Inventory_GetItemsToArray()
    {
        //Create The Array
        TM_ItemUI[] itemArray = new TM_ItemUI[20];

        //Reset Counter
        int counter = 0;

        //Loop All Slots
        foreach (GameObject itemSlot_GO in playerItemSlots_Array)
        {
            //Confirm Item
            if (itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
            {
                //Add Item + Position
                itemArray[counter] = itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_GetItem();
            }

            //Update Counter
            counter++;
        }

        //Return Filled Array
        return itemArray;
    }

    public void Inventory_SetItemsFromArray(TM_ItemUI[] itemArray)
    {
        //Clear Inventory First
        foreach (GameObject itemSlot_GO in playerItemSlots_Array)
        {
            itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_RemoveItem();
        }

        //Reset Counter
        int counter = 0;

        //Loop All Array Items
        foreach (TM_ItemUI itemUI in itemArray)
        {
            //Confirm Item
            if (itemUI != null)
            {
                //Set Item
                playerItemSlots_Array[counter].GetComponent<TM_ItemSlot>().ItemSlot_SetItem(itemUI);
            }

            //Update Counter
            counter++;
        }
    }

    ///////////////////////////////////////////////////////


    private void LookForInventoryKeys()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Attept To Drop SIngle Item From Hotbar
            if (isHoldingItem)
            {
                //Drop Item
                toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_DropItemSingle();
            }
        }
    }

    public void Inventory_FindAndRemoveItem(string itemName)
    {
        //Find Slots in Toolbar
        foreach (GameObject itemSlot in toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();


            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == itemName)
                {
                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    return;
                }
            }
        }

        //Find Slots in Inventory
        foreach (GameObject itemSlot in playerItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == itemName)
                {

                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    return;
                }
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void Toolbar_MoveSelector_SetHover(int hoverPosition)
    {
        //Remove other hovers
        foreach (GameObject toolbar in toolbarItemSlots_Array)
        {
            //Update Color to dark
            toolbar.GetComponent<Image>().color = new Color32(164, 164, 164, 255);
        }

        //Update Color to light
        toolbarItemSlots_Array[hoverPosition].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Set New Position
        currentToolbarPosition = hoverPosition;

        //Refresh Held Item Status
        Toolbar_MoveSelector_RefreshCurrent();
    }

    public void Toolbar_MoveSelector_RefreshCurrent()
    {
        //Check If Slot has an Item
        if (toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
        {
            //Set Animation Value
            isHoldingItem = true;
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(isHoldingItem);

            //Get Scriptable To Hold
            TM_ItemUI item = toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

            //Spawn Item
            TM_PlayerController_Animation.Instance.SpawnItemInHand_Hover(item.original_SO);
        }
        else
        {
            //Set Animation Value
            isHoldingItem = false;
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(isHoldingItem);

            //Remove Old Item
            TM_PlayerController_Animation.Instance.RemoveItemInHand_Right();
        }
    }

    ///////////////////////////////////////////////////////
}

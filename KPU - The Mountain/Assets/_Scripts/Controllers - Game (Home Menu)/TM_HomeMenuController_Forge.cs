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

public class TM_HomeMenuController_Forge : MonoBehaviour
{
    ////////////////////////////////

    public static TM_HomeMenuController_Forge Instance;

    ////////////////////////////////

    [Header("Item Slots")]
    public TM_ItemSlot[] storageItemSlots_Array;
    public TM_ItemSlot[] playerItemSlots_Array;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////// - Fire UI

    public void StorageMenu_OpenUI()
    {
        //Turn On Panel
        TM_PlayerMenuController_UI.Instance.Storage_Panel.SetActive(true);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Setup
        LoadInventory_Player();
    }

    public void StorageMenu_CloseUI()
    {
        //Tunr Off Panel
        TM_PlayerMenuController_UI.Instance.Storage_Panel.SetActive(false);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();

        //Save To Inventory
        TM_ItemUI[] itemArray = Player_GetItemsToArray();
        TM_PlayerMenuController_Inventory.Instance.Inventory_SetItemsFromArray(itemArray);
    }

    ///////////////////////////////////////////////////////

    private void LoadInventory_Player()
    {
        //Clear Items
        Player_ClearPlayerInventory();

        //Load Items
        TM_ItemUI[] itemArray = TM_PlayerMenuController_Inventory.Instance.Inventory_GetItemsToArray();
        Player_SetItemsFromArray(itemArray);
    }

    ///////////////////////////////////////////////////////

    private void Storage_ClearPlayerInventory()
    {
        //Clear All Items
        foreach (TM_ItemSlot itemSlot in storageItemSlots_Array)
        {
            itemSlot.ItemSlot_RemoveItem();
        }
    }

    private void Player_ClearPlayerInventory()
    {
        //Clear All Items
        foreach (TM_ItemSlot itemSlot in playerItemSlots_Array)
        {
            itemSlot.ItemSlot_RemoveItem();
        }
    }

    ///////////////////////////////////////////////////////

    private void Player_SetItemsFromArray(TM_ItemUI[] itemArray)
    {
        //Reset Counter
        int counter = 0;

        //Loop All Items Receievd
        foreach (TM_ItemUI itemUI in itemArray)
        {
            //Confirm Item
            if (itemUI != null)
            {
                //Set Item
                playerItemSlots_Array[counter].ItemSlot_SetItem(itemUI);
            }

            //Update Counter
            counter++;
        }
    }

    ///////////////////////////////////////////////////////

    public TM_ItemUI[] Player_GetItemsToArray()
    {
        //Create The Array
        TM_ItemUI[] itemArray = new TM_ItemUI[20];

        //Reset Counter
        int counter = 0;

        //Loop All Slots
        foreach (TM_ItemSlot itemSlot in playerItemSlots_Array)
        {
            //Confirm Item
            if (itemSlot.GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
            {
                //Add Item + Position
                itemArray[counter] = itemSlot.GetComponent<TM_ItemSlot>().ItemSlot_GetItem();
            }

            //Update Counter
            counter++;
        }

        //Return Filled Array
        return itemArray;
    }

    ///////////////////////////////////////////////////////





    ///////////////////////////////////////////////////////
}

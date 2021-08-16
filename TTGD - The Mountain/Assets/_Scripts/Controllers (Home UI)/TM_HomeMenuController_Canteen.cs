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
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_HomeMenuController_Canteen : MonoBehaviour
{
    ////////////////////////////////

    public static TM_HomeMenuController_Canteen Instance;

    ////////////////////////////////

    [Header("Item Slots")]
    public TM_ItemSlot[] playerItemSlots_Array;

    ////////////////////////////////

    [Header("UI Conainters")]
    public GameObject canteenFixed_Container;
    public GameObject canteenRepair_Container;

    ////////////////////////////////

    [Header("UI Repair - Checks / Crosses")]
    public GameObject canteenRepair_LogStatus_Check;
    public GameObject canteenRepair_LogStatus_Cross;
    public GameObject canteenRepair_IronStatus_Check;
    public GameObject canteenRepair_IronStatus_Cross;

    [Header("UI Repair - Repair Text")]
    public TextMeshProUGUI canteenRepair_CurrentLogs_Text;
    public TextMeshProUGUI canteenRepair_CurrentIronBars_Text;

    [Header("UI Repair - Button")]
    public Button canteenRepair_Button;

    ////////////////////////////////

    [Header("Current Forge")]
    TM_InteractableObject_Kitchen currentlyOpenCanteen;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Button_RepairCanteen()
    {
        //Build Forge
        currentlyOpenCanteen.RepairStructureCanteen();

        //Remove Items
        CanteenMenuRepair_RemoveRepairItems();

        //Close UI
        CanteenMenu_CloseUI();
    }

    ///////////////////////////////////////////////////////

    public void CanteenMenu_OpenUI(TM_InteractableObject_Kitchen canteen)
    {
        //Turn On Panel
        TM_PlayerMenuController_UI.Instance.Canteen_Panel.SetActive(true);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Set Opened Forge Value
        currentlyOpenCanteen = canteen;

        //Set Menu Type
        if (currentlyOpenCanteen.isFixed)
        {
            //Set Fixed Type
            canteenFixed_Container.SetActive(true);
            canteenRepair_Container.SetActive(false);

            //Setup
            CanteenMenuFixed_Setup();
            LoadInventory_Player();
        }
        else
        {
            //Set Repair Type
            canteenFixed_Container.SetActive(false);
            canteenRepair_Container.SetActive(true);

            //Setup
            CanteenMenuRepair_Setup();
            LoadInventory_Player();
        }
    }

    public void CanteenMenu_CloseUI()
    {
        //Tunr Off Panel
        TM_PlayerMenuController_UI.Instance.Canteen_Panel.SetActive(false);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();

        //Save To Inventory
        TM_ItemUI[] itemArray = Player_GetItemsToArray();
        TM_PlayerMenuController_Inventory.Instance.Inventory_SetItemsFromArray(itemArray);
    }

    ///////////////////////////////////////////////////////

    public void CanteenMenuRepair_Setup()
    {
        CanteenMenuRepair_SearchForRepairItems();
    }

    public void CanteenMenuRepair_SearchForRepairItems()
    {
        //Burnable Lists
        List<TM_ItemUI> itemsRepairItemLogs_List = new List<TM_ItemUI>();
        List<TM_ItemUI> itemsRepairItemIron_List = new List<TM_ItemUI>();


        //Find Slots in Toolbar
        foreach (GameObject itemSlot in TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == "Logs")
                {
                    itemsRepairItemLogs_List.Add(slot.ItemSlot_GetItem());
                }
                else if (slot.ItemSlot_GetItem().itemName == "Iron Bar")
                {
                    itemsRepairItemIron_List.Add(slot.ItemSlot_GetItem());
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
                if (slot.ItemSlot_GetItem().itemName == "Logs")
                {
                    itemsRepairItemLogs_List.Add(slot.ItemSlot_GetItem());
                }
                else if (slot.ItemSlot_GetItem().itemName == "Iron Bar")
                {
                    itemsRepairItemIron_List.Add(slot.ItemSlot_GetItem());
                }
            }
        }

        int countOfLogs = 0;
        int countOfIronBar = 0;

        foreach (TM_ItemUI item in itemsRepairItemLogs_List)
        {
            countOfLogs += item.currentStackSize;
        }

        foreach (TM_ItemUI item in itemsRepairItemIron_List)
        {
            countOfIronBar += item.currentStackSize;
        }



        //Set Visable Values
        canteenRepair_CurrentLogs_Text.text = "Current: " + countOfLogs;
        canteenRepair_CurrentIronBars_Text.text = "Current: " + countOfIronBar;

        //Refresh Button
        CanteenMenuRepair_RefreshRepairButton(countOfLogs, countOfIronBar);
    }

    public void CanteenMenuRepair_RefreshRepairButton(int countOfLogs, int countOfIronBar)
    {
        //Set Active Default
        canteenRepair_Button.interactable = true;


        if (countOfLogs >= 2)
        {
            canteenRepair_LogStatus_Check.SetActive(true);
            canteenRepair_LogStatus_Cross.SetActive(false);
        }
        else
        {
            canteenRepair_LogStatus_Check.SetActive(false);
            canteenRepair_LogStatus_Cross.SetActive(true);

            canteenRepair_Button.interactable = false;
        }

        if (countOfIronBar >= 3)
        {
            canteenRepair_IronStatus_Check.SetActive(true);
            canteenRepair_IronStatus_Cross.SetActive(false);
        }
        else
        {
            canteenRepair_IronStatus_Check.SetActive(false);
            canteenRepair_IronStatus_Cross.SetActive(true);

            canteenRepair_Button.interactable = false;
        }
    }

    public void CanteenMenuRepair_RemoveRepairItems()
    {
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Logs");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Logs");

        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
    }


    ///////////////////////////////////////////////////////

    public void CanteenMenuFixed_Setup()
    {

    }

    ///////////////////////////////////////////////////////

    private void LoadInventory_Player()
    {
        //Clear Items
        Player_ClearInventory();

        //Load Items
        TM_ItemUI[] itemArray = TM_PlayerMenuController_Inventory.Instance.Inventory_GetItemsToArray();
        Player_SetItemsFromArray(itemArray);
    }

    private void Player_ClearInventory()
    {
        //Clear All Items
        foreach (TM_ItemSlot itemSlot in playerItemSlots_Array)
        {
            itemSlot.ItemSlot_RemoveItem();
        }
    }

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
}

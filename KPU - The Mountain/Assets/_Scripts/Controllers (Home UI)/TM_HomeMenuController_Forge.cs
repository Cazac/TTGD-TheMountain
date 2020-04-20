using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public TM_ItemSlot[] forge_PlayerItemSlots_Array;

    ////////////////////////////////

    [Header("UI Conainters")]
    public GameObject forgeFixed_Container;
    public GameObject forgeRepair_Container;

    ////////////////////////////////

    [Header("UI Repair - Checks / Crosses")]
    public GameObject forgeRepair_LogStatus_Check;
    public GameObject forgeRepair_LogStatus_Cross;
    public GameObject forgeRepair_IronStatus_Check;
    public GameObject forgeRepair_IronStatus_Cross;

    [Header("UI Repair - Repair Text")]
    public TextMeshProUGUI forgeRepair_CurrentLogs_Text;
    public TextMeshProUGUI forgeRepair_CurrentIronBars_Text;

    [Header("UI Repair - Button")]
    public Button forgeRepair_Button;

    ////////////////////////////////


    ////////////////////////////////


    [Header("Info")]
    public TextMeshProUGUI upgradeItemTitle_Text;
    public TextMeshProUGUI upgradeItemDesc_Text;



    [Header("Info")]
    public TM_ItemSlot upgradeItemInput_Slot;
    public TM_ItemSlot upgradeItemIngredient1_Slot;
    public TM_ItemSlot upgradeItemIngredient2_Slot;
    public TM_ItemSlot upgradeItemIngredient3_Slot;

    public TM_ItemSlot upgradeItemOutput_Slot;

    ////////////////////////////////

    [Header("Current Forge")]
    private TM_InteractableObject_Forge currentlyOpenForge;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Button_RepairForge()
    {
        //Build Forge
        currentlyOpenForge.RepairStructureForge();

        //Remove Items
        ForgeMenuRepair_RemoveRepairItems();

        //Close UI
        ForgeMenu_CloseUI();
    }

    /////////////////////////////////////////////////////// - Forge UI

    public void ForgeMenu_OpenUI(TM_InteractableObject_Forge forge)
    {
        //Turn On Panel
        TM_PlayerMenuController_UI.Instance.Forge_Panel.SetActive(true);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Set Opened Forge Value
        currentlyOpenForge = forge;

        //Set Menu Type
        if (currentlyOpenForge.isFixed)
        {
            //Set Fixed Type
            forgeFixed_Container.SetActive(true);
            forgeRepair_Container.SetActive(false);

            //Setup
            ForgeMenuFixed_Setup();
            PlayerFixed_LoadInventory();
        }
        else
        {
            //Set Repair Type
            forgeFixed_Container.SetActive(false);
            forgeRepair_Container.SetActive(true);

            //Setup
            ForgeMenuRepair_Setup();
            PlayerFixed_LoadInventory();
        }
    }

    public void ForgeMenu_CloseUI()
    {
        //Tunr Off Panel
        TM_PlayerMenuController_UI.Instance.Forge_Panel.SetActive(false);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();

        //Clear Current Forge
        currentlyOpenForge = null;

        //Set Menu Type
        forgeFixed_Container.SetActive(false);
        forgeRepair_Container.SetActive(false);

        //Save To Inventory
        TM_ItemUI[] itemArray = PlayerFixed_GetItemsToArray();
        TM_PlayerMenuController_Inventory.Instance.Inventory_SetItemsFromArray(itemArray);
    }

    ///////////////////////////////////////////////////////

    public void ForgeMenuRepair_Setup()
    {



        ForgeMenuRepair_SearchForRepairItems();
    }

    public void ForgeMenuRepair_SearchForRepairItems()
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
        forgeRepair_CurrentLogs_Text.text = "Current: " + countOfLogs;
        forgeRepair_CurrentIronBars_Text.text = "Current: " + countOfIronBar;

        //Refresh Button
        ForgeMenuRepair_RefreshRepairButton(countOfLogs, countOfIronBar);
    }

    public void ForgeMenuRepair_RefreshRepairButton(int countOfLogs, int countOfIronBar)
    {
        //Set Active Default
        forgeRepair_Button.interactable = true;


        if (countOfLogs >= 2)
        {
            forgeRepair_LogStatus_Check.SetActive(true);
            forgeRepair_LogStatus_Cross.SetActive(false);
        }
        else
        {
            forgeRepair_LogStatus_Check.SetActive(false);
            forgeRepair_LogStatus_Cross.SetActive(true);

            forgeRepair_Button.interactable = false;
        }

        if (countOfIronBar >= 3)
        {
            forgeRepair_IronStatus_Check.SetActive(true);
            forgeRepair_IronStatus_Cross.SetActive(false);
        }
        else
        {
            forgeRepair_IronStatus_Check.SetActive(false);
            forgeRepair_IronStatus_Cross.SetActive(true);

            forgeRepair_Button.interactable = false;
        }
    }

    public void ForgeMenuRepair_RemoveRepairItems()
    {
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Logs");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Logs");

        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
        TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem("Iron Bar");
    }

    ///////////////////////////////////////////////////////

    public void ForgeMenuFixed_Setup()
    {
        ForgeMenuFixed_UpdateInputItems(null);
        ForgeMenuFixed_UpdateOutputItems();
    }

    public void ForgeMenuFixed_UpdateInputItems(TM_Item_SO itemSO)
    {
        if (itemSO == null)
        {
            upgradeItemTitle_Text.text = "Select a Weapon";
            upgradeItemDesc_Text.text = "";

            upgradeItemInput_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Weapon);

            upgradeItemIngredient1_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Question);
            upgradeItemIngredient2_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Question);
            upgradeItemIngredient3_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Question);

            upgradeItemIngredient1_Slot.ItemSlot_Disable();
            upgradeItemIngredient2_Slot.ItemSlot_Disable();
            upgradeItemIngredient3_Slot.ItemSlot_Disable();
        }
        else
        {
            upgradeItemTitle_Text.text = itemSO.itemName;
            upgradeItemDesc_Text.text = itemSO.itemDesc;

            upgradeItemInput_Slot.ItemSlot_SetItemFade(null);

            if (itemSO.weaponUpgrade_Mat1 != null)
            {
                upgradeItemIngredient1_Slot.ItemSlot_SetItemFade(itemSO.weaponUpgrade_Mat1.itemIcon);
                upgradeItemIngredient2_Slot.ItemSlot_SetItemFade(itemSO.weaponUpgrade_Mat2.itemIcon);
                upgradeItemIngredient3_Slot.ItemSlot_SetItemFade(itemSO.weaponUpgrade_Mat3.itemIcon);

                upgradeItemIngredient1_Slot.singleTypeItemSO = itemSO.weaponUpgrade_Mat1;
                upgradeItemIngredient2_Slot.singleTypeItemSO = itemSO.weaponUpgrade_Mat2;
                upgradeItemIngredient3_Slot.singleTypeItemSO = itemSO.weaponUpgrade_Mat3;

                upgradeItemIngredient1_Slot.ItemSlot_Enable();
                upgradeItemIngredient2_Slot.ItemSlot_Enable();
                upgradeItemIngredient3_Slot.ItemSlot_Enable();

                upgradeItemOutput_Slot.ItemSlot_SetItemFade(upgradeItemInput_Slot.ItemSlot_GetItem().itemIcon);
            }
            else
            {
                upgradeItemIngredient1_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Cross);
                upgradeItemIngredient2_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Cross);
                upgradeItemIngredient3_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Cross);


                upgradeItemIngredient1_Slot.ItemSlot_Disable();
                upgradeItemIngredient2_Slot.ItemSlot_Disable();
                upgradeItemIngredient3_Slot.ItemSlot_Disable();

                upgradeItemOutput_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Cross);
            }

        }
    }

    public void ForgeMenuFixed_UpdateOutputItems()
    {
        if (upgradeItemIngredient1_Slot.ItemSlot_GetItem() != null &&
            upgradeItemIngredient2_Slot.ItemSlot_GetItem() != null &&
            upgradeItemIngredient3_Slot.ItemSlot_GetItem() != null)
        {

            upgradeItemOutput_Slot.ItemSlot_SetItemFade(null);


            TM_ItemUI upgradedItem = new TM_ItemUI(upgradeItemInput_Slot.ItemSlot_GetItem().original_SO.weaponUpgrade_UpgradedWeapon);
            upgradeItemOutput_Slot.ItemSlot_SetItem(upgradedItem);
        }
        else
        {
            upgradeItemOutput_Slot.ItemSlot_RemoveItem();

            if (upgradeItemInput_Slot.ItemSlot_GetItem() != null)
            {
                upgradeItemOutput_Slot.ItemSlot_SetItemFade(upgradeItemInput_Slot.ItemSlot_GetItem().itemIcon);
            }
            else
            {
                upgradeItemOutput_Slot.ItemSlot_SetItemFade(TM_DatabaseController.Instance.icon_DB.forgeIcon_Question);
            }
        }
    }

    public void ForgeMenuFixed_ConsumeItems()
    {
        upgradeItemIngredient1_Slot.ItemSlot_RemoveItem();
        upgradeItemIngredient2_Slot.ItemSlot_RemoveItem();
        upgradeItemIngredient3_Slot.ItemSlot_RemoveItem();

        upgradeItemInput_Slot.ItemSlot_RemoveItem();

        ForgeMenuFixed_UpdateInputItems(null);
        ForgeMenuFixed_UpdateOutputItems();
    }

    ///////////////////////////////////////////////////////

    private void PlayerFixed_LoadInventory()
    {
        //Clear Items
        PlayerFixed_ClearInventory();

        //Load Items
        TM_ItemUI[] itemArray = TM_PlayerMenuController_Inventory.Instance.Inventory_GetItemsToArray();
        PlayerFixed_SetItemsFromArray(itemArray);
    }

    private void PlayerFixed_ClearInventory()
    {
        //Clear All Items
        foreach (TM_ItemSlot itemSlot in forge_PlayerItemSlots_Array)
        {
            itemSlot.ItemSlot_RemoveItem();
        }
    }

    private void PlayerFixed_SetItemsFromArray(TM_ItemUI[] itemArray)
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
                forge_PlayerItemSlots_Array[counter].ItemSlot_SetItem(itemUI);
            }

            //Update Counter
            counter++;
        }
    }

    public TM_ItemUI[] PlayerFixed_GetItemsToArray()
    {
        //Create The Array
        TM_ItemUI[] itemArray = new TM_ItemUI[20];

        //Reset Counter
        int counter = 0;

        //Loop All Slots
        foreach (TM_ItemSlot itemSlot in forge_PlayerItemSlots_Array)
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

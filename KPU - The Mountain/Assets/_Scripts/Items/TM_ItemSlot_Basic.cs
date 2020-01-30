using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

///////////////
/// <summary>
///     
/// TM_ItemSlot_Basic 
/// 
/// </summary>
///////////////

public class TM_ItemSlot_Basic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    ////////////////////////////////

    [Header("Cursor Settings")]
    public bool isCursorSlot;
    public bool isInventorySlot;
    public bool isToolbarSlot;
    public bool isContainerSlot;

    ////////////////////////////////

    [Header("Current Item Selected")]
    public TM_ItemUI_Base currentItem;

    ////////////////////////////////

    [Header("Slot Icon")]
    public Image slotIcon;

    [Header("Slot Durablity")]
    public GameObject slotDurablityBar_GO;
    public Image slotDurablityFillBar_Image;

    [Header("Slot Stack Size")]
    public GameObject slotStackSize_GO;
    public TextMeshProUGUI slotStackSize_Text;

    ////////////////////////////////

    //public TM_ItemUI_Base currentSlotItem;

    ///////////////////////////////////////////////////////

    private void Start()
    {
        //Debug Spawning
        SpawnRandomDebugItem();
    }

    ///////////////////////////////////////////////////////

    public void OnPointerClick(PointerEventData eventData)
    {
        //Look For Mouse Click Type
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Look for Shift 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                TryAction_QuickmoveStack();
            }
            //Look for CTRL
            else if (Input.GetKey(KeyCode.LeftControl))
            {

            }
            //No Input
            else
            {
                //Try To Select
                TryAction_Select();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Right Click
            TryAction_DetachSingle();
        }

        

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Create ToolTip
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Remove ToolTip
    }

    ///////////////////////////////////////////////////////

    private void SpawnRandomDebugItem()
    {
        if (isInventorySlot)
        {
            //Get Item Value
            int value = Random.Range(0, 4);

            //Check Valid Values
            if (value < (TM_DatabaseController.Instance.consumableFood_LIST.Count))
            {
                //Create New Item From Database
                TM_ItemUI_Base newItem = new TM_Item_ConsumableFood_UI(TM_DatabaseController.Instance.consumableFood_LIST[value]);

                //Set Debug Item
                ItemSlot_SetItem(newItem);
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void ItemSlot_SetItem(TM_ItemUI_Base newItem)
    {
        //Check for an Empty Stack
        if (newItem.CurrentStackSize <= 0)
        {
            //Remove Item
            ItemSlot_RemoveItem();
            return;
        }

        //Set Item
        currentItem = newItem;

        //Set Sprite
        slotIcon.gameObject.SetActive(true);
        slotIcon.sprite = currentItem.ItemIcon;

        //Durablity
        if (currentItem.MaxDurablity > 0)
        {
            //Turn On Durablity and Fill Bar
            slotDurablityBar_GO.SetActive(true);
            //slotDurablityFillBar_Image.fillAmount = (float)currentItem.currentDurablity / currentItem.maxDurablity;
        }
        else
        {
            //Turn Off Durablity and Reset Bar
            slotDurablityBar_GO.SetActive(false);
            //slotDurablityFillBar_Image.fillAmount = 1;
        }

        //Max Stack Size
        if (currentItem.MaxStackSize > 0)
        {
            //Turn On Durablity and Set Text
            slotStackSize_GO.SetActive(true);

            if (currentItem.CurrentStackSize == currentItem.MaxStackSize)
            {
                //Set Full Stack Color
                slotStackSize_Text.text = "<color=#ffff00>" + currentItem.CurrentStackSize.ToString() + "</color>";
            }
            else
            {
                //Set Default White
                slotStackSize_Text.text = currentItem.CurrentStackSize.ToString();
            }
        }
        else
        {
            //NOT RIGHT


            //Turn Off Stack Icon and Reset Text
            slotStackSize_GO.SetActive(true);
            slotStackSize_Text.text = "1";
        }
    }

    public void ItemSlot_RemoveItem()
    {
        //Clear Values
        currentItem = null;
        slotIcon.sprite = null;
        slotStackSize_Text.text = "";
        slotIcon.gameObject.SetActive(false);
        slotDurablityBar_GO.SetActive(false);
        slotStackSize_GO.SetActive(false);
    }

    public void ItemSlot_UpdateValues()
    {

    }

    ///////////////////////////////////////////////////////

    public void TryAction_DetachSingle()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_Inventory_PlaceSingle();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().ItemName == currentItem.ItemName)
                    {
                        //Attempt To Merge Stacks
                        Action_Inventory_CombineStacks();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_Inventory_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_Inventory_PickupStack();
                }
            }
        }
        else
        {
            print("Test Code: Oops, you forgot to set a slot tag!");
        }
    }

    public void TryAction_SplitStack()
    {

        //cursor

        //Target





    }

    public void TryAction_QuickmoveStack()
    {
        //Slot Type
        if (isInventorySlot)
        {


            //Check if Container is open!


            Action_Toolbar_QuickStack();


        }
        else if (isToolbarSlot)
        {

            //Check if Container is open!

            Action_Inventory_QuickStack();

        }


   


    }

    public void TryAction_Select()
    {
        //Slot Type
        if (isInventorySlot)
        {
            //Current Item
            if (currentItem == null)
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    //Set stack to Inventory
                    Action_Inventory_PlaceStack();
                }
                else
                {
                    //No Action
                    Action_NoAction();
                }
            }
            else
            {
                //Cursor Item
                if (TM_CursorController.Instance.Cursor_GetItem() != null)
                {
                    if (TM_CursorController.Instance.Cursor_GetItem().ItemName == currentItem.ItemName)
                    {
                        //Attempt To Merge Stacks
                        Action_Inventory_CombineStacks();
                    }
                    else
                    {
                        //Switch Stacks
                        Action_Inventory_SwitchStacks();
                    }
                }
                else
                {
                    //Pickup the stack and give to cursor
                    Action_Inventory_PickupStack();
                }
            }
        }
        else
        {
            print("Test Code: Oops, you forgot to set a slot tag!");
        }
        
        



    }

    ///////////////////////////////////////////////////////

    private void Action_NoAction()
    {
        print("Test Code: Double Empty / No Action");
    }

    ///////////////////////////////////////////////////////

    private void Action_Inventory_PickupStack()
    {
        //Give Item
        TM_CursorController.Instance.Cursor_SetItem(currentItem);

        //Remove Item
        ItemSlot_RemoveItem();
    }

    private void Action_Inventory_PlaceStack()
    {
        //Give Item
        ItemSlot_SetItem(TM_CursorController.Instance.Cursor_GetItem());

        //Remove Item
        TM_CursorController.Instance.Cursor_RemoveItem();
    }

    private void Action_Inventory_SwitchStacks()
    {
        //Get Items
        TM_ItemUI_Base inventoryItem = currentItem;
        TM_ItemUI_Base cursorItem = TM_CursorController.Instance.Cursor_GetItem();

        //Switch Values
        TM_CursorController.Instance.Cursor_SetItem(inventoryItem);
        ItemSlot_SetItem(cursorItem);
    }

    private void Action_Inventory_CombineStacks()
    {
        if (currentItem.MaxStackSize == 0)
        {
            print("Test Code: NOT SURE WHAT TO DO ERROR ERROR ERROR IS THIS A SPECIAL CODE???");
            return;
        }

        if (currentItem.CurrentStackSize < currentItem.MaxStackSize)
        {
            //Get Max Values For Passing and Incoming
            int maxAllowedItems_INV = currentItem.MaxStackSize - currentItem.CurrentStackSize;
            int maxPassableItems_CUR = TM_CursorController.Instance.Cursor_GetItem().CurrentStackSize;

            //Check for extra values
            if (maxPassableItems_CUR >= maxAllowedItems_INV)
            {
                //Give Some Values
                currentItem.CurrentStackSize += maxAllowedItems_INV;

                //Remove Some Values
                TM_CursorController.Instance.Cursor_GetItem().CurrentStackSize -= maxAllowedItems_INV;

                //Set Items Again To Refresh Stats
                ItemSlot_SetItem(currentItem);
                TM_CursorController.Instance.Cursor_SetItem(TM_CursorController.Instance.Cursor_GetItem());
            }
            else
            {
                //Deposit All Values
                currentItem.CurrentStackSize += TM_CursorController.Instance.Cursor_GetItem().CurrentStackSize;

                //Clear the Cursor
                TM_CursorController.Instance.Cursor_RemoveItem();

                //Set Items Again To Refresh Stats (Cursor was already removed)
                ItemSlot_SetItem(currentItem);
            }
        }
        else
        {
            //Go back and just swap stacks
            Action_Inventory_SwitchStacks();
        }
    }

    private void Action_Inventory_QuickStack()
    {

    }

    private void Action_Inventory_PickupSingle()
    {

    }

    private void Action_Inventory_PlaceSingle()
    {
        //Create a New Single Stack
        TM_ItemUI_Base newItemStack = TM_CursorController.Instance.Cursor_GetItem();
        newItemStack.CurrentStackSize = 1;

        //Give a Single Item
        ItemSlot_SetItem(newItemStack);

        //Remove a Single Item
        //TM_CursorController.Instance.Cursor_GetItem().CurrentStackSize--;
        TM_CursorController.Instance.Cursor_SetItem(TM_CursorController.Instance.Cursor_GetItem());
    }

    ///////////////////////////////////////////////////////

    private void Action_Toolbar_QuickStack()
    {
        //List of Possible Merges
        List<TM_ItemSlot_Basic> possibleEmptySpots_List = new List<TM_ItemSlot_Basic>();
        List<TM_ItemSlot_Basic> possibleMerges_List = new List<TM_ItemSlot_Basic>();

        ///////////////////////////////////////////////////////

        //Find Empty Slots in Toolbar
        foreach (GameObject itemSlot in TM_PlayerController_Inventory.Instance.toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot_Basic slot = itemSlot.GetComponent<TM_ItemSlot_Basic>();

            //Search Empty Spots
            if (slot.currentItem == null)
            {
                //Add to Empty Spots
                possibleEmptySpots_List.Add(slot);
            }
            else 
            {
                //Check For Matching Names
                if (slot.currentItem.ItemName == currentItem.ItemName)
                {
                    //Check For Non-Max Values
                    if (slot.currentItem.CurrentStackSize < slot.currentItem.MaxStackSize)
                    {
                        //Add to Mergable Spots
                        possibleMerges_List.Add(slot);
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////

        for (int i = 0; i < possibleMerges_List.Count; i++)
        {
            //Check if No values left to add
            if (currentItem.CurrentStackSize <= 0)
            {
                print("Test Code: IS THIS POSSIBLE TO HIT????");
                //Break Out Of Method, There is Nothing left to do
                return;
            }
            else
            {
                //Calculate Max Item Recivable / Passable
                int maxAllowedItems_TOL = possibleMerges_List[i].currentItem.MaxStackSize - possibleMerges_List[i].currentItem.CurrentStackSize;
                int maxPassableItems_INV = currentItem.CurrentStackSize;

                //Check for extra values
                if (maxPassableItems_INV >= maxAllowedItems_TOL)
                {
                    //Give Some Values
                    possibleMerges_List[i].currentItem.CurrentStackSize += maxAllowedItems_TOL;

                    //Remove Some Values
                    currentItem.CurrentStackSize -= maxAllowedItems_TOL;

                    //Set Items Again To Refresh Stats
                    ItemSlot_SetItem(currentItem);
                    possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);
                }
                else
                {
                    //Deposit All Values
                    possibleMerges_List[i].currentItem.CurrentStackSize += currentItem.CurrentStackSize;

                    //Clear the INV Item
                    ItemSlot_RemoveItem();

                    //Set Items Again To Refresh Stats (INV was already removed)
                    possibleMerges_List[i].ItemSlot_SetItem(possibleMerges_List[i].currentItem);

                    //Break Out Of Method, There is Nothing left to do
                    return;
                }
            }
        }

        ///////////////////////////////////////////////////////

        if (possibleEmptySpots_List.Count > 0)
        {
            //Move Stack
            possibleEmptySpots_List[0].ItemSlot_SetItem(currentItem);

            //Remove Stack
            ItemSlot_RemoveItem();

            //Break Out Of Method, There is Nothing left to do
            return;
        }

        ///////////////////////////////////////////////////////




        //if none found then send To top of the  ?????????????????





    }


    /*

    ///////////////////////////////////////////////////////

    void Action_PickupStack_InventoryToCursor();

    ///////////////////////////////////////////////////////

    void Action_PlaceStack_CursorToInventory();

    void Action_PlaceStack_CursorToContainer();

    ///////////////////////////////////////////////////////

    void Action_MergeStack_CursorToInventory();

    void Action_SwapStacks_CursorToInventory();

    ///////////////////////////////////////////////////////

    void Action_DiscardStack_CursorToGround();

    void Action_DiscardSingle_CursorToGround();

    ///////////////////////////////////////////////////////

    void Action_QuickmoveStack_InventoryToToolbar();

    void Action_QuickmoveStack_InventoryToContainer();

    void Action_QuickmoveStack_ToolbarToInventory();

    void Action_QuickmoveStack_ToolbarToContainer();

    void Action_QuickmoveStack_ContainerToInventory();

    void Action_QuickmoveStack_ContainerToToolbar();


    */
    ///////////////////////////////////////////////////////
}

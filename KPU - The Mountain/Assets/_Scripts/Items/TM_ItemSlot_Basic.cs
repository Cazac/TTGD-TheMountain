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

        //Look for Shift 
        if (Input.GetKey(KeyCode.LeftShift))
        {

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
            int value = Random.Range(0, 6);

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
        if (newItem.MaxStackSize > 1)
        {
            //Turn On Durablity and Set Text
            slotStackSize_GO.SetActive(true);
            slotStackSize_Text.text = currentItem.CurrentStackSize.ToString();
        }
        else
        {
            //NOT RIGHT


            //Turn Off Stack Icon and Reset Text
            slotStackSize_GO.SetActive(true);
            slotStackSize_Text.text = "";
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

    public void TryAction_SplitStack()
    {

        //cursor

        //Target





    }

    public void TryAction_QuickmoveStack()
    {

        //cursor

        //Target





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
                print("Test Code: Stack All");

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
                print("Test Code: Stack Some");

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
            print("Test Code: Just Swap");

            //Go back and just swap stacks
            Action_Inventory_SwitchStacks();
        }
    }

    ///////////////////////////////////////////////////////



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

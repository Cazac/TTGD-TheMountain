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
    public bool isCursorItem;

    ////////////////////////////////

    [Header("Current Item Selected")]
    public TM_Item_ConsumableFood_SO currentItem;

    ////////////////////////////////

    [Header("Slot Icon")]
    public Image slotIcon;

    [Header("Slot Durablity")]
    public GameObject slotDurablityBar_GO;

    [Header("Slot Stack Size")]
    public GameObject slotStackSize_GO;
    public TextMeshProUGUI slotStackSize_Text;

    ////////////////////////////////

    public TM_ItemUI_Base currentSlotItem;

    ///////////////////////////////////////////////////////

    private void Start()
    {
        //slotIcon = gameObject.transform.Find("slotIcon").GetComponent<Image>();
        // slotDurablityBar = gameObject.transform.Find("slotDurablityBar").GetComponent<Image>();
        // slotStackSize_Text = gameObject.transform.Find("slotStackSize_Text").GetComponent<TextMeshProUGUI>();


        int value = Random.Range(0, 20);


        if (value < 5)
        {
            SpawnRandomDebugItem(0);
        }
        else if (value < 10)
        {
            SpawnRandomDebugItem(1);
        }

    }

    ///////////////////////////////////////////////////////

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCursorItem)
        {
            return;
        }


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
        //print("Test Code: Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("Test Code: Leave");
    }

    ///////////////////////////////////////////////////////

    private void SpawnRandomDebugItem(int input)
    {
        if (isCursorItem)
        {
            return;
        }

        currentItem = TM_DatabaseController.Instance.consumableFood_LIST[input];


        slotIcon.sprite = currentItem.icon;
        slotIcon.gameObject.SetActive(true);

        //Durablity
        if (currentItem.maxDurablity > 0)
        {
            slotDurablityBar_GO.SetActive(true);
        }
        else
        {
            slotDurablityBar_GO.SetActive(false);
        }

        //Max Stack Size
        if (currentItem.maxStackSize > 1)
        {
            slotStackSize_GO.SetActive(true);

            slotStackSize_Text.text = "1";
        }
        else
        {
            slotStackSize_GO.SetActive(true);
            //slotStackSize_GO.SetActive(false);

            slotStackSize_Text.text = "";
        }


    }

    ///////////////////////////////////////////////////////

    public void ItemSlot_SetItem(TM_Item_ConsumableFood_SO newItem)
    {
        slotIcon.gameObject.SetActive(true);
        slotDurablityBar_GO.SetActive(true);
        slotStackSize_GO.SetActive(true);


     

        //print("Test Code: Item " + newItem);


        currentItem = newItem;

        slotIcon.sprite = newItem.icon;


        if (newItem.maxDurablity > 0)
        {
            slotDurablityBar_GO.SetActive(true);
        }
        else
        {
            slotDurablityBar_GO.SetActive(false);
        }

        if (newItem.maxStackSize > 1)
        {
            slotStackSize_GO.SetActive(true);

            slotStackSize_Text.text = "1";
        }
        else
        {
            slotStackSize_GO.SetActive(true);


            //slotStackSize_GO.SetActive(false);

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


        //Switch
        if (currentItem == null)
        {
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
            if (TM_CursorController.Instance.Cursor_GetItem() != null)
            {
                //Switch Stacks
                Action_Inventory_SwitchStacks();
            }
            else
            {
                //Pickup the stack and give to cursor
                Action_Inventory_PickupStack();
            }
        }






     



        //slotIcon.gameObject.SetActive(true);





        //cursor
        //Target

        //if ()
        {
            //Action_DiscardStack_CursorToGround();
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
        TM_Item_ConsumableFood_SO inventoryItem = currentItem;
        TM_Item_ConsumableFood_SO cursorItem = TM_CursorController.Instance.Cursor_GetItem();

        //Switch Values
        TM_CursorController.Instance.Cursor_SetItem(inventoryItem);
        ItemSlot_SetItem(cursorItem);
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

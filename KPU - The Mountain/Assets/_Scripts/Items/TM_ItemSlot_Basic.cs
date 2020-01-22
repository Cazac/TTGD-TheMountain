using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TM_ItemSlot_Basic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    ///////////////////////////////////////////////////////

    public Image slotIcon;

    public Image slotDurablityBar;



    public TextMeshProUGUI slotStackSize_Text;

    public TM_ItemUI_Base currentSlotItem;

    ///////////////////////////////////////////////////////


    private void Start()
    {
        //slotIcon = gameObject.transform.Find("slotIcon").GetComponent<Image>();
       // slotDurablityBar = gameObject.transform.Find("slotDurablityBar").GetComponent<Image>();
       // slotStackSize_Text = gameObject.transform.Find("slotStackSize_Text").GetComponent<TextMeshProUGUI>();
    }

    ///////////////////////////////////////////////////////

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Test Code: Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Test Code: Yeah");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Test Code: No");
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

        //cursor

        //Target

        //if ()
        {
            //Action_DiscardStack_CursorToGround();
        }



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

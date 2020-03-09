using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_InteractableObject_PlacedItem : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 7f;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to pickup object");
    }

    public void OnInteractTap()
    {  
        //Get Placed Object Script
        TM_ItemPlaced placedObject = gameObject.GetComponent<TM_ItemPlaced>();

        //Check If Valid Item Count First
        if (placedObject.currentStackSize <= 0)
        {
            print("Test Code: Oops No Stack Size");
            placedObject.currentStackSize = 1;
        }

        //Check For Space First



        //Deep Copy and Convert Item to UI
        TM_ItemUI newItemUI = new TM_ItemUI(placedObject.orginalItem_SO);

        //Set Item To cursor
        TM_CursorController.Instance.Cursor_SetItem(newItemUI);

        //Try To Quick Add to INV
        TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
    }

    public void OnInteractHold()
    {
        return;
    }

    public void OnInteractEndHold()
    {
        return;
    }

    public void OnEndHover()
    {
        TM_InteractionController.Instance.InteractionText_Remove();
    }

    ///////////////////////////////////////////////////////
}

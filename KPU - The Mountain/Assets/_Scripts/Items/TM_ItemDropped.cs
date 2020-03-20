using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemDropped : MonoBehaviour
{
    ////////////////////////////////

    [Header("Scriptable Object")]
    public TM_Item_SO originalItem_SO;

    ////////////////////////////////

    [Header("Current Values")]
    public int currentStackSize;
    public int currentDurablity;

    public bool hasCollided;

    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //Check If Valid Item Count First
        if (currentStackSize <= 0)
        {
            print("Test Code: Oops No Stack Size");
            currentStackSize = 1;
        }


        //Check For Space First


        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            if (hasCollided)
            {
                return;
            }
            else
            {
                //Set bool to allow single pickup
                hasCollided = true;

                //Conversion To UI
                ItemConversion_UI();
            }
        }
    }

    ///////////////////////////////////////////////////////

    private void ItemConversion_UI()
    {
        //Deep Copy and Convert Item to UI
        TM_ItemUI newItemUI = new TM_ItemUI(originalItem_SO);

        //Set Stack and Durablity
        newItemUI.currentStackSize = currentStackSize;
        newItemUI.currentDurablity = currentDurablity;

        //Set Item To cursor
        TM_CursorController.Instance.Cursor_SetItem(newItemUI);

        //Try To Quick Add to INV
        TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
    }

    ///////////////////////////////////////////////////////
}

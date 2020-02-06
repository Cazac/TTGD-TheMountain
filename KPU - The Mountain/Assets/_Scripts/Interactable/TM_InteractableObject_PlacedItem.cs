using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_InteractableObject_PlacedItem : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 30f;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to pickup object");
    }

    public void OnInteractTap()
    {  
        //Get Placed Object Script
        TM_ItemPlaced placedObject = gameObject.GetComponent<TM_ItemPlaced>();

        //Filter Filled Scriptable Type
        if (placedObject.originalScriptableItem_ConsumableFood != null)
        {
            //Deep Copy and Convert Item to UI
            TM_ItemUI_ConsumableFood newItemUI = new TM_ItemUI_ConsumableFood(placedObject.originalScriptableItem_ConsumableFood);

            //Set Item To cursor
            TM_CursorController.Instance.Cursor_SetItem(newItemUI);

            //Try To Quick Add to INV
            TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
        }
        else if (placedObject.originalScriptableItem_ConsumablePotions != null)
        {
            print("Test Code: OOPs");
        }
        else if (placedObject.originalScriptableItem_EquiptableWeapons != null)
        {
            //Deep Copy and Convert Item to UI
            TM_ItemUI_EquiptableWeapons newItemUI = new TM_ItemUI_EquiptableWeapons(placedObject.originalScriptableItem_EquiptableWeapons);

            //Set Item To cursor
            TM_CursorController.Instance.Cursor_SetItem(newItemUI);

            //Try To Quick Add to INV
            TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
        }
        else
        {
            print("Test Code: OOPs");
        }
            

        /*

        //Filter Object Type
        if (placedObject.originalScriptableItem.GetType() == typeof(TM_Item_ConsumableFood_SO))
        {
            //Cast Type Of Object
            TM_Item_ConsumableFood_SO newItemScriptable = (TM_Item_ConsumableFood_SO)placedObject.originalScriptableItem;

            //Deep Copy and Convert Item to UI
            TM_Item_ConsumableFood_UI newItemUI = new TM_Item_ConsumableFood_UI(newItemScriptable);

            //Set Item To cursor
            TM_CursorController.Instance.Cursor_SetItem(newItemUI);

            //Try To Quick Add to INV
            TM_CursorController.Instance.TryAction_AddItemToInventory();

        }
        else if (placedObject.originalScriptableItem.GetType() == typeof(TM_Item_EquiptableArmor_SO))
        {
            //Invalid Needs Other Tpyes
            print("Tt Code: OOOOPS NEEDS OTHER TPYES");
        }
        else
        {
            print("Tt Code: OOOOPS NEEDS OTHER TPYES");
        }
        */

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

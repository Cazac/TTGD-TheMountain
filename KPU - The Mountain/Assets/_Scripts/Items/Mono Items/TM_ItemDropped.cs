using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemDropped : MonoBehaviour
{
    ////////////////////////////////

    [Header("Scriptable Objects")]
    public TM_Item_ConsumableFood_SO originalScriptableItem_ConsumableFood;
    public TM_Item_ConsumablePotions_SO originalScriptableItem_ConsumablePotions;
    public TM_Item_EquiptableWeapons_SO originalScriptableItem_EquiptableWeapons;
    public TM_Item_EquiptableArmor_SO originalScriptableItem_EquiptableArmor;


    [HideInInspector]
    public int currentStackSize;
    public int currentDurablity;


    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            //Filter Filled Scriptable Type
            if (originalScriptableItem_ConsumableFood != null)
            {
                ItemConversion_ConsumableFood();
            }
            else if (originalScriptableItem_ConsumablePotions != null)
            {
                print("Test Code: OOPS (Wrong Type)");
            }
            else if (originalScriptableItem_EquiptableArmor != null)
            {
                print("Test Code: OOPS (Wrong Type)");
            }
            else if (originalScriptableItem_EquiptableWeapons != null)
            {
                ItemConversion_EquiptableWeapon();
            }
            else
            {
                print("Test Code: OOPS (Wrong Type)");
            }
        }
    }


    ///////////////////////////////////////////////////////

    private void ItemConversion_ConsumableFood()
    {
        //Deep Copy and Convert Item to UI
        TM_ItemUI_ConsumableFood newItemUI = new TM_ItemUI_ConsumableFood(originalScriptableItem_ConsumableFood);

        //Set Stack and Durablity
        newItemUI.CurrentStackSize = currentStackSize;
        newItemUI.CurrentDurablity = currentDurablity;

        //Set Item To cursor
        TM_CursorController.Instance.Cursor_SetItem(newItemUI);

        //Try To Quick Add to INV
        TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
    }

    private void ItemConversion_EquiptableWeapon()
    {
        //Deep Copy and Convert Item to UI
        TM_ItemUI_EquiptableWeapons newItemUI = new TM_ItemUI_EquiptableWeapons(originalScriptableItem_EquiptableWeapons);

        //Set Stack and Durablity
        if (currentStackSize == 0)
        {
            newItemUI.CurrentStackSize = 1;
        }
        else
        {
            newItemUI.CurrentStackSize = currentStackSize;
        }

        //Set Stack and Durablity
        newItemUI.CurrentDurablity = currentDurablity;

        //Set Item To cursor
        TM_CursorController.Instance.Cursor_SetItem(newItemUI);

        //Try To Quick Add to INV
        TM_CursorController.Instance.TryAction_AddItemToInventory(gameObject);
    }



    ///////////////////////////////////////////////////////
}

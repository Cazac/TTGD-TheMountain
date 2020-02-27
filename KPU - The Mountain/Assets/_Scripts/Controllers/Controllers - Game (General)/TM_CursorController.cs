﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_CursorController 
/// 
/// </summary>
///////////////

public class TM_CursorController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_CursorController Instance;

    ////////////////////////////////

    private TM_ItemSlot cursorItemSlot;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Set Slotbox
        cursorItemSlot = gameObject.GetComponent<TM_ItemSlot>();
    }

    private void Update()
    {
        //Follow Cursor
        FollowCursor();
    }

    ///////////////////////////////////////////////////////

    private void FollowCursor()
    {
        //Only Folllow When Full
        if (Cursor_GetItem() != null)
        {
            //Move Icon with cursor
            Vector3 cursorPosition = (Input.mousePosition);
            cursorPosition.z = -5;

            //Apply position
            gameObject.transform.position = cursorPosition;
        }
    }

    ///////////////////////////////////////////////////////

    public TM_ItemUI Cursor_GetItem()
    {
        return cursorItemSlot.ItemSlot_GetItem();
    }

    public void Cursor_SetItem(TM_ItemUI item)
    {
        gameObject.GetComponent<TM_ItemSlot>().ItemSlot_SetItem(item);
    }

    public void Cursor_UpdateItem()
    {
        gameObject.GetComponent<TM_ItemSlot>().ItemSlot_UpdateItem();
    }
    
    public void Cursor_RemoveItem()
    {
        gameObject.GetComponent<TM_ItemSlot>().ItemSlot_RemoveItem();
    }

    public void Cursor_DropItem()
    {
        gameObject.GetComponent<TM_ItemSlot>().ItemSlot_DropItem();
    }

    public void Cursor_DupplicateItem(TM_ItemUI item)
    {
        gameObject.GetComponent<TM_ItemSlot>().ItemSlot_DupplicateItem(item);
    }

    ///////////////////////////////////////////////////////

    public void TryAction_AddItemToInventory(GameObject interactedItem)
    {
        //Looking For Possible Merges In Toolbar
        if (gameObject.GetComponent<TM_ItemSlot>().Action_Toolbar_QuickStack())
        {
            //All Good, Destory Me!
            Destroy(interactedItem);
        }
        else
        {
            //Looking For Possible Merges In Inventory
            if (gameObject.GetComponent<TM_ItemSlot>().Action_Inventory_QuickStack())
            {
                //All Good, Destory Me!
                Destroy(interactedItem);
            }
            else
            {
                //Nothing Worked Leave Item Alone
                gameObject.GetComponent<TM_ItemSlot>().Action_NoAction();
            }
        }

        //Remove Item From Cursor Anyways
        Cursor_RemoveItem();
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
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

    private TM_ItemSlot_Basic cursorItemSlot;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Set Slotbox
        cursorItemSlot = gameObject.GetComponent<TM_ItemSlot_Basic>();
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

    public TM_ItemUI_Base Cursor_GetItem()
    {
        return cursorItemSlot.currentItem;
    }

    public void Cursor_SetItem(TM_ItemUI_Base item)
    {
        gameObject.GetComponent<TM_ItemSlot_Basic>().ItemSlot_SetItem(item);
    }

    public void Cursor_RemoveItem()
    {
        gameObject.GetComponent<TM_ItemSlot_Basic>().ItemSlot_RemoveItem();
    }

    ///////////////////////////////////////////////////////
}

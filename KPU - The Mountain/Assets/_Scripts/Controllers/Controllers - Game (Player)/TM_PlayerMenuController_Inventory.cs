using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_PlayerController_Movement takes input and moves the player.
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Inventory : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Inventory Instance;

    ////////////////////////////////

    [Header("Item Slots")]
    public GameObject[] toolbarItemSlots_Array;
    public GameObject[] playerItemSlots_Array;

    ////////////////////////////////

    public int currentToolbarPosition;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Toolbar_MoveSelector_SetHover(int hoverPosition)
    {
        //Remove other hovers
        foreach (GameObject toolbar in toolbarItemSlots_Array)
        {
            //Update Color to dark
            toolbar.GetComponent<Image>().color = new Color32(164, 164, 164, 255);
        }

        //Update Color to light
        toolbarItemSlots_Array[hoverPosition].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Set New Position
        currentToolbarPosition = hoverPosition;


        // ***** DEBUG CODE ******




        //Check If Slot has an Item
        if (toolbarItemSlots_Array[hoverPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
        {
            //Set Animation Value
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(true);

            TM_ItemUI item = toolbarItemSlots_Array[hoverPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

            //Spawn Item
            TM_PlayerController_Animation.Instance.SpawnItemInHand_Hover(item.original_SO);
        }
        else
        {
            //Set Animation Value
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(false);

            //Remove Old Item
            TM_PlayerController_Animation.Instance.RemoveItemInHand_Right();
        }









        // ***** DEBUG CODE ******
    }

    ///////////////////////////////////////////////////////
}

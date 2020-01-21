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

public class TM_PlayerController_Inventory : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Inventory Instance;

    ////////////////////////////////

    public GameObject[] toolbarItemSlots_Array;

    public GameObject[] playerItemSlots_Array;






    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Toolbar_MoveSelector_MouseScroll()
    {

    }

    public void Toolbar_MoveSelector_InputKey(int slotPosition)
    {

        Toolbar_SetHover(slotPosition);

    }

    private void Toolbar_SetHover(int hoverPosition)
    {
        toolbarItemSlots_Array[hoverPosition].GetComponent<Image>().color = new Color(255, 255, 255);





    }


    ///////////////////////////////////////////////////////





    ///////////////////////////////////////////////////////
}

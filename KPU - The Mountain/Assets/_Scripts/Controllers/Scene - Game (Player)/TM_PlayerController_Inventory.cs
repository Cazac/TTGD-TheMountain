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

            toolbar.GetComponent<Image>().color = new Color32(164, 164, 164, 255);
        }

        toolbarItemSlots_Array[hoverPosition].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        currentToolbarPosition = hoverPosition;




    }


    ///////////////////////////////////////////////////////





    ///////////////////////////////////////////////////////
}

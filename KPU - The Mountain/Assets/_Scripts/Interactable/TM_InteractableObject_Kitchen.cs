using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_InteractableObject_Furnace is the interactable object for the Forge fire.
/// 
/// </summary>
///////////////

public class TM_InteractableObject_Kitchen : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    //Get and Set Activation Range Value
    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 5f;

    ////////////////////////////////

    [Header("Outline Tool")]
    public TOOL_Outline outlineTool;

    [Header("Fixed Status")]
    public bool isFixed;

    [Header("States")]
    public GameObject kitchen_Broken;
    public GameObject kitchen_Fixed;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        //Set Interaction Text On Hover
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to access The Canteen");

        outlineTool.enabled = true;
    }

    public void OnEndHover()
    {
        //Remove Interaction Text On Hover Removal
        TM_InteractionController.Instance.InteractionText_Remove();

        outlineTool.enabled = false;
    }

    ///////////////////////////////////////////////////////

    public void OnInteractTap()
    {
        //Check If Panel is Already Active
        if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Canteen_Panel.activeSelf == true)
        {
            //Close UI
            TM_HomeMenuController_Canteen.Instance.CanteenMenu_CloseUI();
        }
        else if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Canteen_Panel.activeSelf == false)
        {
            return;
        }
        else
        {
            //Open UI
            TM_HomeMenuController_Canteen.Instance.CanteenMenu_OpenUI(this);
        }
    }

    ///////////////////////////////////////////////////////

    public void OnInteractHold()
    {
        //Does Not Support Hold Interaction
        return;
    }

    public void OnInteractEndHold()
    {
        //Does Not Support Hold Interaction
        return;
    }

    ///////////////////////////////////////////////////////

    public void BreakStructureCanteen()
    {
        isFixed = false;

        //Turn On Visable GO
        kitchen_Fixed.SetActive(false);
        kitchen_Broken.SetActive(true);
    }

    public void RepairStructureCanteen()
    {
        isFixed = true;

        //Turn On Visable GO
        kitchen_Fixed.SetActive(true);
        kitchen_Broken.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_InteractableObject_Furnace is the interactable object for the Forge fire.
/// 
/// </summary>
///////////////

public class TM_InteractableObject_Workshop : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    //Get and Set Activation Range Value
    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 5f;

    ////////////////////////////////

    public TOOL_Outline outlineTool;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        //Set Interaction Text On Hover
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to access The Workshop");

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
        if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Workshop_Panel.activeSelf == true)
        {
            //Close UI
            TM_HomeMenuController_Workshop.Instance.WorkshopMenu_CloseUI();
        }
        else if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Workshop_Panel.activeSelf == false)
        {
            return;
        }
        else
        {
            //Open UI
            TM_HomeMenuController_Workshop.Instance.WorkshopMenu_OpenUI();
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
}

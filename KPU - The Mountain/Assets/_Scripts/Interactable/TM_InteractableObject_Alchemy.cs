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

public class TM_InteractableObject_Alchemy : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    //Get and Set Activation Range Value
    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 5f;

    ////////////////////////////////

    [Header("Outline Tool")]
    public TOOL_Outline outlineTool;

    ////////////////////////////////

    [Header("Building Containers")]
    public GameObject brewery_Built;
    public GameObject brewery_Broken;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        //Set Interaction Text On Hover
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to access The Brewery");

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
        if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Brewery_Panel.activeSelf == true)
        {
            //Close UI
            TM_HomeMenuController_Brewery.Instance.BreweryMenu_CloseUI();

        }
        else if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Brewery_Panel.activeSelf == false)
        {
            return;
        }
        else
        {
            if (TM_DatabaseController.Instance.player_SaveData.player_HasUnlocked_Brewery)
            {
                //Open UI
                TM_HomeMenuController_Brewery.Instance.BreweryMenu_OpenUI();
            }
            else
            {
                //Open UI
                TM_HomeMenuController_Brewery.Instance.BreweryMenu_OpenUI();
            }
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

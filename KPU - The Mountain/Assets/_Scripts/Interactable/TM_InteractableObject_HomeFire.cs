﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_InteractableObject_HomeFire is the interactable object for the home fire.
/// 
/// </summary>
///////////////

public class TM_InteractableObject_HomeFire : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    //Get and Set Activation Range Value
    public float MaxRange { get { return MAXRANGE; } }
    private const float MAXRANGE = 5f;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        //Set Interaction Text On Hover
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to access The Fire");
    }

    public void OnEndHover()
    {
        //Remove Interaction Text On Hover Removal
        TM_InteractionController.Instance.InteractionText_Remove();
    }

    ///////////////////////////////////////////////////////

    public void OnInteractTap()
    {
        //Check If Panel is Already Active
        if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Fire_Panel.activeSelf == true)
        {
            //Close UI
            TM_HomeMenuController_Fire.Instance.FireMenu_CloseUI();
        }
        else if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu && TM_PlayerMenuController_UI.Instance.Fire_Panel.activeSelf == false)
        {
            return;
        }
        else
        {
            //Open UI
            TM_HomeMenuController_Fire.Instance.FireMenu_OpenUI();
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

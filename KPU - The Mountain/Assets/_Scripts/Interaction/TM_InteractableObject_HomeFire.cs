using System.Collections;
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
    
    public float maxRange { get { return MAXRANGE; } }

    private const float MAXRANGE = 40f;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to access the fire");
    }

    public void OnInteractTap()
    {
        if (TM_PlayerController_UI.Instance.Fire_Panel.activeSelf)
        {
            TM_PlayerController_UI.Instance.Action_Fire_CloseUI();
        }
        else
        {
            TM_PlayerController_UI.Instance.Action_Fire_OpenUI();
        }
    }

    public void OnInteractHold()
    {
        return;
    }

    public void OnInteractEndHold()
    {
        return;
    }

    public void OnEndHover()
    {
        TM_InteractionController.Instance.InteractionText_Remove();
    }

    ///////////////////////////////////////////////////////
}

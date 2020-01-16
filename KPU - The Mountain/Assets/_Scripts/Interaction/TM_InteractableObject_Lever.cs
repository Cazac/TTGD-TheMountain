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

public class TM_InteractableObject_Lever : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    public float maxRange { get { return MAXRANGE; } }

    private const float MAXRANGE = 40f;
    public float holdTime;
    public float holdMax;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        TM_InteractionController.Instance.InteractionText_Set("Hold (F) to pickup object.");
    }

    public void OnInteractTap()
    {
        print("Test Code: Picked Up Item");
    }

    public void OnInteractHold()
    {
        //if ()
        {
            TM_InteractionController.Instance.InteractionHoldIcon_UpdateValue();
        }
        //else
        {
            //TM_InteractionController.Instance.holdicon();
        }

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
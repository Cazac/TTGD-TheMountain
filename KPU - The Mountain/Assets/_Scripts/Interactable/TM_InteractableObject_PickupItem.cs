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

public class TM_InteractableObject_PickupItem : MonoBehaviour, TM_InteractableObject_Base
{
    ////////////////////////////////

    public float maxRange { get { return MAXRANGE; } }

    public float MaxRange => throw new System.NotImplementedException();

    private const float MAXRANGE = 40f;

    ///////////////////////////////////////////////////////

    public void OnStartHover()
    {
        TM_InteractionController.Instance.InteractionText_Set("Press (F) to pickup object.");
    }

    public void OnInteractTap()
    {
        print("Test Code: Picked Up Item");
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

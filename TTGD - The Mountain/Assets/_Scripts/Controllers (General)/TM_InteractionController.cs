using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_InteractionController is used to raycast the players camera to find interactable object for the player to use. 
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_InteractionController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_InteractionController Instance;

    ////////////////////////////////

    [SerializeField]
    private float raycastRange;

    [Header("Camera and Target")]
    private Camera raycastCamera;
    private TM_InteractableObject_Base currentTarget;

    [Header("Interaction Gameobjects")]
    public TextMeshProUGUI playerInteraction_Text;
    public Image playerInteraction_Icon;
    public GameObject playerInteractionDot;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Set Main Camera Refference
        raycastCamera = Camera.main;
    }

    private void Update()
    {
        //Get Raycast Object
        RaycastForInteractable();

        //Look for Interaction Key Press and Hold
        LookForMenuKey_Interaction();
    }

    /////////////////////////////////////////////////////////////////

    private void RaycastForInteractable()
    {
        //Get ray direction from user mouse
        Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

        //Send raycast from mouse position
        if (Physics.Raycast(ray, out RaycastHit objectHit, raycastRange))
        {
            //Object collided with raycast by range
            TM_InteractableObject_Base interactableObject = objectHit.collider.GetComponent<TM_InteractableObject_Base>();

            //Check If Valid
            if (interactableObject != null)
            {
                //Check If In Range
                if (objectHit.distance <= interactableObject.MaxRange)
                {
                    if (interactableObject == currentTarget)
                    {
                        //Target Still Active - No Changes
                        return;
                    }
                    else if (currentTarget != null)
                    {
                        //New Target Found With Existing Old - Remove Old / Change Target / Hover New
                        currentTarget.OnEndHover();
                        currentTarget = interactableObject;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        //New Target Found With No Current - Change Target / Hover New
                        currentTarget = interactableObject;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                else
                {
                    //Raycast Object is Not Valid Interactable - Remove Object If Possible
                    if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = null;
                        return;
                    }
                }
            }
            else
            {
                //No Raycast Hit - Remove Object If Possible
                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
    }

    public void LookForMenuKey_Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteractTap();
                currentTarget.OnInteractHold();
            }
        }
        else if (Input.GetKey(KeyCode.F))
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteractHold();
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteractEndHold();
            }
        }
    }

    /////////////////////////////////////////////////////////////////

    public void InteractionText_Set(string interactionText)
    {
        playerInteraction_Text.text = interactionText;
    }

    public void InteractionText_Remove()
    {
        playerInteraction_Text.text = "";
    }

    /////////////////////////////////////////////////////////////////

    public void InteractionHoldIcon_UpdateValue()
    {

    }

    public void InteractionHoldIcon_Set()
    {

    }

    public void InteractionHoldIcon_Remove()
    {

    }

    /////////////////////////////////////////////////////////////////
}

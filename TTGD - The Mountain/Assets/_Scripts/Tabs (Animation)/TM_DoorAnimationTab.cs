using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_DoorAnimationTab : MonoBehaviour
{

    public Animator doorAnimator;


    //Get Directions

    public bool isLocked;

    public bool isDoorOpen;

    ///////////////////////////////////////////////////////

    public void ActivateDoor()
    {
        if (isDoorOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor_Forward();
        }
    }

    private void CloseDoor()
    {
        //SFX Audio
        TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.interactionDoor1_SFX);

        isDoorOpen = false;
        doorAnimator.SetBool("IsDoorOpen", isDoorOpen);

    }

    private void OpenDoor_Forward()
    {
        //SFX Audio
        TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.interactionDoor2_SFX);

        isDoorOpen = true;
        doorAnimator.SetBool("IsDoorOpen", isDoorOpen);

    }

    ///////////////////////////////////////////////////////

    public void AnimationEvent_SetDoorCollider()
    {
        gameObject.layer = 0;
        //doorCollider.enabled = true;
    }

    public void AnimationEvent_RemoveDoorCollider()
    {
        gameObject.layer = 13;
        //doorCollider.enabled = false;
    }

    ///////////////////////////////////////////////////////
}

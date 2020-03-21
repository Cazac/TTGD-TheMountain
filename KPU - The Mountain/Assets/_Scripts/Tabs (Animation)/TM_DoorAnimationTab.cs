using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_DoorAnimationTab : MonoBehaviour
{

    public Animator doorAnimator;

    //Get Directions

    public bool isLocked;

    public bool isDoorOpen;


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
        isDoorOpen = false;
        doorAnimator.SetBool("IsDoorOpen", isDoorOpen);

    }

    private void OpenDoor_Forward()
    {
        isDoorOpen = true;
        doorAnimator.SetBool("IsDoorOpen", isDoorOpen);

    }

    private void OpenDoor_Backwards()
    {

    }




}

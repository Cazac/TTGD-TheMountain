using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_RoomRangeActivator : MonoBehaviour
{
    ////////////////////////////////

    [Header("Room Container")]
    public GameObject activeRoom_GO;

    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            Deactivate();
        }
    }

    ///////////////////////////////////////////////////////

    public void RefreshFromRange()
    {
        float distance = Vector3.Distance(TM_PlayerController_Movement.Instance.gameObject.transform.position, transform.position);

        if (distance >= 50)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    ///////////////////////////////////////////////////////

    private void Activate()
    {
        activeRoom_GO.SetActive(true);
    }

    private void Deactivate()
    {
        activeRoom_GO.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

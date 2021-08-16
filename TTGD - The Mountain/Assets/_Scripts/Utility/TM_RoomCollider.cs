using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_RoomCollider is tje collider used to connect rooms without overlap.
/// 
/// </summary>
///////////////

public class TM_RoomCollider : MonoBehaviour
{
    ////////////////////////////////

    public bool hasCollided = false;

    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //print("Test Code: I HAVE COLLIDERED - " + gameObject.name + " - " + collider.gameObject.name);

        hasCollided = true;
    }

    ///////////////////////////////////////////////////////
}

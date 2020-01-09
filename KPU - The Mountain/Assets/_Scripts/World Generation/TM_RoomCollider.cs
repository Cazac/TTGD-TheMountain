using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_RoomCollider : MonoBehaviour
{

    public bool hasCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        hasCollided = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_CanvasLookAtPlayer : MonoBehaviour
{


    Vector3 additionalRotation = new Vector3(0,180,0);

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TM_PlayerController_Movement.Instance.gameObject.transform);
        transform.Rotate(additionalRotation);
    }
}

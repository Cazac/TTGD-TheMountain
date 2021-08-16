using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TM_GroundboxDeathTrapRangeCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<TM_PlayerController_Combat>() != null)
        {
            TM_PlayerController_Stats.Instance.ChangeHealth_Current(-99999, "MapBounds");
        }
    }
}

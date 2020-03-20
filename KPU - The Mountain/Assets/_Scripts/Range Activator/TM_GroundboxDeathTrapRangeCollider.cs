using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TM_GroundboxDeathTrapRangeCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {

        TM_PlayerController_Stats.Instance.ChangeHealth_Current(-99999, "MapBounds");

    }


}

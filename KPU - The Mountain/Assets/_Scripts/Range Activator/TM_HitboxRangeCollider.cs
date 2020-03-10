using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_HitboxRangeCollider : MonoBehaviour
{



    void OnTriggerEnter(Collider collider)
    {



        //Check For Player
        if (collider.gameObject.GetComponent<TM_EnemyBossMinotaur>() != null)
        {
            print("Test Code: Damage!");
            Destroy(gameObject);
        }
    }

}

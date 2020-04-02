using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerHitboxRangeCollider : MonoBehaviour
{



    void OnTriggerEnter(Collider collider)
    {



        //Check For Player
        if (collider.gameObject.GetComponent<TM_EnemyStats>() != null)
        {


            collider.gameObject.GetComponent<TM_EnemyStats>().ChangeHealth_Current(-40);



            //print("Test Code: Damaged!");
            Destroy(gameObject);
        }
    }

}

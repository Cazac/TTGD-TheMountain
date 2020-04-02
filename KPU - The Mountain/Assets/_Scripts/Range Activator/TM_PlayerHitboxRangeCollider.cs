using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerHitboxRangeCollider : MonoBehaviour
{



    private void OnTriggerEnter(Collider collider)
    {


        print("Test Code: BLANK");
        //Check For Player
        if (collider.gameObject.GetComponent<TM_EnemyStats>() != null)
        {

            print("Test Code: Get Damage Value");

            collider.gameObject.GetComponent<TM_EnemyStats>().ChangeHealth_Current(-40);



            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;

            collider.gameObject.GetComponent<TM_EnemyDirector_Minotaur>().Knockback(direction);

            //print("Test Code: Damaged!");
            Destroy(gameObject);
        }
    }

}

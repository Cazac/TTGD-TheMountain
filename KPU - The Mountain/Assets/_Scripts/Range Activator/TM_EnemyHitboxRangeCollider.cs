using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyHitboxRangeCollider : MonoBehaviour
{

    public int colliderDamage;
    public string damageType;



    private void OnTriggerEnter(Collider collider)
    {
        //print("Test Code: Collider?");

        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Combat>() != null)
        {


            collider.gameObject.GetComponent<TM_PlayerController_Stats>().ChangeHealth_Current(-5);
            TM_PlayerController_Combat.Instance.AddToHurtScreen(5);



            print("Test Code: Dealing Damage!");
            Destroy(gameObject);
        }
    }
}

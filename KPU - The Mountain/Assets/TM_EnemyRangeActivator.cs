using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TM_EnemyRangeActivator : MonoBehaviour
{
    [Header("Nav Mesh Agent")]
    public GameObject enemy_GO;

    [Header("Nav Mesh Agent")]
    public TM_EnemyBossMinotaur enemyManager;


    void OnTriggerEnter(Collider collider)
    {



        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            Activate();
        }
    }


    void OnTriggerExit(Collider collider)
    {



        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            Deactivate();
        }
    }


    public void Deactivate()
    {
        print("Test Code: DEACTIVATED");

        enemyManager.enemy_Animator.SetBool("IsDisabled", true);
        enemyManager.enemy_Animator.Play("Disabled", 0);
        enemy_GO.GetComponent<TM_EnemyBossMinotaur>().enabled = false;
        enemy_GO.GetComponent<NavMeshAgent>().enabled = false;

    }

    public void Activate()
    {
        print("Test Code: ACTIVATE");


        enemy_GO.GetComponent<TM_EnemyBossMinotaur>().enabled = true;
        enemy_GO.GetComponent<NavMeshAgent>().enabled = true;

        enemyManager.EnemyState_Activated();



    }
}

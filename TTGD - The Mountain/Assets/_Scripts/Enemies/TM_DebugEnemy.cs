using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TM_DebugEnemy : MonoBehaviour
{


    string currentState;
    
    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    //CharacterCombat combat;

    // Use this for initialization
    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        //combat = GetComponent<CharacterCombat>();
        //agent.Warp(gameObject.transform.position + (transform.forward * 2));


        //agent.enabled = true;
    }

    int counter = 0;


    private void FixedUpdate()
    {
        
        if (counter > 200)
        {
            agent.SetDestination(gameObject.transform.position + (-transform.right * 5));

            counter = 0;
        }
        else
        {
            counter++;
        }
    }

    private void Update()
    {




        return;



        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        //if (distance <= lookRadius)
        {
            // Move towards the target
            agent.SetDestination(target.position);

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                //CharacterStats targetStats = target.GetComponent<CharacterStats>();
                //i//f (targetStats != null)
                {
                    //combat.Attack(targetStats);
                }

                //FaceTarget();   // Make sure to face towards the target
            }
        }
    }



 







}

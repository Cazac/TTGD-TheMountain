using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TM_EnemyBossMinotaur : MonoBehaviour
{
    ////////////////////////////////

    private float visualRangeRaduis = 20f;

    private readonly float wandering_NextNodeDistance = 10f;

    ////////////////////////////////


    private string currentState;


    [Header("Animator")]
    public Animator enemy_Animator;

    [Header("Charecter Controller")]
    public CharacterController enemy_CC;







    ////////////////////////////////
    public float wanderRadius;
    public float wanderTimer;

    //private Transform target;
    private NavMeshAgent agent;
    private float timer;
    ////////////////////////////////






    ////////////////////////////////

    private Vector3 currentTargetLocation;
    private Transform currentChaseTarget;

    Transform target;   // Reference to the player
    private NavMeshAgent enemyNavAgent;

    //CharacterCombat combat;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Get Nav Mesh Agaent
        enemyNavAgent = gameObject.GetComponent<NavMeshAgent>();


        currentState = "Chasing";



        //target = PlayerManager.instance.player.transform;

        //combat = GetComponent<CharacterCombat>();
        //agent.Warp(gameObject.transform.position + (transform.forward * 2));


        //agent.enabled = true;
    }

    private void Update()
    {
        //Get Current State and Prefrom Action
        EnemyState_GetState();






    }

    ///////////////////////////////////////////////////////

    private void EnemyState_GetState()
    {

        switch (currentState)
        {
            case "Deactivated":
                return;
                break;

            case "Idling":
                EnemyState_Idling();
                break;

            case "Wandering":
                EnemyState_Wandering();
                break;

            case "Patroling":
                //EnemyState_Patroling();
                break;

            case "Chasing":
                EnemyState_Chasing();
                break;
                
            case "Attacking":


                break;

            default:
                print("Test Code: OOPS");
                break;
        }
    }

    ///////////////////////////////////////////////////////

    private void EnemyState_Idling()
    {
        //Set Animation Values
        enemy_Animator.SetFloat("Speed", 0f);

        //Check For State Change
        if (Random.Range(0, 100) == 0)
        {
            //Change To Idle
            currentState = "Wandering";


            return;
        }

    }

    private void EnemyState_Wandering()
    {
        //!enemy_CC.isGrounded

        //Set Animation Values
        enemy_Animator.SetBool("OnGround", true);
        enemy_Animator.SetFloat("Speed", enemyNavAgent.velocity.magnitude * 0.8f);
        enemy_Animator.SetFloat("MovementID", 0f);
        //enemy_Animator.SetFloat("RunWalkID", 2f);
        enemy_Animator.SetFloat("AttackID", 0f);



        //enemy_Animator.SetFloat("Speed", 0f);



        //Get Distance Between Goal
        float distance = Vector3.Distance(gameObject.transform.position, currentTargetLocation);

        //Check if distance is close enough to get a new one
        if (distance <= 1f)
        {
            //Reset Target
            currentTargetLocation = Vector3.zero;

            //Check For State Change
            if (Random.Range(0, 5) == 0)
            {
                //Change To Idle
                currentState = "Idling";

                //Remove Desintation
                enemyNavAgent.ResetPath();

                return;
            }
        }



        if (currentTargetLocation == Vector3.zero)
        {
            //Get New Target Destination
            if (WanderingDestination(transform.position, wandering_NextNodeDistance, out Vector3 newTargetLocation))
            {
                //Set New Target and Set Destination
                currentTargetLocation = newTargetLocation;
                enemyNavAgent.SetDestination(currentTargetLocation);

                //Debug Gizmo
                Debug.DrawRay(currentTargetLocation, Vector3.up, Color.blue, 2f);
            }
            else
            {

                //Change To Idle


                print("Test Code: No Hit");
            }
        }
    }

    private void EnemyState_Chasing()
    {
        //Set Animation Values
        enemy_Animator.SetBool("OnGround", true);
        enemy_Animator.SetFloat("Speed", enemyNavAgent.velocity.magnitude * 0.8f);
        enemy_Animator.SetFloat("MovementID", 0f);
        //enemy_Animator.SetFloat("RunWalkID", 2f);
        enemy_Animator.SetFloat("AttackID", 1f);





        currentChaseTarget = TM_PlayerController_Combat.Instance.transform;



        if (currentChaseTarget == null)
        {
            EnemyState_Wandering();
            currentState = "Wandering";
            return;
        }



        // Move towards the target
        enemyNavAgent.SetDestination(currentChaseTarget.position);




        //Get Distance Between Goal
        float distance = Vector3.Distance(gameObject.transform.position, currentChaseTarget.position);

        //Check if distance is close enough to get a new one
        if (distance <= 6f)
        {

            //print("Test Code: Attack!");

            enemy_Animator.SetBool("Attack1", true);
            

        }
        else
        {
            //print("Test Code: Chase!");

            enemy_Animator.SetBool("Attack1", false);
        }

        /*

            // If inside the lookRadius
            if (distance <= lookRadius)
        {
         

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                FaceTarget();   // Make sure to face towards the target
            }
        }

        */

    }

    private void EnemyState_Attacking()
    {


        // Distance to the target
        float distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= visualRangeRaduis)
        {
            // Move towards the target
            enemyNavAgent.SetDestination(target.position);

            // If within attacking distance
            if (distance <= enemyNavAgent.stoppingDistance)
            {
                //CharacterStats targetStats = target.GetComponent<CharacterStats>();
                //i//f (targetStats != null)
                {
                    //combat.Attack(targetStats);
                }

                FaceTarget();   // Make sure to face towards the target
            }
        }

    }

    ///////////////////////////////////////////////////////

    private bool WanderingDestination(Vector3 originPosition, float distanceFromEnemy, out Vector3 result)
    {
        //Nav Mesh Hit By Sampling Position
        NavMeshHit navMeshHit;

        //Get Direction Modifiers
        Vector3 forwardDirection = transform.forward * Random.Range(4f, 8f);
        Vector3 backwardsDirection = -transform.forward * Random.Range(4f, 8f);
        Vector3 turningDirection = transform.right * Random.Range(-12f, 12f);

        //Get Final Checking Vectors
        Vector3 randomPoint_Forward = originPosition + forwardDirection + turningDirection;
        Vector3 randomPoint_Backwards = originPosition + backwardsDirection + turningDirection;

        //Try To Sample Forwards Direction
        if (NavMesh.SamplePosition(randomPoint_Forward, out navMeshHit, 1f, NavMesh.AllAreas))
        {
            //Return True, Out Position
            result = navMeshHit.position;
            return true;
        }

        //Try To Sample Backwards Direction
        if (NavMesh.SamplePosition(randomPoint_Backwards, out navMeshHit, 1f, NavMesh.AllAreas))
        {
            //Return True, Out Position
            result = navMeshHit.position;
            return true;
        }

        //Attempt a valid location 10 times
        for (int i = 0; i < 10; i++)
        {
            //Get Random Points Around Center Of Unit
            Vector3 randomPoint = originPosition + (Random.insideUnitSphere * distanceFromEnemy);

            //Try To Sample Random Direction
            if (NavMesh.SamplePosition(randomPoint, out navMeshHit, 3f, NavMesh.AllAreas))
            {
                //Return True, Out Position
                result = navMeshHit.position;
                return true;
            }
        }

        //Return False, No Options Found
        result = Vector3.zero;
        return false;
    }


    




    // Use this for initialization
    void OnEnable()
    {
        timer = wanderTimer;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    */
   



    ///////////////////////////////////////////////////////

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    ///////////////////////////////////////////////////////

    private void OnDrawGizmosSelected()
    {
        // Show the lookRadius in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visualRangeRaduis);
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TM_EnemyDirector_Minotaur : MonoBehaviour
{
    ////////////////////////////////

    [Header("Animator")]
    public Animator enemy_Animator;

    [Header("Charecter Controller")]
    public CharacterController enemy_CC;

    [Header("Nav Mesh Agent")]
    public NavMeshAgent enemyNavAgent;

    [Header("Range Activator")]
    public TM_EnemyRangeActivator rangeActivator;

    [Header("Current State")]
    public EnemyState currentState;

    [Header("Current Stats")]
    public TM_EnemyStats currentStats;

    [Header("Hitbox")]
    public GameObject enemyHitboxContainter;

    ////////////////////////////////

    [Header("Travel Points")]
    private Vector3 currentTargetLocation;
    private Transform currentChaseTarget;

    ////////////////////////////////

    [Header("Ranges")]
    public float visualRangeRadius;
    public float attackingRangeRadius;
    public float wandering_NextNodeDistance;

    ////////////////////////////////


    //Loot?




    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Default State
        currentState = EnemyState.Deactivated;


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

    public enum EnemyState
    {
        Deactivated,
        Idling,
        Wandering,
        Patroling,
        Chasing,
        Attacking,
        Blocking,
        Dying
    }

    ///////////////////////////////////////////////////////

    private void EnemyState_GetState()
    {
        //print("Test Code: Minotaur State: " + currentState);

        //Check Current State
        switch (currentState)
        {
            case EnemyState.Deactivated:
                EnemyState_Deactivated();
                break;

            case EnemyState.Idling:
                EnemyState_Idling();
                break;

            case EnemyState.Wandering:
                EnemyState_Wandering();
                break;

            case EnemyState.Patroling:
                EnemyState_Patroling();
                break;

            case EnemyState.Chasing:
                EnemyState_Chasing();
                break;
                
            case EnemyState.Attacking:
                EnemyState_Attacking();
                break;

            case EnemyState.Blocking:
                EnemyState_Blocking();
                break;

            case EnemyState.Dying:
                EnemyState_Dying();
                break;
        }
    }

    ///////////////////////////////////////////////////////

    private void EnemyState_Deactivated()
    {
        //Turn On Activations Sript
        rangeActivator.Deactivate();
    }

    public void EnemyState_Activated()
    {
        //Set animation looking down
        enemy_Animator.SetBool("IsDisabled", false);

        //Set Default State
        ChangeToState_Wandering();
    }

    ///////////////////////////////////////////////////////

    private void EnemyState_Idling()
    {
        //Set Animation Values
        enemy_Animator.SetFloat("Speed", 0f);

        //Check For State Change
        if (Random.Range(0, 100) == 0)
        {
            //Change To Wandering
            ChangeToState_Wandering();

            return;
        }
    }

    private void EnemyState_Wandering()
    {
        //Set Animation Values
        enemy_Animator.SetBool("OnGround", !enemy_CC.isGrounded);
        enemy_Animator.SetFloat("Speed", enemyNavAgent.velocity.magnitude * 0.8f);
        enemy_Animator.SetFloat("MovementID", 0f);
        //enemy_Animator.SetFloat("RunWalkID", 2f);
        enemy_Animator.SetFloat("AttackID", 0f);

        //Get Distance Between Enemy and Player
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, TM_PlayerController_Combat.Instance.transform.position);

        //Check if distance is Far Enough to break Chase
        if (distanceToPlayer < visualRangeRadius)
        {
            ChangeToState_Chasing();
            return;
        }


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
                ChangeToState_Idling();
                return;
            }
        }

        if (currentTargetLocation == Vector3.zero)
        {
            //Get New Target Destination
            if (FindWanderDestination(transform.position, wandering_NextNodeDistance, out Vector3 newTargetLocation))
            {
                //Set New Target and Set Destination
                currentTargetLocation = newTargetLocation;
                enemyNavAgent.SetDestination(currentTargetLocation);

                //Debug Gizmo
                Debug.DrawRay(currentTargetLocation, Vector3.up, Color.blue, 2f);
            }
            else
            {
                //No Spawning Point Hit, Set To Idle For Now
                ChangeToState_Idling();

                print("Test Code: No Raycast Hit");
            }
        }
    }

    private void EnemyState_Patroling()
    {


    }

    private void EnemyState_Chasing()
    {
        //Set Animation Values
        enemy_Animator.SetBool("OnGround", !enemy_CC.isGrounded);
        enemy_Animator.SetFloat("Speed", enemyNavAgent.velocity.magnitude * 0.8f);
        enemy_Animator.SetFloat("MovementID", 0f);
        //enemy_Animator.SetFloat("RunWalkID", 2f);
        enemy_Animator.SetFloat("AttackID", 1f);

        //Get Target
        currentChaseTarget = TM_PlayerController_Combat.Instance.transform;

        //Check For Valid Target
        if (currentChaseTarget == null)
        {
            ChangeToState_Idling();
            return;
        }

        //Get Distance Between Enemy and Player
        float distance = Vector3.Distance(gameObject.transform.position, currentChaseTarget.position);

        //Check if distance is Far Enough to break Chase
        if (distance > visualRangeRadius)
        {
            ChangeToState_Wandering();
            return;
        }

        // Move towards the target
        enemyNavAgent.SetDestination(currentChaseTarget.position);






        //Check if distance is close enough Attack
        if (distance <= attackingRangeRadius)
        {

            //print("Test Code: Attack!");

            ChangeToState_AttackQuick();
            

        }
    }

    private void EnemyState_Attacking()
    {
        enemyNavAgent.ResetPath();

        enemy_Animator.SetBool("Attack1", true);

        //Get Distance Between Enemy and Player
        float distance = Vector3.Distance(gameObject.transform.position, currentChaseTarget.position);

        //Check if distance is close enough Attack
        if (distance > attackingRangeRadius)
        {
            //Return To Chase State
            //ChangeToState_Chasing();
            return;
        }


        FaceTarget();



    }

    private void EnemyState_Blocking()
    {



    }

    private void EnemyState_Dying()
    {

    }

    ///////////////////////////////////////////////////////

    private void ChangeToState_Idling()
    {

        enemy_Animator.SetBool("Attack1", false);


        //Change To Idle
        EnemyState_Idling();
        currentState = EnemyState.Idling;
        enemyNavAgent.ResetPath();
    }

    private void ChangeToState_Wandering()
    {

        enemy_Animator.SetBool("Attack1", false);

        //Change To Wandering
        currentState = EnemyState.Wandering;
        enemyNavAgent.SetDestination(currentTargetLocation);
    }

    public void ChangeToState_Chasing()
    {

        enemy_Animator.SetBool("Attack1", false);

        //Change To Chase
        EnemyState_Chasing();
        currentState = EnemyState.Chasing;
    }

    private void ChangeToState_AttackQuick()
    {
        enemy_Animator.SetFloat("AttackSpeed1", 1f);

        //Change To Chase
        EnemyState_Attacking();
        currentState = EnemyState.Attacking;
    }

    public void ChangeToState_Dying()
    {
        enemy_Animator.Play("Death");



        //Change To Death
        EnemyState_Dying();
        currentState = EnemyState.Dying;
        enemyNavAgent.ResetPath();
    }

    ///////////////////////////////////////////////////////



    public void SpawnAttackHitbox(GameObject hitboxPrefab)
    {
        GameObject hitbox_GO = Instantiate(hitboxPrefab, enemyHitboxContainter.transform);


        //Set Auto Destruct

        StartCoroutine(AutoDestoryCountdown(0.2f, hitbox_GO));

    }

    private IEnumerator AutoDestoryCountdown(float clipLength, GameObject hitBox)
    {
        //Wait Till Clip is over + buffer room
        yield return new WaitForSeconds(clipLength + 0.1f);

        //Destory Clip
        Destroy(hitBox);

        //Break Out
        yield break;
    }




    ///////////////////////////////////////////////////////

    private bool FindWanderDestination(Vector3 originPosition, float distanceFromEnemy, out Vector3 result)
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


    






    ///////////////////////////////////////////////////////

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (currentChaseTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    ///////////////////////////////////////////////////////

    private void OnDrawGizmosSelected()
    {
        // Show the lookRadius in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visualRangeRadius);
    }

    ///////////////////////////////////////////////////////
}



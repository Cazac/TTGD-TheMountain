using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TM_EnemyDirector_Minotaur : MonoBehaviour
{
    ////////////////////////////////

    [Header("Animator")]
    public Animator enemy_Animator;

    [Header("Nav Mesh Agent")]
    public NavMeshAgent enemy_NavAgent;

    [Header("Rigidbody")]
    public Rigidbody enemy_Rigidbody;

    [Header("Range Activator")]
    public TM_EnemyRangeActivator enemy_RangeActivator;

    [Header("Current State")]
    public EnemyState enemy_CurrentState;

    [Header("Current Stats")]
    public TM_EnemyStats enemy_CurrentStats;

    [Header("Hitbox")]
    public GameObject enemy_HitboxContainter;

    [Header("Loots!")]
    public TM_MonsterLootTable_SO enemy_LootTable;

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

    [Header("Monster State Renderers")]
    public MeshRenderer monsterParts_Head_MeshRend;
    public MeshRenderer monsterParts_Body_MeshRend;
    public MeshRenderer monsterParts_LegRight_MeshRend;
    public MeshRenderer monsterParts_LegLeft_MeshRend;
    public MeshRenderer monsterParts_FootRight_MeshRend;
    public MeshRenderer monsterParts_FootLeft_MeshRend;
    public MeshRenderer monsterParts_ArmRight_MeshRend;
    public MeshRenderer monsterParts_ArmLeft_MeshRend;
    public MeshRenderer monsterParts_HandRight_MeshRend;
    public MeshRenderer monsterParts_HandLeft_MeshRend;

    [Header("Monster State Mats")]
    public Material monsterPartsHurt_Head_Mat;
    public Material monsterPartsPlain_Head_Mat;
    public Material monsterPartsHurt_Body_Mat;
    public Material monsterPartsPlain_Body_Mat;
    public Material monsterPartsHurt_Leg_Mat;
    public Material monsterPartsPlain_Leg_Mat;
    public Material monsterPartsHurt_Foot_Mat;
    public Material monsterPartsPlain_Foot_Mat;
    public Material monsterPartsHurt_Arm_Mat;
    public Material monsterPartsPlain_Arm_Mat;
    public Material monsterPartsHurt_Hand_Mat;
    public Material monsterPartsPlain_Hand_Mat;

    ////////////////////////////////

    [Header("Popup Damage TEST")]
    public GameObject popupDamageText;
    public GameObject enemy_Canvas;


    public int STARTING_HEALTH = 200;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Default State
        enemy_CurrentState = EnemyState.Deactivated;
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
        switch (enemy_CurrentState)
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
        enemy_RangeActivator.Deactivate();
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
        enemy_Animator.SetBool("OnGround", true);
        enemy_Animator.SetFloat("Speed", enemy_NavAgent.velocity.magnitude * 0.8f);
        enemy_Animator.SetFloat("MovementID", 0f);
        //enemy_Animator.SetFloat("RunWalkID", 2f);
        enemy_Animator.SetFloat("AttackID", 0f);

        //Get Distance Between Enemy and Player
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, TM_PlayerController_Combat.Instance.transform.position);

        //Get Target
        currentChaseTarget = TM_PlayerController_Combat.Instance.transform;

        //Check if distance is Far Enough to break Chase
        if (distanceToPlayer < visualRangeRadius)
        {
            //Nav Mesh Hit By Sampling Position
            NavMeshHit navMeshHit;

            //Try To Sample Forwards Direction
            if (NavMesh.SamplePosition(currentChaseTarget.position, out navMeshHit, 1f, NavMesh.AllAreas))
            {
                //Check If Path To Location Is Valid
                NavMeshPath path = new NavMeshPath();
                bool possiblePath = enemy_NavAgent.CalculatePath(currentChaseTarget.position, path);

                if (path.status != NavMeshPathStatus.PathPartial)
                {
                    //Chase towards the target
                    ChangeToState_Chasing();
                    return;
                }
            }
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
                enemy_NavAgent.SetDestination(currentTargetLocation);

                //Debug Gizmo
                Debug.DrawRay(currentTargetLocation, Vector3.up, Color.blue, 2f);
            }
            else
            {
                //No Spawning Point Hit, Set To Idle For Now
                ChangeToState_Idling();
            }
        }
    }

    private void EnemyState_Patroling()
    {


    }

    private void EnemyState_Chasing()
    {
        //Set Animation Values
        enemy_Animator.SetBool("OnGround", true);
        enemy_Animator.SetFloat("Speed", enemy_NavAgent.velocity.magnitude * 0.8f);
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

        //Check if distance is close enough Attack
        if (distance <= attackingRangeRadius)
        {
            //Ignore All and Attack
            ChangeToState_AttackQuick();
            return;
        }

        //Nav Mesh Hit By Sampling Position
        NavMeshHit navMeshHit;

        //Try To Sample Forwards Direction
        if (NavMesh.SamplePosition(currentChaseTarget.position, out navMeshHit, 1f, NavMesh.AllAreas))
        {
            //Check If Path To Location Is Valid
            NavMeshPath path = new NavMeshPath();
            bool possiblePath = enemy_NavAgent.CalculatePath(currentChaseTarget.position, path);

            if (path.status != NavMeshPathStatus.PathPartial)
            {
                //Chase towards the target
                enemy_NavAgent.SetDestination(currentChaseTarget.position);
                return;
            }
            else
            {
                //Can't Reach Idle It
                ChangeToState_Idling();
                return;
            }
        }
    }

    private void EnemyState_Attacking()
    {
        enemy_NavAgent.ResetPath();

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
        enemy_CurrentState = EnemyState.Idling;
        enemy_NavAgent.ResetPath();
    }

    private void ChangeToState_Wandering()
    {

        enemy_Animator.SetBool("Attack1", false);

        //Change To Wandering
        enemy_CurrentState = EnemyState.Wandering;
        enemy_NavAgent.SetDestination(currentTargetLocation);
    }

    public void ChangeToState_Chasing()
    {

        enemy_Animator.SetBool("Attack1", false);

        //Change To Chase
        EnemyState_Chasing();
        enemy_CurrentState = EnemyState.Chasing;
    }

    private void ChangeToState_AttackQuick()
    {
        enemy_Animator.SetFloat("AttackSpeed1", 1f);

        //Change To Chase
        EnemyState_Attacking();
        enemy_CurrentState = EnemyState.Attacking;
    }

    public void ChangeToState_Dying()
    {
        //Play SFX
        TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.minotaurDeath_SFX);

        enemy_Animator.Play("Death");



        //Change To Death
        EnemyState_Dying();
        enemy_CurrentState = EnemyState.Dying;
        enemy_NavAgent.ResetPath();
    }

    ///////////////////////////////////////////////////////

    public void DamagePopup(int damage)
    {
        //Create New Popup
        GameObject popupText = Instantiate(popupDamageText, enemy_Canvas.transform);

        //Set Starting Position
        popupText.GetComponent<RectTransform>().localPosition = new Vector3(0, 0.5f, -1.8f);

        //Setup Values
        popupText.GetComponent<TM_DamagePopup>().Setup(damage);
    }

    public void Knockback(Vector3 direction, float power)
    {
        //Impluse the enemy with knockback
        enemy_Rigidbody.AddForce(direction.normalized * power, ForceMode.Impulse);
    }

    public IEnumerator DamagedVisualFlash()
    {
        //Red Color
        monsterParts_Head_MeshRend.material = monsterPartsHurt_Head_Mat;
        monsterParts_Body_MeshRend.material = monsterPartsHurt_Body_Mat;

        monsterParts_LegRight_MeshRend.material = monsterPartsHurt_Leg_Mat;
        monsterParts_LegLeft_MeshRend.material = monsterPartsHurt_Leg_Mat;

        monsterParts_FootRight_MeshRend.material = monsterPartsHurt_Foot_Mat;
        monsterParts_FootLeft_MeshRend.material = monsterPartsHurt_Foot_Mat;

        monsterParts_ArmRight_MeshRend.material = monsterPartsHurt_Arm_Mat;
        monsterParts_ArmLeft_MeshRend.material = monsterPartsHurt_Arm_Mat;

        monsterParts_HandRight_MeshRend.material = monsterPartsHurt_Hand_Mat;
        monsterParts_HandLeft_MeshRend.material = monsterPartsHurt_Hand_Mat;

        //Wait For 0.15 Seconds
        yield return new WaitForSeconds(0.3f);

        //Plain Color
        monsterParts_Head_MeshRend.material = monsterPartsPlain_Head_Mat;
        monsterParts_Body_MeshRend.material = monsterPartsPlain_Body_Mat;

        monsterParts_LegRight_MeshRend.material = monsterPartsPlain_Leg_Mat;
        monsterParts_LegLeft_MeshRend.material = monsterPartsPlain_Leg_Mat;

        monsterParts_FootRight_MeshRend.material = monsterPartsPlain_Foot_Mat;
        monsterParts_FootLeft_MeshRend.material = monsterPartsPlain_Foot_Mat;

        monsterParts_ArmRight_MeshRend.material = monsterPartsPlain_Arm_Mat;
        monsterParts_ArmLeft_MeshRend.material = monsterPartsPlain_Arm_Mat;

        monsterParts_HandRight_MeshRend.material = monsterPartsPlain_Hand_Mat;
        monsterParts_HandLeft_MeshRend.material = monsterPartsPlain_Hand_Mat;

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////

    public void SpawnLoot()
    {

        List<TM_Item_SO> itemSO_List = enemy_LootTable.GetLootDrops();


        int raduisChange = 360 / itemSO_List.Count;
    

        //Loop Foreach Drop Count
        for (int i = 0; i < itemSO_List.Count; i++)
        {
            //Get Angle
            float currentAngle = raduisChange * i;

            //Get ItemSO
            TM_Item_SO itemSO = itemSO_List[i];


            //Create a position infront of the player
            Vector3 spawnPosition = gameObject.transform.position;
            spawnPosition += TM_PlayerController_Movement.Instance.gameObject.transform.forward * -3;






            spawnPosition.y += 1;

            //Spawn Item as Dropped
            GameObject newObject = Instantiate(itemSO.dropped_Prefab, spawnPosition, Quaternion.identity);

            //Set Stacksize and Durablity 
            newObject.GetComponent<TM_ItemDropped>().currentStackSize = 1;
        }
    }

    public void SpawnAttackHitbox(GameObject hitboxPrefab)
    {
        GameObject hitbox_GO = Instantiate(hitboxPrefab, enemy_HitboxContainter.transform);


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
            //Check If Path To Location Is Valid
            NavMeshPath path = new NavMeshPath();
            bool possiblePath = enemy_NavAgent.CalculatePath(navMeshHit.position, path);

            if (path.status != NavMeshPathStatus.PathPartial)
            {
                //Return True, Out Position
                result = navMeshHit.position;
                return true;
            }
        }


        //Try To Sample Backwards Direction
        if (NavMesh.SamplePosition(randomPoint_Backwards, out navMeshHit, 1f, NavMesh.AllAreas))
        {
            //Check If Path To Location Is Valid
            NavMeshPath path = new NavMeshPath();
            bool possiblePath = enemy_NavAgent.CalculatePath(navMeshHit.position, path);

            if (path.status != NavMeshPathStatus.PathPartial)
            {
                //Return True, Out Position
                result = navMeshHit.position;
                return true;
            }
        }

        //Attempt a valid location 10 times
        for (int i = 0; i < 10; i++)
        {
            //Get Random Points Around Center Of Unit
            Vector3 randomPoint = originPosition + (Random.insideUnitSphere * distanceFromEnemy);

            //Try To Sample Random Direction
            if (NavMesh.SamplePosition(randomPoint, out navMeshHit, 3f, NavMesh.AllAreas))
            {
                //Check If Path To Location Is Valid
                NavMeshPath path = new NavMeshPath();
                bool possiblePath = enemy_NavAgent.CalculatePath(navMeshHit.position, path);

                if (path.status != NavMeshPathStatus.PathPartial)
                {
                    //Return True, Out Position
                    result = navMeshHit.position;
                    return true;
                }
            }
        }

        //Return False, No Options Found
        result = Vector3.zero;
        return false;
    }

    private void FaceTarget()
    {
        // Rotate to face the target
        Vector3 direction = (currentChaseTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    ///////////////////////////////////////////////////////







    ///////////////////////////////////////////////////////

    private void OnDrawGizmosSelected()
    {
        // Show the look Radius in editor for visual distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visualRangeRadius);
    }

    ///////////////////////////////////////////////////////
}



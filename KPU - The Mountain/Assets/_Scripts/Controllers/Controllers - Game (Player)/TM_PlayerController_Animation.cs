using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerController_Animation : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Animation Instance;

    ////////////////////////////////

    public GameObject playerHead_GO;
    public GameObject firstPersonCamera_GO;
    public GameObject thirdPersonCamera_GO;


    ////////////////////////////////

    private Animator playerAnimator;

    /*
    float TypeID_Running;
    float TypeID_Walking;
    float TypeID_Idling;
    float PlayerSpeed;
    bool IsGrounded;
    bool IsDashing;
    bool IsAttacking_MeleeQuick;
    bool IsAttacking_MeleeStrong;
    bool IsAttacking_MagicQuick;
    */




    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Get Animator
        playerAnimator = gameObject.GetComponent<Animator>();
    }
   
    private void Update()
    {
        LookForAnimationKeys_ViewType();
        LookForAnimationKeys_DebugChanges();
    }

    ///////////////////////////////////////////////////////

    public void SetAnimationValue_QuickAttack()
    {
        playerAnimator.Play("Attack Melee Quick", 0);
    }

    public void SetAnimationValue_PlayerSpeed(float value)
    {
        playerAnimator.SetFloat("PlayerSpeed", value);



    }

    public void SetAnimationValue_IsGrounded(bool value)
    {

        playerAnimator.SetBool("IsGrounded", value);
    }

    ///////////////////////////////////////////////////////



    ///////////////////////////////////////////////////////

    private void LookForAnimationKeys_ViewType()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (firstPersonCamera_GO.activeSelf == true)
            {
                //Cameras
                firstPersonCamera_GO.SetActive(false);
                thirdPersonCamera_GO.SetActive(true);

                //Head
                playerHead_GO.SetActive(true);
            }
            else if (thirdPersonCamera_GO.activeSelf == true)
            {
                //Cameras
                firstPersonCamera_GO.SetActive(true);
                thirdPersonCamera_GO.SetActive(false);

                //Head
                playerHead_GO.SetActive(false);
            }
        }
    }

    private void LookForAnimationKeys_DebugChanges()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimator.SetFloat("TypeID_Walking", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerAnimator.SetFloat("TypeID_Walking", 2.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimator.SetFloat("TypeID_Walking", 3.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerAnimator.SetFloat("TypeID_Walking", 4.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
         
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(9);
        }
    }

    ///////////////////////////////////////////////////////
}

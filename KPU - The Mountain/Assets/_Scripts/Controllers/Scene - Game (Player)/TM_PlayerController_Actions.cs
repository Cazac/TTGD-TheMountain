using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerController_Actions : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Actions Instance;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimator.SetBool("OnGround", true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerAnimator.SetBool("OnGround", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimator.SetFloat("TypeID_Walking", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerAnimator.SetFloat("TypeID_Walking", 3.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerAnimator.SetFloat("TypeID_Walking", 2.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(9);
        }
    }


    ///////////////////////////////////////////////////////

    public void SetAnimationValue_PlayerSpeed(float value)
    {
        playerAnimator.SetFloat("PlayerSpeed", value);
    }




    ///////////////////////////////////////////////////////
}

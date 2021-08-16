using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerController_Movement takes input and moves the player.
/// 
/// </summary>
///////////////

public class TM_PlayerController_Movement : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Movement Instance;

    ////////////////////////////////
    
    [Header("Player Able To Move")]
    public bool canPlayerMove;

    ////////////////////////////////

    [Header("Player Speeds")]
    private float defaultSpeed = 10f;
    private float sprintSpeed = 14f;
    private float crouchSpeed = 3f;

    [Header("Current Player Force")]
    private float currentSpeed;
    private float verticalVelocity;
    private Vector3 moveDirection;

    [Header("Constant Forces")]
    private float jumpForce = 12f;
    private float gravityForce = 30f;

    [Header("Player States")]
    private bool isCrouching;

    [Header("Player's Charecter Controller")]
    private CharacterController player_CC;


    [Header("Footsteps")]
    float distancePerFootstep = 6;
    float currentFootstepDistance;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Allow Movement
        canPlayerMove = true;

        //Get Charecter Controller
        player_CC = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (canPlayerMove == false)
        {
            return;
        }

        //Set Speed Values
        PlayerCrouch();
        //PlayerSprint();

        //Get Player Movement Values
        PlayerMove_Regluar();
        PlayerMove_Vertical();

        //Move the player
        player_CC.Move(moveDirection);



        PlayerFootsteps();




        //Debug Dodge
        //DoubleTap_Left();
        //DoubleTap_Right();



        //Debug Shift Dodge
        PlayerDodge(moveDirection);


    }

    ///////////////////////////////////////////////////////

    private void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Set to crouch speed
            currentSpeed = crouchSpeed;

            //Toggle crouch bool
            isCrouching = true;
        }
        else
        {
            //Set to default speed
            currentSpeed = defaultSpeed;

            //Toggle crouch bool
            isCrouching = false;
        }
    }

    private void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isCrouching)
            {
                currentSpeed = sprintSpeed;
            }
            else
            {
                currentSpeed = default;
            }
        }
    }

    private float PlayerJump()
    {
        if (player_CC.isGrounded && Input.GetKey(KeyCode.Space))
        {
            return jumpForce;
        }
        else
        {
            return verticalVelocity;
        }
    }

    private float GetGravity()
    {
        //Return a downwards position
        return verticalVelocity -= gravityForce * Time.deltaTime;
    }

    ///////////////////////////////////////////////////////

    private void PlayerMove_Regluar()
    {
        // use Unity's built-in Input axis to create a move vector
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0f, -Input.GetAxis("Vertical"));

        // change moveDirection from local space to global space (current global pos + moveDirection)
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= currentSpeed * Time.deltaTime;

        //DEBUG
        float speed = player_CC.velocity.magnitude;
        TM_PlayerController_Animation.Instance.SetAnimationValue_PlayerSpeed(speed);
        TM_PlayerController_Animation.Instance.SetAnimationValue_IsGrounded(player_CC.isGrounded);
    }

    private void PlayerMove_Vertical()
    {
        //Set new Y velcoity from gravity + jump
        verticalVelocity = GetGravity();
        verticalVelocity = PlayerJump();

        //Set Y value to move direction
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    ///////////////////////////////////////////////////////

    private void PlayerFootsteps()
    {
        //Check If player is on the ground
        if (player_CC.isGrounded)
        {
            currentFootstepDistance += player_CC.velocity.magnitude * Time.deltaTime;
            //print("Test Code: " + player_CC.velocity.magnitude);
            //print("Test Code: " + currentFootstepDistance);

            //If 0 reset????\\

            if (currentFootstepDistance >= distancePerFootstep)
            {
                currentFootstepDistance -= distancePerFootstep;

                //Play SFX
                TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.playerFootsteps_List);
            }

        }


    }


    ///////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////


    /// <summary>
    /// 
    /// Code found for double tap dodge
    /// 
    /// </summary>

    private bool onePress_Left;
    private float delay_Left;
    private bool twoPress_Left;
    private float twoPressTimer_Left;

    private bool onePress_Right;
    private float delay_Right;
    private bool twoPress_Right;
    private float twoPressTimer_Right;


    bool twoPress_Shift = false;
    float twoPressTimer_Shift = 0;
    Vector3 boostDirection;




    private void DoubleTap_Left()
    {
        //Check For Key
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!onePress_Left)
            {
                onePress_Left = true;
                delay_Left = Time.time + 0.2f;
            }
            else
            {
                onePress_Left = false;
                twoPressTimer_Left = 0.3f;
                twoPress_Left = true;
            }
        }

        if (onePress_Left)
        {
            if ((Time.time - .05) > delay_Left)
            {
                onePress_Left = false;
            }
        }
        if (twoPress_Left)
        {
            twoPressTimer_Left = twoPressTimer_Left - Time.deltaTime;
            transform.Translate(Vector3.right * 20 * Time.deltaTime);
            if (twoPressTimer_Left <= 0)
            {
                twoPress_Left = false;
            }

        }
    }

    private void DoubleTap_Right()
    {
        //Check For Key
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!onePress_Right)
            {
                onePress_Right = true;
                delay_Right = Time.time + 0.2f;
            }
            else
            {
                onePress_Right = false;
                twoPressTimer_Right = 0.3f;
                twoPress_Right = true;
            }
        }

        if (onePress_Right)
        {
            if ((Time.time - .05) > delay_Right)
            {
                onePress_Right = false;
            }
        }
        if (twoPress_Right)
        {
            twoPressTimer_Right = twoPressTimer_Right - Time.deltaTime;
            transform.Translate(Vector3.left * 20 * Time.deltaTime);
            if (twoPressTimer_Right <= 0)
            {
                twoPress_Right = false;
            }
        }
    }

    private void PlayerDodge(Vector3 moveDirection)
    {


        //Facing X



        //Check For Key
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            twoPress_Shift = true;
            twoPressTimer_Shift = 0.1f;


            boostDirection = new Vector3(player_CC.velocity.x, 0f, player_CC.velocity.z) * 6f;
        }

        //Keep Moving
        if (twoPress_Shift)
        {


       
            //Scale Direction To Time
            Vector3 scaledDirection = boostDirection * Time.deltaTime;

            //Move GameObject
            transform.Translate(scaledDirection, Space.World);






            //Subtract Time
            twoPressTimer_Shift -= Time.deltaTime;

            //Check If Done
            if (twoPressTimer_Shift <= 0)
            {
                twoPress_Shift = false;
            }
        }
    }

    ///////////////////////////////////////////////////////
}

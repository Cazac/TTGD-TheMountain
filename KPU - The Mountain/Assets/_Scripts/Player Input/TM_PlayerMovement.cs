using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerMovement moves the player.
/// 
/// </summary>
///////////////

public class TM_PlayerMovement : MonoBehaviour
{
    ////////////////////////////////

    [Header("Player Speeds")]
    private float defaultSpeed = 5f;
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

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Get Charecter Controller
        player_CC = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Set Speed Values
        PlayerCrouch();
        PlayerSprint();

        //Get Player Movement Values
        PlayerMove_Regluar();
        PlayerMove_Vertical();

        //Move the player
        player_CC.Move(moveDirection);



        //Debug 
        DoubleTap();


        //PlayerDodge(moveDirection);


    }

    ///////////////////////////////////////////////////////

    

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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // change moveDirection from local space to global space (current global pos + moveDirection)
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= currentSpeed * Time.deltaTime;
    }

    private void PlayerMove_Vertical()
    {
        //Set new Y velcoity from gravity + jump
        verticalVelocity = GetGravity();
        verticalVelocity = PlayerJump();

        //Set Y value to move direction
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }




private bool one_press;
private bool timer_running;
private float delay;
private bool two_press;
private float two_press_timer;

    private void DoubleTap()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!one_press)
            {
                one_press = true;
                delay = Time.time + 0.2f;
            }
            else
            {
                one_press = false;
                two_press_timer = 0.3f;
                two_press = true;
            }
        }



        if (one_press)
        {
            if ((Time.time - .05) > delay)
            {
                one_press = false;
            }
        }
        if (two_press)
        {
            two_press_timer = two_press_timer - Time.deltaTime;
            transform.Translate(Vector3.left * 20 * Time.deltaTime);
            if (two_press_timer <= 0)
            {
                two_press = false;
            }

        }
    }

    private void PlayerDodge(Vector3 moveDirection)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            print("Test Code: BLANK");
            //player_CC.isGrounded && 

            //if ()
            {

            }


            //moveDirection.Scale();

            transform.Translate(moveDirection * 30);
        }


        if (two_press_timer <= 0)
        {
            two_press = false;
        }

        two_press_timer = two_press_timer - Time.deltaTime;

    }

    ///////////////////////////////////////////////////////
}

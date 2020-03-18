﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerController_Camera moves the players camera with the mousemovement when the camera is locked.
/// 
/// 
/// PLAYER LOAD ROTATION COMES FROM THE START OF THIS SCRIPT
/// 
/// 
/// </summary>
///////////////

public class TM_PlayerController_Camera : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Camera Instance;

    ////////////////////////////////

    [Header("Mouse Controls")]
    private float sensitivity = 3f;
    private float rollAngle = 0.5f;
    private float rollSpeed = 3f;

    [Header("Mouse Controls")]
    private Vector2 defaultLookLimits = new Vector2(-90f, 90f);
    private Vector2 lookAngles;
    //private Vector2 currentMouseLook;
    private float currentRollAngle;

    //private int lastLookFrame;
    //private Vector2 smoothMove;

    public Vector3 startingRotation;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Turn On Camera Lock
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        startingRotation = gameObject.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        //Look around with camera
        MoveCamera();
    }

    ///////////////////////////////////////////////////////

    private void MoveCamera()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        //Get Mouse Speeds
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX_Raw = Input.GetAxisRaw("Mouse X");

        //Combine Mouse inputs
        Vector2 currentMouseLook = new Vector2(-mouseY, mouseX);


        // ???
        lookAngles.x += currentMouseLook.x * sensitivity;
        lookAngles.y += currentMouseLook.y * sensitivity;

        //clamp look angle to min and max look angles
        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        //camera roll for looking side to side
        //currentRollAngle = Mathf.Lerp(currentRollAngle, mouseX_Raw * rollAngle, rollSpeed * Time.deltaTime);


        //Set new angles
        Camera.main.gameObject.transform.localRotation = Quaternion.Euler(lookAngles.x, 0f, currentRollAngle);
        gameObject.transform.localRotation = Quaternion.Euler(0f, lookAngles.y + startingRotation.y, 0f);
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool canUnlock = true;

    [SerializeField]
    private float sensitivity = 4f;

    [SerializeField]
    private int smoothSteps = 10;

    [SerializeField]
    private float smoothWeight = 0.4f;

    [SerializeField]
    private float rollAngle = 0.5f;

    [SerializeField]
    private float rollSpeed = 3f;

    [SerializeField]
    private Vector2 defaultLookLimits = new Vector2(-90f, 90f);

    private Vector2 lookAngles;

    private Vector2 currentMouseLook;
    private Vector2 smoothMove;

    private float currentRollAngle;

    private int lastLookFrame;



    void LookAround()
    {
        /*
        currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        //(invert ? 1f : -1f)  ->  If (invert == true){use 1f} else{use -1f]
        lookAngles.x += currentMouseLook.x * sensitivity * (invert ? 1f : -1f);
        lookAngles.y += currentMouseLook.y * sensitivity;

        //clamp look angle to min and max look angles
        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        //camera roll for looking side to side
        currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw(MouseAxis.MOUSE_X) * rollAngle, rollSpeed * Time.deltaTime);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, currentRollAngle);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
        */

    }// LookAround



}// class

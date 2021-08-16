using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_TitleScreenCameraRotator 
/// 
/// </summary>
///////////////

public class TM_TitleScreenCameraRotator : MonoBehaviour
{
    ////////////////////////////////
    
    public float speed = 5;

    ///////////////////////////////////////////////////////

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    ///////////////////////////////////////////////////////
}

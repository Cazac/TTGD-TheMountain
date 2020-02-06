using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_CycleController Controls the cycle clock in the UI and the effect it produces in the world.
/// 
/// </summary>
///////////////

public class TM_CycleClockController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_CycleClockController Instance;

    ////////////////////////////////



    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        
    }

    ///////////////////////////////////////////////////////
}

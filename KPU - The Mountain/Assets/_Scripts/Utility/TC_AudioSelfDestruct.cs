using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// The TC_AudioSelfDestruct class is used to auto destruct SFX when they are built.
/// 
/// </summary>
///////////////

public class TC_AudioSelfDestruct : MonoBehaviour
{
    ////////////////////////////////

    public float TimeTillDestruction;
    public float counter;

    /////////////////////////////////////////////////////////////////

    public void Update()
    {
        //Countdown by Frame Timings Each Frame
        Countdown();
    }

    /////////////////////////////////////////////////////////////////

    public void Setup(float DestroyTime)
    {
        //If out of TIme Self Destruct
        if (DestroyTime == 0)
        {
            Destroy(this);
        }

        //Set When the Gameobject should be destroyed
        TimeTillDestruction = DestroyTime + 0.1f;
        counter = 0;
    }

    private void Countdown()
    {
        //Countdown till destruction
        if (TimeTillDestruction < counter)
        {
            Destroy(gameObject);
        }
        else
        {
            //Add to Counter
            counter += Time.deltaTime;
        }
    }

    /////////////////////////////////////////////////////////////////
}

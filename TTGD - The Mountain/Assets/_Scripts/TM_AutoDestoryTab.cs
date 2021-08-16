using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_ExampleClass 
///
///
/// Class Type - 
///
/// 
/// </summary>
///////////////

public class TM_AutoDestoryTab : MonoBehaviour
{
    ////////////////////////////////



    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(AutoDestoryCountdown(1f));
    }

    ///////////////////////////////////////////////////////

    public void Setup(float clipLength)
    {
        StartCoroutine(AutoDestoryCountdown(clipLength));
    }

    private IEnumerator AutoDestoryCountdown(float clipLength)
    {
        //Wait Till Clip is over + buffer room
        yield return new WaitForSeconds(clipLength + 0.1f);

        //Destory Clip
        Destroy(gameObject);

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////

    public void InstantDestroy()
    {
        //Destory Gameobject
        Destroy(gameObject);
    }

    ///////////////////////////////////////////////////////
}

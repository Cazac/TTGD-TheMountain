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

public class TM_SpawnerCandlesTab : MonoBehaviour
{
    ////////////////////////////////

    public bool isCandleActive;
    public GameObject candleParticules;

    ///////////////////////////////////////////////////////

    public void SetCandleActive()
    {
        isCandleActive = true;
        candleParticules.SetActive(true);

    }

    public void SetCandleDeactive()
    {
        isCandleActive = false;
        candleParticules.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

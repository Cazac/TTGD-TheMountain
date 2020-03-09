using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_CycleData 
/// 
/// DATA CLASS 
/// Data classes are used to store data under the TM_DatabaseController for better sorting
/// 
/// </summary>
///////////////

public class TM_CycleData : MonoBehaviour
{
    ////////////////////////////////

    [Header("General Cycles")]
    public TM_Cycle_SO growth_Cycle;
    public TM_Cycle_SO burning_Cycle;
    public TM_Cycle_SO death_Cycle;


    ////////////////////////////////
}


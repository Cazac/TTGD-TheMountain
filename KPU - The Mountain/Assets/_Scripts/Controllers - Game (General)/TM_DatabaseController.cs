using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// </summary>
///////////////

public class TM_DatabaseController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_DatabaseController Instance;

    ////////////////////////////////


    //[Header("Enemy Lists")]
    public TM_Item_SO apple;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        SpawnDebugItemPlaced();
    }

    /////////////////////////////////////////////////////////////////

    private void SpawnDebugItemPlaced()
    {
        //DEBUG SPAWN
        if (Input.GetKeyDown(KeyCode.R))
        {
            //consumableFood_LIST[0].SpawnItem_Placed();
        }
    }

    /////////////////////////////////////////////////////////////////
}

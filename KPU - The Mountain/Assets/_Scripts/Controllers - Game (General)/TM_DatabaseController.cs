using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_DatabaseController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_DatabaseController Instance;

    ////////////////////////////////

    [Header("Music Database")]
    public TM_MusicData musicDatabase;




    public TM_PlayerSaveData playerSaveData;



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


        playerSaveData = new TM_PlayerSaveData();
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

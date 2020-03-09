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
    public TM_MusicData music_DB;

    [Header("Ambience Database")]
    public TM_AmbienceData ambience_DB;

    [Header("SFX Database")]
    public TM_SFXData sfx_DB;

    [Header("Item Database")]
    public TM_ItemData item_DB;

    [Header("Cycle Database")]
    public TM_CycleData cycle_DB;





    [Header("Player Saves?????")]
    public TM_PlayerSaveData playerSaveData;




    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {




        playerSaveData = new TM_PlayerSaveData();
    }

    /////////////////////////////////////////////////////////////////
}

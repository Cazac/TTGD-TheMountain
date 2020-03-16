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

    [Header("Hitbox Database")]
    public TM_HitboxData hitbox_DB;

    [Header("Icon Database")]
    public TM_IconData icon_DB;

    [Header("Name Database")]
    public TM_NameData name_DB;


    [Header("Save Datas")]
    public TM_PlayerSaveData player_SaveData;
    public TM_SettingsSaveData settings_SaveData;



    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Build Databases
        name_DB.BuildDatabase();

        player_SaveData = new TM_PlayerSaveData();
    }

    /////////////////////////////////////////////////////////////////
}

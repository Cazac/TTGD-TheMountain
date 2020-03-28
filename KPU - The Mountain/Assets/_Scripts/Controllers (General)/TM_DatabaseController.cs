using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// 
/// Each Data Class used must container none scene specfic data as the database will be transfered across scenes
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

    ////////////////////////////////

    [Header("Current Player Save Data")]
    public TM_PlayerSaveData player_SaveData;

    [Header("Account Save Data")]
    public TM_SettingsSaveData settings_SaveData;
    public TM_MorgueSaveData morgue_SaveData;
    public TM_UnlocksSaveData unlock_SaveData;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Check to Delete Singleton
        CheckSingleton();

        //Build Databases Value Lists
        BuildDatabase();
    }

    private void Start()
    {
        GetSceneSetup();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (Instance == this)
        {
            GetSceneSetup();
        }
    }

    /////////////////////////////////////////////////////////////////

    private void CheckSingleton()
    {
        if (Instance == null)
        {
            //Set Static Singleton Self Refference
            Instance = this;

            //Instance is Set, Do not delete this database
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Remove Current Scene Quick Load Database
            Destroy(gameObject);
        }
    }

    private void BuildDatabase()
    {
        //Build Databases
        item_DB.BuildDatabase();
        name_DB.BuildDatabase();
        cycle_DB.BuildDatabase();


    }

    private void GetSceneSetup()
    {
        //Get Name Of Current Scene
        string currentScene = SceneManager.GetActiveScene().name;

        //Check the type by scene
        if (currentScene == "TM_Title")
        {
            Setup_Title();
        }
        else if (currentScene == "TM_Zac's Systems Room" || currentScene == "TM_Game")
        {
            if (player_SaveData.player_hasLoadedSaveBefore)
            {
                //Load Stats From player and start game
                Setup_GameLoad();
            }
            else
            {
                //Player has not played before, Setup stats
                Setup_GameNew();
            }

        }
        else if (currentScene == "TM_Credits")
        {
            Setup_Credits();
        }
    }

    /////////////////////////////////////////////////////////////////

    private void Setup_Title()
    {
        print("Test Code: Loading All Settings Files...");

        TM_SaveController.Instance.SettingsData_LoadSaveFile();
        TM_SaveController.Instance.UnlocksData_LoadSaveFile();
        TM_SaveController.Instance.MorgueData_LoadSaveFile();
    }

    private void Setup_Credits()
    {
        return;
    }

    /////////////////////////////////////////////////////////////////

    private void Setup_GameNew()
    {
        print("Test Code: ...New Game Found");



        //Do Eextra Stuff, Rmove this stuff~



        //Reload Data For the Systems Room Debug Play
        TM_SaveController.Instance.PlayerData_ReloadSaveFiles();

        //Assume the data is present already
        TM_SaveController.Instance.PlayerData_LoadGameData();
    }

    private void Setup_GameLoad()
    {
        print("Test Code: ...Loaded Game Found");


        //Reload Data For the Systems Room Debug Play
        TM_SaveController.Instance.PlayerData_ReloadSaveFiles();

        //Assume the data is present already
        TM_SaveController.Instance.PlayerData_LoadGameData();
    }

    /////////////////////////////////////////////////////////////////
}

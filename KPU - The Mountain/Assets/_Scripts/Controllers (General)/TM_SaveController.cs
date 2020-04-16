using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_SaveSystemController
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_SaveController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_SaveController Instance;

    ////////////////////////////////

    [Header("Player Save File Data")]
    public int currentSaveSlotID;
    public ES3File[] playerSaveFiles_Array = new ES3File[5];

    ////////////////////////////////

    [Header("Player Save File Data")]
    public ES3File settingsSaveFile;
    public ES3File unlocksSaveFile;
    public ES3File morgueSaveFile;
  
    /////////////////////////////////////////////////////////////////

    private void Awake()
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

    ///////////////////////////////////////////////////////////////// - Reload Save Data File Refferences

    public void PlayerData_ReloadSaveFiles()
    {
        //Load Or Create Save Files
        playerSaveFiles_Array[0] = new ES3File("The Mountain Save 1.es3");
        playerSaveFiles_Array[1] = new ES3File("The Mountain Save 2.es3");
        playerSaveFiles_Array[2] = new ES3File("The Mountain Save 3.es3");
        playerSaveFiles_Array[3] = new ES3File("The Mountain Save 4.es3");
        playerSaveFiles_Array[4] = new ES3File("The Mountain Save 5.es3");
    }

    ///////////////////////////////////////////////////////////////// - Set The Current PlayerData Index / Database Value

    public void PlayerData_SetCurrentSaveFile(int saveSlot)
    {
        currentSaveSlotID = saveSlot;
    }

    ///////////////////////////////////////////////////////////////// - Get The Playerdata From the Files

    public TM_PlayerSaveData PlayerData_GetSaveFile(int saveSlot)
    {
        if (playerSaveFiles_Array[saveSlot - 1].KeyExists("PlayerSaveData"))
        {
            return playerSaveFiles_Array[saveSlot - 1].Load<TM_PlayerSaveData>("PlayerSaveData");
        }
        else
        {
            return null;
        }
    }

    public TM_PlayerSaveData PlayerData_GetCurrentSaveFile()
    {
        if (currentSaveSlotID == 0)
        {
            //print("Test Code: Deafult Save File");
            //Return Default
            return PlayerData_CreateDefault();
        }
        else if (playerSaveFiles_Array[currentSaveSlotID - 1].KeyExists("PlayerSaveData"))
        {
            //print("Test Code: Loaded Save File");
            return playerSaveFiles_Array[currentSaveSlotID - 1].Load<TM_PlayerSaveData>("PlayerSaveData");
        }
        else
        {
            //print("Test Code: Deafult Save File");
            //Return Default
            return PlayerData_CreateDefault();
        }
    }

    ///////////////////////////////////////////////////////////////// - Save The file to System From A PlayerData

    public void PlayerData_SaveFile(TM_PlayerSaveData newPlayerSaveData, int saveSlot)
    {
        //Save Data To File
        ES3.Save<TM_PlayerSaveData>("PlayerSaveData", newPlayerSaveData, "The Mountain Save " + currentSaveSlotID + ".es3");
    }

    ///////////////////////////////////////////////////////////////// - Destroy Save Files From System

    public void PlayerData_DeleteSaveFile(int saveSlot)
    {
        //Delete File
        ES3.DeleteFile("The Mountain Save " + saveSlot + ".es3");
    }

    /////////////////////////////////////////////////////////////////

    public TM_PlayerSaveData PlayerData_CreateDefault()
    {
        TM_PlayerSaveData saveData = new TM_PlayerSaveData();


        saveData.player_hasLoadedSaveBefore = false;

        //Player Info
        saveData.playerInfo_Name = "The Mountainer";
        saveData.playerInfo_Class = "Brawler";

        //World Info
        saveData.playerInfo_MapSeed = 99999999;
        saveData.playerInfo_CyclesSurvived = 0;
        saveData.playerInfo_BossesKilled = 0;
        saveData.playerInfo_NotesCollected = 0;

        //Unlocks
        saveData.player_HasUnlocked_Brewery = false;
        saveData.player_HasUnlocked_Forge = false;
        saveData.player_HasUnlocked_Canteen = false;
        saveData.player_HasUnlocked_Storage = false;

        //Leveling
        saveData.player_Level = 1;
        saveData.player_Exp = 0;
        saveData.player_SkillPointsAvalible = 0;
        saveData.player_SkillPointsSpent = 0;


        saveData.player_CurrentStat_STR = 5;
        saveData.player_CurrentStat_DEX = 5;
        saveData.player_CurrentStat_INT = 5;
        saveData.player_CurrentStat_CON = 5;

        saveData.player_CurrentHealth = 100;
        saveData.player_MaxHealth = 100;
        saveData.player_BaseHealth = 100;

        saveData.player_CurrentHunger = 100;
        saveData.player_MaxHunger = 100;
        saveData.player_BaseHunger = 100;

        saveData.player_CurrentFire = 100;
        saveData.player_MaxFire = 100;
        saveData.player_BaseFire = 100;


        saveData.player_Position = new Vector3(-30f, 8.5f, 0.2f);
        //saveData.player_Rotation = Quaternion.Euler(0f, -90f, 0f);
           




        saveData.player_Inventory = new TM_ItemUI[20];
        saveData.player_Storage = new TM_ItemUI[20];


        return saveData;
    }






    ///////////////////////////////////////////////////////////////// - Game State Loading And Saving

    public void PlayerData_SaveGameData()
    {
        print("Test Code: Saving Game Data...");


        //Convert To Savable Data
        TM_DatabaseController.Instance.player_SaveData.ConvertGameData_ToSaveData();

        //Save To File
        PlayerData_SaveFile(TM_DatabaseController.Instance.player_SaveData, currentSaveSlotID);


        print("Test Code: ...Saving Game Data Done!");
    }

    public void PlayerData_LoadGameData()
    {
        print("Test Code: Loading Game Data...");

        //Load Player Data To Database
        TM_DatabaseController.Instance.player_SaveData = PlayerData_GetCurrentSaveFile();

        //Load Data Into Game
        TM_DatabaseController.Instance.player_SaveData.ConvertSaveData_ToGameData();

        print("Test Code: ...Game Data Loaded!");
    }

    /////////////////////////////////////////////////////////////////











    /////////////////////////////////////////////////////////////////

    public void SettingsData_LoadSaveFile()
    {
        //Load Or Create Save Files
        settingsSaveFile = new ES3File("The Mountain Settings.es3");
        TM_SettingsSaveData currentSettingsData = null;

        if (settingsSaveFile.KeyExists("SettingsSaveData"))
        {
            //print("Test Code: ...Settings Found, Loading!");

            //Load Settings From File
            currentSettingsData = settingsSaveFile.Load<TM_SettingsSaveData>("SettingsSaveData");
        }
        else
        {
            //print("Test Code: Settings NOT FOUND, Creating!");

            //Create New defualt Settings
            currentSettingsData = SettingsData_CreateDefault();

            //Save It
            SettingsData_SaveFile(currentSettingsData);
        }

        //Set Settings In Database
        TM_DatabaseController.Instance.settings_SaveData = currentSettingsData;
    }

    public void SettingsData_SaveFile(TM_SettingsSaveData newSettingsSaveData)
    {
        //Save Data To File
        ES3.Save<TM_SettingsSaveData>("SettingsSaveData", newSettingsSaveData, "The Mountain Settings.es3");
    }

    public TM_SettingsSaveData SettingsData_CreateDefault()
    {
        print("Test Code: Creating New Settings");


        TM_SettingsSaveData saveData = new TM_SettingsSaveData();


        saveData.isMusicMute = false;
        saveData.isAmbienceMute = false;
        saveData.isSFXMute = false;

        saveData.volumeTotal = 0.5f;
        saveData.volumeMusic = 0.5f;
        saveData.volumeAmbience = 0.5f;
        saveData.volumeSFX = 0.5f;


        saveData.keybindings_Dictonary = new Dictionary<string, KeyCode>();

        saveData.keybindings_Dictonary.Add("Forward", KeyCode.W);
        saveData.keybindings_Dictonary.Add("Backwards", KeyCode.S);
        saveData.keybindings_Dictonary.Add("Left", KeyCode.A);
        saveData.keybindings_Dictonary.Add("Right", KeyCode.D);

        saveData.keybindings_Dictonary.Add("Jump", KeyCode.Space);
        saveData.keybindings_Dictonary.Add("Sprint", KeyCode.LeftShift);

        saveData.keybindings_Dictonary.Add("Attack", KeyCode.Mouse0);
        saveData.keybindings_Dictonary.Add("Use", KeyCode.Mouse1);

        saveData.keybindings_Dictonary.Add("Interact", KeyCode.F);
        saveData.keybindings_Dictonary.Add("Inventory", KeyCode.E);
        saveData.keybindings_Dictonary.Add("Notes", KeyCode.N);
        saveData.keybindings_Dictonary.Add("Stats", KeyCode.L);



        return saveData;
    }

    /////////////////////////////////////////////////////////////////

    public void MorgueData_LoadSaveFile()
    {
        //Load Or Create Save Files
        morgueSaveFile = new ES3File("The Mountain Morgue.es3");
    }

    public void MorgueData_SaveFile(TM_SettingsSaveData newSettingsSaveData)
    {
        //Save Data To File
        //ES3.Save<TM_SettingsSaveData>("SettingsSaveData", newSettingsSaveData, "The Mountain Settings.es3");
    }

    /////////////////////////////////////////////////////////////////

    public void UnlocksData_LoadSaveFile()
    {
        //Load Or Create Save Files
        unlocksSaveFile = new ES3File("The Mountain Unlocks.es3"); 
    }

    public void UnlocksData_SaveFile(TM_SettingsSaveData newSettingsSaveData)
    {
        //Save Data To File
        //ES3.Save<TM_SettingsSaveData>("SettingsSaveData", newSettingsSaveData, "The Mountain Settings.es3");
    }

    /////////////////////////////////////////////////////////////////












    /*
     * 
     * This class will manage the creation of prefabs, including loading and saving them.
     * It will also store a list of all of the prefabs we've created.
     * 
     */
    public class ES3PrefabManager : MonoBehaviour
{
    // The prefab we want to create.
    public GameObject prefab;
    // An automatically-generated unique identifier for this type of prefab.
    // We will append this to our keys when saving to identifiy different types
    // of prefab in the save file.
    public string id = System.Guid.NewGuid().ToString();

    // A List which we'll add the Transforms of our created prefabs to.
    private List<Transform> prefabInstances = new List<Transform>();

    /*
   * This is called whenever the application is quit.
  * This is where we will save our data.
  */
    void OnApplicationQuit()
    {
        // Save the number of created prefabs there are.
        ES3.Save<int>(id + "count", prefabInstances.Count);
        // Save our Transforms.
        ES3.Save<List<Transform>>(id, prefabInstances);
    }

    /* We also call OnApplicationPause, which is called when an app goes into the background. */
    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
            OnApplicationQuit();
    }

    /*
    * This is called when the scene first loads.
     * This is where we load our prefabs, if there are prefabs to load.
   */
    void Start()
    {
        int count = ES3.Load<int>(id + "count", 0);
        // If there are prefabs to load, load them.
        if (count > 0)
        {
            // For each prefab we want to load, instantiate a prefab.
            for (int i = 0; i < count; i++)
                InstantiatePrefab();
            // Load our List of Transforms into our prefab array.
            ES3.LoadInto<List<Transform>>(id, prefabInstances);
        }
    }

    /*
    *  Creates an instance of the prefab and adds it to the instance list.
   */
    public GameObject InstantiatePrefab()
    {
        var go = Instantiate(prefab);
        prefabInstances.Add(go.transform);
        return go;
    }

    /*
    * Instantiates the prefab at a random position and with a random rotation.
   */
    public void CreateRandomPrefab()
    {
        var go = InstantiatePrefab();
        go.transform.position = Random.insideUnitSphere * 5;
        go.transform.rotation = Random.rotation;
    }

    /*
    *  Deletes all prefab instances from the scene and from the save file.
   */
    public void DeletePrefabs()
    {
        // Delete the keys relating to this prefab.
        ES3.DeleteKey(id);
        ES3.DeleteKey(id + "count");
        // Destroy each created prefab, and then clear the List.
        for (int i = 0; i < prefabInstances.Count; i++)
            Destroy(prefabInstances[i].gameObject);
        prefabInstances.Clear();
    }
}
 

}

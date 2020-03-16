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
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////


    public void PlayerData_ReloadSaveFiles()
    {
        //Load Or Create Save Files
        playerSaveFiles_Array[0] = new ES3File("The Mountain Save 1.es3");
        playerSaveFiles_Array[1] = new ES3File("The Mountain Save 2.es3");
        playerSaveFiles_Array[2] = new ES3File("The Mountain Save 3.es3");
        playerSaveFiles_Array[3] = new ES3File("The Mountain Save 4.es3");
        playerSaveFiles_Array[4] = new ES3File("The Mountain Save 5.es3");
    }

    public void PlayerData_SetCurrentSaveFile(int saveSlot)
    {
        currentSaveSlotID = saveSlot;
    }

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
        if (playerSaveFiles_Array[currentSaveSlotID - 1].KeyExists("PlayerSaveData"))
        {
            return playerSaveFiles_Array[currentSaveSlotID - 1].Load<TM_PlayerSaveData>("PlayerSaveData");
        }
        else
        {
            return null;
        }
    }

    public void PlayerData_SaveFile(TM_PlayerSaveData newPlayerSaveData, int saveSlot)
    {
        //Save Data To File
        ES3.Save<TM_PlayerSaveData>("PlayerSaveData", newPlayerSaveData, "The Mountain Save " + currentSaveSlotID + ".es3");
    }


    /////////////////////////////////////////////////////////////////



    public void PlayerData_DeleteSaveFile(int saveSlot)
    {
        //Delete File
        ES3.DeleteFile("The Mountain Save " + saveSlot + ".es3");
    }




    /////////////////////////////////////////////////////////////////



    public void PlayerData_SaveDataTitle()
    {

    }

    public TM_PlayerSaveData PlayerData_LoadDataTitle(int saveSlot)
    {
        //Get File
        ES3File file = new ES3File("The Mountain Save " + saveSlot + ".es3");

        //Get Player Data
        TM_PlayerSaveData data = file.Load<TM_PlayerSaveData>("PlayerSaveData");


        return data;
    }




    public void PlayerData_SaveDataGame()
    {
        print("Test Code: Saving...");



        TM_DatabaseController.Instance.player_SaveData.SaveData_FromGame();



        ES3.Save<TM_PlayerSaveData>("PlayerSaveData", TM_DatabaseController.Instance.player_SaveData, "The Mountain Save " + currentSaveSlotID + ".es3");


        print("Test Code: ...Saving Done!");
    }


    /////////////////////////////////////////////////////////////////






    public void LoadPlayerData()
    {
        print("Test Code: Loading...");

        //Get File
        ES3File file = new ES3File("The Mountain Save " + currentSaveSlotID + ".es3");

        //Get Player Data
        TM_PlayerSaveData data = file.Load<TM_PlayerSaveData>("PlayerSaveData");

        //Get Map Data


        //Load Data Into Game
        data.LoadData_ToGame();

        print("Test Code: ...Loading Done!");
    }









    /////////////////////////////////////////////////////////////////

    public void SettingsData_LoadSaveFile()
    {
        //Load Or Create Save Files
        settingsSaveFile = new ES3File("The Mountain Settings.es3");
        TM_SettingsSaveData currentSettingsData = null;

        if (settingsSaveFile.KeyExists("SettingsSaveData"))
        {
            currentSettingsData = settingsSaveFile.Load<TM_SettingsSaveData>("SettingsSaveData");
        }
        else
        {
            currentSettingsData = new TM_SettingsSaveData();



            //SETUP VALUSE
            //currentSettingsData


            //SAVE VALUE
        }

        TM_DatabaseController.Instance.settings_SaveData = currentSettingsData;
    }

    public void SettingsData_SaveFile(TM_SettingsSaveData newSettingsSaveData)
    {
        //Save Data To File
        ES3.Save<TM_SettingsSaveData>("SettingsSaveData", newSettingsSaveData, "The Mountain Settings.es3");
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

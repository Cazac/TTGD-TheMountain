using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

///////////////
/// <summary>
///     
/// TM_ButtonController_Play is used to control the button on the Title Screen pertaining to the 
/// "play" sub menu. This deals with loading the game saves, creating game saves and starting the game.
/// 
/// </summary>
///////////////

public class TM_ButtonController_Play : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ButtonController_Play Instance;

    ////////////////////////////////

    [Header("Charecter Panel Info")]
    public GameObject charecterNew_Panel;
    public GameObject charecterLoad_Panel;

    ////////////////////////////////

    [Header("Icon Info - 1")]
    public GameObject saveIcon1_NewSave_Panel;
    public GameObject saveIcon1_LoadSave_Panel;
    public TextMeshProUGUI saveIcon1_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon1_LoadSaveDesc_Text;

    ////////////////////////////////

    [Header("Icon New Info - 2")]
    public GameObject saveIcon2_NewSave_Panel;
    public GameObject saveIcon2_LoadSave_Panel;
    public TextMeshProUGUI saveIcon2_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon2_LoadSaveDesc_Text;


    ////////////////////////////////


    public ES3File playerSave_1;



    private int currentSelected_SaveSlotID;


    public ES3File[] saveFiles_Array = new ES3File[5];

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Button_Load_Play()
    {
        //Load Game Scene
        SceneManager.LoadScene("TM_Game");
    }

    public void Button_SaveSlot(int saveSlot)
    {
        //Load Or Create Files
        saveFiles_Array[0] = new ES3File("The Mountain Save 1.es3");
        saveFiles_Array[1] = new ES3File("The Mountain Save 2.es3");
        saveFiles_Array[2] = new ES3File("The Mountain Save 3.es3");
        saveFiles_Array[3] = new ES3File("The Mountain Save 4.es3");
        saveFiles_Array[4] = new ES3File("The Mountain Save 5.es3");

        //Selected File
        ES3File selectedSaveFile = null;

        //Get Button Number Input
        switch (saveSlot)
        {
            case 1:
                
                //
                selectedSaveFile = saveFiles_Array[0];
                currentSelected_SaveSlotID = 1;
                break;

            case 2:

                //
                selectedSaveFile = saveFiles_Array[1];
                currentSelected_SaveSlotID = 2;
                break;

            case 3:

                //
                selectedSaveFile = saveFiles_Array[2];
                currentSelected_SaveSlotID = 3;
                break;

            case 4:

                //
                selectedSaveFile = saveFiles_Array[3];
                currentSelected_SaveSlotID = 4;
                break;

            case 5:

                //
                selectedSaveFile = saveFiles_Array[4];
                currentSelected_SaveSlotID = 5;
                break;
        }


        //Save File 1
        if (selectedSaveFile.KeyExists("PlayerName"))
        {
            //Use Loaded charecter sheet
            charecterNew_Panel.SetActive(false);
            charecterLoad_Panel.SetActive(true);
        }
        else
        {
            //Use New charecter sheet
            charecterNew_Panel.SetActive(true);
            charecterLoad_Panel.SetActive(false);
        }
    }

    ///////////////////////////////////////////////////////

    private void LoadCharecterSheet_New()
    {
        print("Test Code: New Charecter!");
    }

    private void LoadCharecterSheet_Saved(string saveData)
    {
        print("Test Code: Old Charecter - " + saveData);
    }

    ///////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////

    /////////////////////////////////////////////////////// - Debug Saving

    public void Refresh_SaveIconInfo()
    {
        //Load Or Create Files
        saveFiles_Array[0] = new ES3File("The Mountain Save 1.es3");
        saveFiles_Array[1] = new ES3File("The Mountain Save 2.es3");
        saveFiles_Array[2] = new ES3File("The Mountain Save 3.es3");
        saveFiles_Array[3] = new ES3File("The Mountain Save 4.es3");
        saveFiles_Array[4] = new ES3File("The Mountain Save 5.es3");

        ////////////////////////////////

        //Save File 1
        if (saveFiles_Array[0].KeyExists("PlayerName"))
        {
            //Set Loaded Panels
            saveIcon1_NewSave_Panel.SetActive(false);
            saveIcon1_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon1_LoadSaveTitle_Text.text = saveFiles_Array[0].Load<string>("PlayerName");
            saveIcon1_LoadSaveDesc_Text.text = saveFiles_Array[0].Load<string>("PlayerLevel");
            //ICON
        }
        else
        {
            //New Panel
            saveIcon1_NewSave_Panel.SetActive(true);
            saveIcon1_LoadSave_Panel.SetActive(false);
        }

        ////////////////////////////////

        //Save File 2
        if (saveFiles_Array[1].KeyExists("PlayerName"))
        {
            //Set Loaded Panels
            saveIcon2_NewSave_Panel.SetActive(false);
            saveIcon2_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon2_LoadSaveTitle_Text.text = saveFiles_Array[1].Load<string>("PlayerName");
            saveIcon2_LoadSaveDesc_Text.text = saveFiles_Array[1].Load<string>("PlayerLevel");
            //ICON
        }
        else
        {
            //New Panel
            saveIcon2_NewSave_Panel.SetActive(true);
            saveIcon2_LoadSave_Panel.SetActive(false);
        }





    }



    ///////////////////////////////////////////////////////


    public void Button_DeleteCharecter()
    {

        ES3.DeleteFile("The Mountain Save " + currentSelected_SaveSlotID + ".es3");



        Refresh_SaveIconInfo();
    }


    public void Button_SaveNewCharecter()
    {

        int name = UnityEngine.Random.Range(0, 100);
        int level = UnityEngine.Random.Range(0, 50);




        ES3.Save<string>("PlayerName", name.ToString(), "The Mountain Save " + currentSelected_SaveSlotID + ".es3");
        ES3.Save<string>("PlayerLevel", level.ToString(), "The Mountain Save " + currentSelected_SaveSlotID + ".es3");


        Refresh_SaveIconInfo();

        print("Test Code: Create");



        // Load the int array


        // Save an int array
        // ES3.Save<int[]>("myArray", myArray);

        // Save a List of strings
        //ES3.Save<List<string>>("myList", myList);

        // Save a Dictionary of string keys and Vector3 values
        //ES3.Save<Dictionary<string, Vector3>>("myDictionary", myDictionary);
    }




    ///////////////////////////////////////////////////////
}

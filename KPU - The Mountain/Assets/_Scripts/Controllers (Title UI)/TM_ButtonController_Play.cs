using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_ButtonController_Play is used to control the button on the Title Screen pertaining to the 
/// "play" sub menu. This deals with loading the game saves, creating game saves and starting the game.
/// 
/// 
/// 
/// 
/// 
// Load the int array


// Save an int array
// ES3.Save<int[]>("myArray", myArray);

// Save a List of strings
//ES3.Save<List<string>>("myList", myList);

// Save a Dictionary of string keys and Vector3 values
//ES3.Save<Dictionary<string, Vector3>>("myDictionary", myDictionary);
/// 
/// 
/// 
/// </summary>
///////////////

public class TM_ButtonController_Play : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ButtonController_Play Instance;

    ////////////////////////////////

    [Header("General - Icon Info 1")]
    public GameObject saveSlot1_Panel;
    public GameObject saveIcon1_NewSave_Panel;
    public GameObject saveIcon1_LoadSave_Panel;
    public Image saveIcon1_LoadIcon_Image;
    public TextMeshProUGUI saveIcon1_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon1_LoadSaveDesc_Text;

    ////////////////////////////////

    [Header("General - Icon Info 2")]
    public GameObject saveSlot2_Panel;
    public GameObject saveIcon2_NewSave_Panel;
    public GameObject saveIcon2_LoadSave_Panel;
    public Image saveIcon2_LoadIcon_Image;
    public TextMeshProUGUI saveIcon2_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon2_LoadSaveDesc_Text;

    ////////////////////////////////

    [Header("General - Icon Info 3")]
    public GameObject saveSlot3_Panel;
    public GameObject saveIcon3_NewSave_Panel;
    public GameObject saveIcon3_LoadSave_Panel;
    public Image saveIcon3_LoadIcon_Image;
    public TextMeshProUGUI saveIcon3_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon3_LoadSaveDesc_Text;

    ////////////////////////////////

    [Header("General - Icon Info 4")]
    public GameObject saveSlot4_Panel;
    public GameObject saveIcon4_NewSave_Panel;
    public GameObject saveIcon4_LoadSave_Panel;
    public Image saveIcon4_LoadIcon_Image;
    public TextMeshProUGUI saveIcon4_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon4_LoadSaveDesc_Text;

    ////////////////////////////////

    [Header("General - Icon Info 5")]
    public GameObject saveSlot5_Panel;
    public GameObject saveIcon5_NewSave_Panel;
    public GameObject saveIcon5_LoadSave_Panel;
    public Image saveIcon5_LoadIcon_Image;
    public TextMeshProUGUI saveIcon5_LoadSaveTitle_Text;
    public TextMeshProUGUI saveIcon5_LoadSaveDesc_Text;

    ////////////////////////////////

    ////////////////////////////////

    ////////////////////////////////

    [Header("New Save - Class Buttons")]
    public GameObject newSave_ClassBrawlerButton;
    public GameObject newSave_ClassKnightButton;
    public GameObject newSave_ClassArcherButton;
    public GameObject newSave_ClassWizardButton;
    public GameObject newSave_ClassTankButton;

    private string newSave_currentClass;

    [Header("New Save - Class Text")]
    public TextMeshProUGUI newSave_ClassSTR_Text;
    public TextMeshProUGUI newSave_ClassDEX_Text;
    public TextMeshProUGUI newSave_ClassINT_Text;
    public TextMeshProUGUI newSave_ClassCON_Text;

    ////////////////////////////////

    ////////////////////////////////

    ////////////////////////////////

    [Header("Load Save - Charecter Panel Info")]
    public GameObject charecterNew_Panel;
    public GameObject charecterLoad_Panel;
    public TextMeshProUGUI charecterLoad_SaveSlot_Text;
    public TextMeshProUGUI charecterLoad_Name_Text;
    public TextMeshProUGUI charecterLoad_Level_Text;
    public TextMeshProUGUI charecterLoad_STR_Text;
    public TextMeshProUGUI charecterLoad_DEX_Text;
    public TextMeshProUGUI charecterLoad_INT_Text;
    public TextMeshProUGUI charecterLoad_CON_Text;
    public TextMeshProUGUI charecterLoad_Bosses_Text;
    public TextMeshProUGUI charecterLoad_Notes_Text;
    public TextMeshProUGUI charecterLoad_Time_Text;
    public Image charecterLoad_Icon_Image;

    ////////////////////////////////



    private GameObject currentSaveSlot_GO;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Setup()
    {
        //Select First Button
        Button_SaveSlot(1);

        //Visuals
        ButtonSelect_SaveSlot(saveSlot1_Panel);

        //Open First Save File
        SaveSlots_RefreshVisuals();
    }

    ///////////////////////////////////////////////////////

    public void Button_Load_Play()
    {
        //Load Game Scene
        SceneManager.LoadScene("TM_Game");
    }

    public void Button_SaveSlot(int saveSlot)
    {
        //Reload the Save Data
        TM_SaveController.Instance.PlayerData_ReloadSaveFiles();

        //Selected File
        TM_PlayerSaveData currentSaveFile = TM_SaveController.Instance.PlayerData_GetSaveFile(saveSlot);

        //Set Selected Save Value
        TM_SaveController.Instance.PlayerData_SetCurrentSaveFile(saveSlot);

        //Save File Load Or New Panel
        if (currentSaveFile != null)
        {
            //Use Loaded charecter sheet
            charecterNew_Panel.SetActive(false);
            charecterLoad_Panel.SetActive(true);

            //Load Details
            LoadSave_LoadPanel();
        }
        else
        {
            //Use New charecter sheet
            charecterNew_Panel.SetActive(true);
            charecterLoad_Panel.SetActive(false);

            //Load Details
            NewSave_LoadPanel();
        }
    }

    public void Button_DeleteCharecter()
    {
        //Delete Current File
        TM_SaveController.Instance.PlayerData_DeleteSaveFile(TM_SaveController.Instance.currentSaveSlotID);

        //Refresh Icon / Info Data
        SaveSlots_RefreshVisuals();

        //Reselect Button To Reload Stats
        Button_SaveSlot(TM_SaveController.Instance.currentSaveSlotID);
    }

    public void Button_CreateNewCharecter()
    {
        //Get Stats From Page


        //Check Null Values


        //Set Null Values


        TM_PlayerSaveData newPlayerSaveData = new TM_PlayerSaveData();
        newPlayerSaveData.player_Name = "";
        newPlayerSaveData.player_Level = 1;


        //Class / Stats
        if (newSave_currentClass == "Brawler")
        {
            //Set Stats
            newPlayerSaveData.player_Class = "Brawler";
            newPlayerSaveData.player_CurrentStat_STR = 8;
            newPlayerSaveData.player_CurrentStat_DEX = 6;
            newPlayerSaveData.player_CurrentStat_INT = 2;
            newPlayerSaveData.player_CurrentStat_CON = 4;
        }
        else if (newSave_currentClass == "Knight")
        {
            //Set Stats
            newPlayerSaveData.player_Class = "Knight";
            newPlayerSaveData.player_CurrentStat_STR = 7;
            newPlayerSaveData.player_CurrentStat_DEX = 5;
            newPlayerSaveData.player_CurrentStat_INT = 3;
            newPlayerSaveData.player_CurrentStat_CON = 5;
        }
        else if (newSave_currentClass == "Archer")
        {
            //Set Stats
            newPlayerSaveData.player_Class = "Archer";
            newPlayerSaveData.player_CurrentStat_STR = 3;
            newPlayerSaveData.player_CurrentStat_DEX = 9;
            newPlayerSaveData.player_CurrentStat_INT = 4;
            newPlayerSaveData.player_CurrentStat_CON = 4;
        }
        else if (newSave_currentClass == "Wizard")
        {
            //Set Stats
            newPlayerSaveData.player_Class = "Wizard";
            newPlayerSaveData.player_CurrentStat_STR = 2;
            newPlayerSaveData.player_CurrentStat_DEX = 4;
            newPlayerSaveData.player_CurrentStat_INT = 12;
            newPlayerSaveData.player_CurrentStat_CON = 2;
        }
        else if (newSave_currentClass == "Tank")
        {
            //Set Stats
            newPlayerSaveData.player_Class = "Tank";
            newPlayerSaveData.player_CurrentStat_STR = 7;
            newPlayerSaveData.player_CurrentStat_DEX = 3;
            newPlayerSaveData.player_CurrentStat_INT = 0;
            newPlayerSaveData.player_CurrentStat_CON = 10;
        }



        //Name Validation
        if (newPlayerSaveData.player_Name == "" || newPlayerSaveData.player_Name == null)
        {
            newPlayerSaveData.player_Name = "The Mountainer";
        }

        //Save File
        TM_SaveController.Instance.PlayerData_SaveFile(newPlayerSaveData, TM_SaveController.Instance.currentSaveSlotID);

        //Refresh Icon / Info Data
        SaveSlots_RefreshVisuals();

        //Reselect Button To Reload Stats
        Button_SaveSlot(TM_SaveController.Instance.currentSaveSlotID);
    }

    public void Button_ClassSlot(GameObject class_GO)
    {

        if (class_GO == newSave_ClassBrawlerButton)
        {
            //Set Stats
            newSave_ClassSTR_Text.text = "STR: 8";
            newSave_ClassDEX_Text.text = "DEX: 6";
            newSave_ClassINT_Text.text = "INT: 2";
            newSave_ClassCON_Text.text = "CON: 4";

            newSave_currentClass = "Brawler";

        }
        else if (class_GO == newSave_ClassKnightButton)
        {
            //Set Stats
            newSave_ClassSTR_Text.text = "STR: 7";
            newSave_ClassDEX_Text.text = "DEX: 5";
            newSave_ClassINT_Text.text = "INT: 3";
            newSave_ClassCON_Text.text = "CON: 5";

            newSave_currentClass = "Knight";
        }
        else if (class_GO == newSave_ClassArcherButton)
        {
            //Set Stats
            newSave_ClassSTR_Text.text = "STR: 3";
            newSave_ClassDEX_Text.text = "DEX: 9";
            newSave_ClassINT_Text.text = "INT: 4";
            newSave_ClassCON_Text.text = "CON: 4";

            newSave_currentClass = "Archer";
        }
        else if (class_GO == newSave_ClassWizardButton)
        {
            //Set Stats
            newSave_ClassSTR_Text.text = "STR: 2";
            newSave_ClassDEX_Text.text = "DEX: 4";
            newSave_ClassINT_Text.text = "INT: 12";
            newSave_ClassCON_Text.text = "CON: 2";

            newSave_currentClass = "Wizard";
        }
        else if (class_GO == newSave_ClassTankButton)
        {
            //Set Stats
            newSave_ClassSTR_Text.text = "STR: 7";
            newSave_ClassDEX_Text.text = "DEX: 3";
            newSave_ClassINT_Text.text = "INT: 0";
            newSave_ClassCON_Text.text = "CON: 10";

            newSave_currentClass = "Tank";
        }





    }

    ///////////////////////////////////////////////////////

    public void ButtonSelect_SaveSlot(GameObject saveSlot_GO)
    {
        //Remove All Selections And Set To Netrual Colors
        saveSlot1_Panel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        saveSlot2_Panel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        saveSlot3_Panel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        saveSlot4_Panel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        saveSlot5_Panel.GetComponent<Image>().color = new Color32(180, 180, 180, 255);


        saveSlot_GO.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
    }

    public void ButtonSelect_ClassSlot(GameObject class_GO)
    {


        //Remove all buttons
        newSave_ClassBrawlerButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        newSave_ClassKnightButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        newSave_ClassArcherButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        newSave_ClassWizardButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        newSave_ClassTankButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Select This Button
        class_GO.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    ///////////////////////////////////////////////////////

    public void SaveSlots_RefreshVisuals()
    {
        //Reload the Save Data
        TM_SaveController.Instance.PlayerData_ReloadSaveFiles();

        //Load Or Create Files
        TM_PlayerSaveData playerData1 = TM_SaveController.Instance.PlayerData_GetSaveFile(1);
        TM_PlayerSaveData playerData2 = TM_SaveController.Instance.PlayerData_GetSaveFile(2);
        TM_PlayerSaveData playerData3 = TM_SaveController.Instance.PlayerData_GetSaveFile(3);
        TM_PlayerSaveData playerData4 = TM_SaveController.Instance.PlayerData_GetSaveFile(4);
        TM_PlayerSaveData playerData5 = TM_SaveController.Instance.PlayerData_GetSaveFile(5);

        ////////////////////////////////

        //Save File 1
        if (playerData1 != null)
        {
            //Set Loaded Panels
            saveIcon1_NewSave_Panel.SetActive(false);
            saveIcon1_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon1_LoadSaveTitle_Text.text = playerData1.player_Name;
            saveIcon1_LoadSaveDesc_Text.text = "Level " + playerData1.player_Level;

            //Find Icon From Database
            saveIcon1_LoadIcon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(playerData1.player_Class);
        }
        else
        {
            //New Panel
            saveIcon1_NewSave_Panel.SetActive(true);
            saveIcon1_LoadSave_Panel.SetActive(false);
        }

        ////////////////////////////////

        //Save File 2
        if (playerData2 != null)
        {
            //Set Loaded Panels
            saveIcon2_NewSave_Panel.SetActive(false);
            saveIcon2_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon2_LoadSaveTitle_Text.text = playerData2.player_Name;
            saveIcon2_LoadSaveDesc_Text.text = "Level " + playerData2.player_Level;

            //Find Icon From Database
            saveIcon2_LoadIcon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(playerData2.player_Class);
        }
        else
        {
            //New Panel
            saveIcon2_NewSave_Panel.SetActive(true);
            saveIcon2_LoadSave_Panel.SetActive(false);
        }

        ////////////////////////////////

        //Save File 3
        if (playerData3 != null)
        {
            //Set Loaded Panels
            saveIcon3_NewSave_Panel.SetActive(false);
            saveIcon3_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon3_LoadSaveTitle_Text.text = playerData3.player_Name;
            saveIcon3_LoadSaveDesc_Text.text = "Level " + playerData3.player_Level;

            //Find Icon From Database
            saveIcon3_LoadIcon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(playerData3.player_Class);
        }
        else
        {
            //New Panel
            saveIcon3_NewSave_Panel.SetActive(true);
            saveIcon3_LoadSave_Panel.SetActive(false);
        }

        ////////////////////////////////

        //Save File 4
        if (playerData4 != null)
        {
            //Set Loaded Panels
            saveIcon4_NewSave_Panel.SetActive(false);
            saveIcon4_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon4_LoadSaveTitle_Text.text = playerData4.player_Name;
            saveIcon4_LoadSaveDesc_Text.text = "Level " + playerData4.player_Level;

            //Find Icon From Database
            saveIcon4_LoadIcon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(playerData4.player_Class);
        }
        else
        {
            //New Panel
            saveIcon4_NewSave_Panel.SetActive(true);
            saveIcon4_LoadSave_Panel.SetActive(false);
        }

        ////////////////////////////////

        //Save File 5
        if (playerData5 != null)
        {
            //Set Loaded Panels
            saveIcon5_NewSave_Panel.SetActive(false);
            saveIcon5_LoadSave_Panel.SetActive(true);

            //Load Info
            saveIcon5_LoadSaveTitle_Text.text = playerData5.player_Name;
            saveIcon5_LoadSaveDesc_Text.text = "Level " + playerData5.player_Level;

            //Find Icon From Database
            saveIcon5_LoadIcon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(playerData5.player_Class);
        }
        else
        {
            //New Panel
            saveIcon5_NewSave_Panel.SetActive(true);
            saveIcon5_LoadSave_Panel.SetActive(false);
        }
    }

    ///////////////////////////////////////////////////////

    private void NewSave_LoadPanel()
    {
        //Clear Text



        //Select Button
        Button_ClassSlot(newSave_ClassBrawlerButton);
        ButtonSelect_ClassSlot(newSave_ClassBrawlerButton);
    }

    ///////////////////////////////////////////////////////

    private void LoadSave_LoadPanel()
    {
        TM_PlayerSaveData currentPlayerSaveData = TM_SaveController.Instance.PlayerData_GetCurrentSaveFile();

        //Set Info
        charecterLoad_SaveSlot_Text.text = "Save Slot " + TM_SaveController.Instance.currentSaveSlotID;
        charecterLoad_Name_Text.text = currentPlayerSaveData.player_Name;
        charecterLoad_Level_Text.text = "Level " + currentPlayerSaveData.player_Level.ToString();

        charecterLoad_Notes_Text.text = "Notes - " + currentPlayerSaveData.player_Level.ToString() + " / 0";
        charecterLoad_Bosses_Text.text = "Bosses - " + currentPlayerSaveData.player_Level.ToString() + " / 0";
        charecterLoad_Time_Text.text = "Cycles - " + currentPlayerSaveData.player_Level.ToString();


        charecterLoad_STR_Text.text = "STR " + currentPlayerSaveData.player_CurrentStat_STR.ToString();
        charecterLoad_DEX_Text.text = "DEX " + currentPlayerSaveData.player_CurrentStat_DEX.ToString();
        charecterLoad_INT_Text.text = "INT " + currentPlayerSaveData.player_CurrentStat_INT.ToString();
        charecterLoad_CON_Text.text = "CON " + currentPlayerSaveData.player_CurrentStat_CON.ToString();

        //Find Icon From Database
        charecterLoad_Icon_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(currentPlayerSaveData.player_Class);


    }

    ///////////////////////////////////////////////////////
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject charecterNew_Panel;
    public GameObject charecterLoad_Panel;

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
        string SaveFile = "";


        switch (saveSlot)
        {
            case 1:

                SaveFile = "Save File Here!";

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;

            case 5:

                break;

            default:

                //Throw error for debugging
                throw new NotImplementedException("The requested action output is not valid.");

                break;
        }


        if (SaveFile == "")
        {
            //Use New charecter sheet
            charecterNew_Panel.SetActive(true);
            charecterLoad_Panel.SetActive(false);

            //Load Stats
        }
        else
        {
            //Use Load charecter sheet
            charecterNew_Panel.SetActive(false);
            charecterLoad_Panel.SetActive(true);

            //Load Stats
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
}

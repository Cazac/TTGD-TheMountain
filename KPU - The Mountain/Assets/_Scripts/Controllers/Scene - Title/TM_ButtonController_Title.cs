using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_ButtonController_Title is used the control the main buttons in the main menu of the game
/// 
/// </summary>
///////////////

public class TM_ButtonController_Title : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ButtonController_Title Instance;

    ////////////////////////////////

    public GameObject newGame_Panel;
    public GameObject loadGame_Panel;
    public GameObject settings_Panel;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public void Button_NewGame()
    {
        //Check if already opened
        if (newGame_Panel.activeSelf == true)
        {
            //Open Settings Panel
            newGame_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Open Settings Panel
            newGame_Panel.SetActive(true);
        }
    }

    public void Button_LoadGame()
    {
        //Check if already opened
        if (loadGame_Panel.activeSelf == true)
        {
            //Open Settings Panel
            loadGame_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels



            //Open Settings Panel
            loadGame_Panel.SetActive(true);
        }
    }

    public void Button_Settings()
    {
        //Check if already opened
        if (settings_Panel.activeSelf == true)
        {
            //Open Settings Panel
            settings_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Open Settings Panel
            settings_Panel.SetActive(true);
        }
    }

    public void Button_Credits()
    {
        //Load Credits Scene
        SceneManager.LoadScene("TM_Credits");
    }

    public void Button_Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

        //Quit Application
        Application.Quit();
    }

    /////////////////////////////////////////////////////////////////

    public void Button_SettingsConfirm()
    {

    }

    public void Button_SettingsBack()
    {

    }

    public void Slider_TotalVolume()
    {

    }

    /////////////////////////////////////////////////////////////////

    public void OpenConfirmDialog_Settings()
    {

    }

    public void OpenConfirmDialog_DeleteSave()
    {

    }

    /////////////////////////////////////////////////////////////////
}

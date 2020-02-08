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
    
    [Header("Panels")]
    public GameObject play_Panel;
    public GameObject settings_Panel;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public void Button_LoadGame()
    {
        //Check if already opened
        if (play_Panel.activeSelf == true)
        {
            //Open Settings Panel
            play_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels



            //Open Settings Panel
            play_Panel.SetActive(true);
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

            //newGame_Panel.SetActive(false);
            play_Panel.SetActive(false);

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Open Settings Panel
            settings_Panel.SetActive(true);

            //Open First Panel
            TM_ButtonController_Settings.Instance.Button_OpenPanel_KeyBinding();
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

    private void CloseAllPanels()
    {
        settings_Panel.SetActive(true);
        //newGame_Panel.SetActive(false);
        play_Panel.SetActive(false);
    }
 
    public void OpenConfirmDialog_DeleteSave()
    {

    }

    /////////////////////////////////////////////////////////////////
}

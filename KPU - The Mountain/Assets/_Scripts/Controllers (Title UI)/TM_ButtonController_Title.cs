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
    public GameObject notes_Panel;
    public GameObject morgue_Panel;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public void Button_Play()
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
            CloseAllPanels();

            //Open Settings Panel
            play_Panel.SetActive(true);

            //Select First Save Slot
            TM_ButtonController_Play.Instance.Setup();
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
            CloseAllPanels();

            //Open Settings Panel
            settings_Panel.SetActive(true);

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Select First Panel
            TM_ButtonController_Settings.Instance.Setup();
        }
    }

    public void Button_Notes()
    {
        //Check if already opened
        if (notes_Panel.activeSelf == true)
        {
            //Open Settings Panel
            notes_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels
            CloseAllPanels();

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Open Settings Panel
            notes_Panel.SetActive(true);

            //Open First Panel
          


        }
    }

    public void Button_Morgue()
    {
        //Check if already opened
        if (morgue_Panel.activeSelf == true)
        {
            //Open Settings Panel
            morgue_Panel.SetActive(false);
        }
        else
        {
            //Close All Other Panels
            CloseAllPanels();

            //Check if Settings Should Be Saved With A Confim Prompt? ???

            //Open Settings Panel
            morgue_Panel.SetActive(true);

            //Open First Panel
          


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
        play_Panel.SetActive(false);
        settings_Panel.SetActive(false);
        notes_Panel.SetActive(false);
        morgue_Panel.SetActive(false);
    }
 
    public void OpenConfirmDialog_DeleteSave()
    {

    }

    /////////////////////////////////////////////////////////////////
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_ButtonController_Settings
/// 
/// </summary>
///////////////

public class TM_ButtonController_Settings : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ButtonController_Settings Instance;

    ////////////////////////////////

    public GameObject settingsKeyBinding_Panel;
    public GameObject settingsSound_Panel;
    public GameObject settingsGraphics_Panel;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void Button_OpenPanel_KeyBinding()
    {
        //Check For Changed Settings in current panel before switching



        //Close Other Panels
        CloseAllPanels();

        //Open Panel
        settingsKeyBinding_Panel.SetActive(true);

        //Load Settings



    }

    public void Button_OpenPanel_Sound()
    {
        //Check For Changed Settings in current panel before switching



        //Close Other Panels
        CloseAllPanels();

        //Open Panel
        settingsSound_Panel.SetActive(true);

        //Load Settings



    }

    public void Button_OpenPanel_Graphics()
    {
        //Check For Changed Settings in current panel before switching



        //Close Other Panels
        CloseAllPanels();

        //Open Panel
        settingsGraphics_Panel.SetActive(true);

        //Load Settings



    }

    ///////////////////////////////////////////////////////

    public void Button_SettingsConfirm()
    {

    }

    public void Button_SettingsBack()
    {

    }

    ///////////////////////////////////////////////////////

    public void Slider_TotalVolume()
    {

    }


    public void OpenConfirmDialog_Settings()
    {

    }

    ///////////////////////////////////////////////////////

    public void CloseAllPanels()
    {
        //Close Panels
        settingsKeyBinding_Panel.SetActive(false);
        settingsSound_Panel.SetActive(false);
        settingsGraphics_Panel.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

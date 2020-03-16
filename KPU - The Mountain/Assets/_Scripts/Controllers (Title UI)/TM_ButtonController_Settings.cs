using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header("Buttons")]
    public GameObject settingsKeyBindingButton;
    public GameObject settingsSoundButton;
    public GameObject settingsGraphicsButton;

    [Header("Panels")]
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

    public void Setup()
    {
        //Open First Panel
        Button_OpenPanel_KeyBinding();
        ButtonSelect_PanelChange(settingsKeyBindingButton);
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

    public void ButtonSelect_PanelChange(GameObject panelButton_GO)
    {
        //Remove All Selections And Set To Netrual Colors
        settingsKeyBindingButton.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        settingsSoundButton.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        settingsGraphicsButton.GetComponent<Image>().color = new Color32(180, 180, 180, 255);

        panelButton_GO.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
    }

    ///////////////////////////////////////////////////////

    public void SliderChange_TotalVolume()
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

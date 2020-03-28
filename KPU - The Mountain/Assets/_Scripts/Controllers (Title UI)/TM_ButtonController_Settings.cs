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

    [Header("Audio Values")]
    public Slider settingsSound_TotalVolume_Slider;
    public Slider settingsSound_MusicVolume_Slider;
    public Slider settingsSound_AmbienceVolume_Slider;
    public Slider settingsSound_SFXVolume_Slider;

    public Toggle settingsSound_MusicMute_Toggle;
    public Toggle settingsSound_AmbienceMute_Toggle;
    public Toggle settingsSound_SFXMute_Toggle;

    [Header("Keybinding")]
    //Reference for the initial button text names
    public GameObject BindingInputs;


    public Button forward_Button;
    public Button backwards_Button;
    public Button left_Button;
    public Button right_Button;

    //Used OnClick() to hold a reference to button that is currently being changed
    private Button currentButton;

    //New key to be set
    KeyCode newKey;

    //Flag to wait for the key press
    bool waitingForKey = false;



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

        UpdateSettingsVisuals();
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

    ///////////////////////////////////////////////////////////////// - Sliders

    public void UpdateSettingsVisuals()
    {
        settingsSound_TotalVolume_Slider.value = TM_DatabaseController.Instance.settings_SaveData.volumeTotal;
        settingsSound_MusicVolume_Slider.value = TM_DatabaseController.Instance.settings_SaveData.volumeMusic;
        settingsSound_AmbienceVolume_Slider.value = TM_DatabaseController.Instance.settings_SaveData.volumeAmbience;
        settingsSound_SFXVolume_Slider.value = TM_DatabaseController.Instance.settings_SaveData.volumeSFX;

        settingsSound_MusicMute_Toggle.isOn = TM_DatabaseController.Instance.settings_SaveData.isMusicMute;
        settingsSound_AmbienceMute_Toggle.isOn = TM_DatabaseController.Instance.settings_SaveData.isAmbienceMute;
        settingsSound_SFXMute_Toggle.isOn = TM_DatabaseController.Instance.settings_SaveData.isSFXMute;
    }

    /////////////////////////////////////////////////////////////////

    public void SliderChange_TotalVolume()
    {
        //Update Database With Total
        TM_DatabaseController.Instance.settings_SaveData.volumeTotal = settingsSound_TotalVolume_Slider.value;

        //Update Controllers Current Audio Levels
        TM_MusicController.Instance.VolumeLevels_UpdateAll();
        TM_SFXController.Instance.VolumeLevels_UpdateAll();
        TM_AmbienceController.Instance.VolumeLevels_UpdateAll();
    }

    public void SliderChange_MusicVolume()
    {
        //Update Database With Music
        TM_DatabaseController.Instance.settings_SaveData.volumeMusic = settingsSound_MusicVolume_Slider.value;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_MusicController.Instance.VolumeLevels_UpdateAll();
    }

    public void SliderChange_AmbienceVolume()
    {
        //Update Database With Ambience
        TM_DatabaseController.Instance.settings_SaveData.volumeAmbience = settingsSound_AmbienceVolume_Slider.value;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_AmbienceController.Instance.VolumeLevels_UpdateAll();
    }

    public void SliderChange_SFXVolume()
    {
        //Update Database With SFX
        TM_DatabaseController.Instance.settings_SaveData.volumeSFX = settingsSound_SFXVolume_Slider.value;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_SFXController.Instance.VolumeLevels_UpdateAll();
    }

    ///////////////////////////////////////////////////////////////// - Toggles

    public void ToggleChange_MuteMusic(Toggle toggle)
    {
        //Update Database
        TM_DatabaseController.Instance.settings_SaveData.isMusicMute = toggle.isOn;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_MusicController.Instance.VolumeLevels_UpdateAll();
    }

    public void ToggleChange_MuteAmbience(Toggle toggle)
    {
        //Update Database
        TM_DatabaseController.Instance.settings_SaveData.isAmbienceMute = toggle.isOn;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_AmbienceController.Instance.VolumeLevels_UpdateAll();
    }

    public void ToggleChange_MuteSFX(Toggle toggle)
    {
        //Update Database
        TM_DatabaseController.Instance.settings_SaveData.isSFXMute = toggle.isOn;
        TM_SaveController.Instance.SettingsData_SaveFile(TM_DatabaseController.Instance.settings_SaveData);

        //Update Controllers Current Audio Levels
        TM_SFXController.Instance.VolumeLevels_UpdateAll();
    }

    ///////////////////////////////////////////////////////


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

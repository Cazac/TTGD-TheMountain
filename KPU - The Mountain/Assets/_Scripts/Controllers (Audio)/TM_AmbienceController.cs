using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_AmbienceController is the audio controller for the ambience sound in the game.
/// 
/// WORK IN PROGRESS NOT CURRENTLY ACTIVE
/// 
/// 
/// </summary>
///////////////

public class TM_AmbienceController : MonoBehaviour
{
    //////////////////////////////// - Singleton Refference

    public static TM_AmbienceController Instance;

    ////////////////////////////////

    [Header("Container")]
    public GameObject ambienceTrack_Container;

    [Header("Prefab")]
    public GameObject ambienceTrack_Prefab;

    ////////////////////////////////

    [Header("Current Scene")]
    private bool isTitleScene;
    private bool isGameScene;
    private bool isCreditsScene;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Self Refference Singleton
        Instance = this;
    }

    private void Start()
    {
        //Setup
        GetSceneSetupAmbience();
    }

    /////////////////////////////////////////////////////////////////

    private void GetSceneSetupAmbience()
    {
        //Get Name Of Current Scene
        string currentScene = SceneManager.GetActiveScene().name;

        //Check the type by scene
        if (currentScene == "TM_Title")
        {
            isTitleScene = true;
        }
        else if (currentScene == "TM_Zac's Systems Room" || currentScene == "TM_Game")
        {
            isGameScene = true;
        }
        else if (currentScene == "TM_Credits")
        {
            isCreditsScene = true;
        }
    }

    /////////////////////////////////////////////////////////////////

    public void PlayTrackAmbience(TM_Audio_SO audioSO, GameObject locationalParent)
    {
        //Instantiate New Audio Source At Location
        GameObject newAmbienceTrack = Instantiate(ambienceTrack_Prefab, locationalParent.transform);

        //Ambience Setup
        newAmbienceTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO, 1, TM_DatabaseController.Instance.settings_SaveData.volumeAmbience, TM_DatabaseController.Instance.settings_SaveData.isAmbienceMute);
    }

    public void PlayTrackAmbience(TM_Audio_SO audioSO)
    {
        //Instantiate New Audio Source Unser Container
        GameObject newAmbienceTrack = Instantiate(ambienceTrack_Prefab, ambienceTrack_Container.transform);

        //Ambience Setup
        newAmbienceTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO, 0, TM_DatabaseController.Instance.settings_SaveData.volumeAmbience, TM_DatabaseController.Instance.settings_SaveData.isAmbienceMute);
    }

    /////////////////////////////////////////////////////////////////

    public void StopTrackAmbience_Single(GameObject audioTrack)
    {

    }

    public void StopTrackAmbience_All()
    {
        //Loop all Tabs
        foreach (Transform child in ambienceTrack_Container.transform)
        {
            //Get Tab
            TM_AudioTab audioTab = child.gameObject.GetComponent<TM_AudioTab>();

            //Fade Out Or Destory
            if (audioTab.currentAudio_SO.canFadeOut)
            {
                StartCoroutine(audioTab.AudioVolumeDampeningOnDestory(audioTab.currentAudio_SO.fadeOutSpeed));
            }
            else
            {
                audioTab.DestoryAudio();
            }
        }
    }

    /////////////////////////////////////////////////////////////////

    public void VolumeLevels_UpdateAll()
    {
        //Loop All Current Ambience Tracks
        foreach (Transform child in ambienceTrack_Container.transform)
        {
            //Get Tab
            TM_AudioTab audioTab = child.gameObject.GetComponent<TM_AudioTab>();

            //Set Volume
            if (TM_DatabaseController.Instance.settings_SaveData.isAmbienceMute)
            {
                //Mute
                audioTab.audioSource.volume = 0;
            }
            else
            {
                //Update Volume
                float volumeMutiplyer = TM_DatabaseController.Instance.settings_SaveData.volumeTotal * TM_DatabaseController.Instance.settings_SaveData.volumeAmbience;
                audioTab.audioSource.volume = (audioTab.currentAudio_SO.volume * volumeMutiplyer);
            }
        }
    }

    /////////////////////////////////////////////////////////////////

    public void PlayTrack_ButtonHover()
    {
        //PlayTrack_SFX(database, null);
    }

    public void PlaySFX_ButtonClick()
    {
        //PlayTrack_SFX(database, null);
    }

    public void PlaySFX_ButtonBack()
    {
        //PlayTrack_SFX(database, null);
    }

    /////////////////////////////////////////////////////////////////
}
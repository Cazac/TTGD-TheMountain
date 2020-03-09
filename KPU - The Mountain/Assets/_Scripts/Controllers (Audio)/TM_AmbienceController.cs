using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //Spawn SFX
        GameObject newAmbienceTrack;

        //Sort By Location Parent
        if (locationalParent == null)
        {
            //Instantiate New Audio Source Unser Container
            newAmbienceTrack = Instantiate(ambienceTrack_Prefab, ambienceTrack_Container.transform);
        }
        else
        {
            //Instantiate New Audio Source At Location
            newAmbienceTrack = Instantiate(ambienceTrack_Prefab, locationalParent.transform);
        }

        //SFX Setup
        newAmbienceTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO);
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
        //Loop All Current Music Tracks
        foreach (Transform child in ambienceTrack_Container.transform)
        {
            //ReQUIRES SETTINGS DATABSE MUTING


            /*
            //Get Tab
            TM_AudioTab sfxTab = child.gameObject.GetComponent<TM_AudioTab>();

            //Set Volume
            if (TC_DatabaseController.Instance.player_DB.settings.isSFXMute)
            {
                sfxTab.audioSource.volume = 0;
            }
            else
            {
                float volumeMutiplyer = TC_DatabaseController.Instance.player_DB.settings.volumeTotal * TC_DatabaseController.Instance.player_DB.settings.volumeSFX;
                sfxTab.audioSource.volume = (sfxTab.audioSource.volume * volumeMutiplyer);
            }
            */
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
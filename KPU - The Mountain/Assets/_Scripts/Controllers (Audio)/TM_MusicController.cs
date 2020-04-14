using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_CreditsController controls the credits sequence at the end of the game or though the menu.
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_MusicController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_MusicController Instance;

    ////////////////////////////////

    [Header("Prefabs")]
    public GameObject musicTrack_Prefab;

    [Header("Containers")]
    public GameObject musicTrack_Container;

    ////////////////////////////////




    public GameObject currentMusicRange_GO;


    [Header("Current Scene")]
    private bool isTitleScene;
    private bool isGameScene;
    private bool isCreditsScene;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        //Setup
        GetSceneSetupMusic();
    }

    ///////////////////////////////////////////////////////

    private void GetSceneSetupMusic()
    {
        //Get Name Of Current Scene
        string currentScene = SceneManager.GetActiveScene().name;

        //Check the type by scene
        if (currentScene == "TM_Title")
        {
            isTitleScene = true;
            PlayMusic_TitleMain();
        }
        else if (currentScene == "TM_Zac's Systems Room" || currentScene == "TM_Game")
        {
            isGameScene = true;
        }
        else if (currentScene == "TM_Credits")
        {
            isCreditsScene = true;
            PlayMusic_Credits();
        }
    }

    /////////////////////////////////////////////////////////////////

    public void PlayTrackMusic(TM_Audio_SO audioSO, GameObject locationalParent)
    {
        //Stop Other Music
        StopTrackMusic_All();

        //Instantiate New Audio Source At Location
        GameObject newSFXTrack = Instantiate(musicTrack_Prefab, locationalParent.transform);

        //Music Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO, 1, TM_DatabaseController.Instance.settings_SaveData.volumeMusic, TM_DatabaseController.Instance.settings_SaveData.isMusicMute);
    }


    public void PlayTrackMusic(TM_Audio_SO audioSO)
    {
        //Stop Other Music
        StopTrackMusic_All();

        //Instantiate New Audio Source User Container
        GameObject newSFXTrack = Instantiate(musicTrack_Prefab, musicTrack_Container.transform);

        //Music Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO, 0, TM_DatabaseController.Instance.settings_SaveData.volumeMusic, TM_DatabaseController.Instance.settings_SaveData.isMusicMute);
    }

    /////////////////////////////////////////////////////////////////

    public void StopTrackMusic_Single(GameObject audioTrack)
    {

    }

    public void StopTrackMusic_All()
    {
        //Loop all Tabs
        foreach (Transform child in musicTrack_Container.transform)
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
        foreach (Transform child in musicTrack_Container.transform)
        {
            //Get Music Tab
            TM_AudioTab audioTab = child.gameObject.GetComponent<TM_AudioTab>();

            //Set Volume
            if (TM_DatabaseController.Instance.settings_SaveData.isMusicMute)
            {
                audioTab.audioSource.volume = 0;
            }
            else
            {
                float volumeMutiplyer = TM_DatabaseController.Instance.settings_SaveData.volumeTotal * TM_DatabaseController.Instance.settings_SaveData.volumeMusic;
                audioTab.audioSource.volume = (audioTab.currentAudio_SO.volume * volumeMutiplyer);
            }
        }
    }

    ///////////////////////////////////////////////////////////////// - Starting Music 

    public void PlayMusic_TitleMain()
    {
        //Get Clip
        PlayTrackMusic(TM_DatabaseController.Instance.music_DB.titleMainTheme_Music, null);
    }

    public void PlayMusic_Credits()
    {
        //Get Clip
        PlayTrackMusic(TM_DatabaseController.Instance.music_DB.creditsMusic_MainTheme, null);
    }

    /////////////////////////////////////////////////////////////////
}

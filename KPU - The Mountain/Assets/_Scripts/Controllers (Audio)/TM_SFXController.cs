using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TM_SFXController : MonoBehaviour
{
    //////////////////////////////// - Singleton Refference

    public static TM_SFXController Instance;

    ////////////////////////////////

    [Header("Container")]
    public GameObject sfxTrack_Container;

    [Header("Prefab")]
    public GameObject sfxTrack_Prefab;

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
        GetSceneSetupSFX();
    }

    /////////////////////////////////////////////////////////////////

    private void GetSceneSetupSFX()
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

    public void PlayTrackSFX(TM_Audio_SO audioSO, GameObject locationalParent)
    {
        //Spawn SFX
        GameObject newSFXTrack;

        //Instantiate New Audio Source At Location
        newSFXTrack = Instantiate(sfxTrack_Prefab, locationalParent.transform);

        //SFX Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO);
    }

    public void PlayTrackSFX(TM_Audio_SO audioSO)
    {
        print("Test Code: Play");

        //Spawn SFX
        GameObject newSFXTrack;

        //Instantiate New Audio Source Unser Container
        newSFXTrack = Instantiate(sfxTrack_Prefab, sfxTrack_Container.transform);

        //SFX Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO);
    }

    /////////////////////////////////////////////////////////////////

    public void PlayTrackSFX(List<TM_Audio_SO> audioSO_List, GameObject locationalParent)
    {
        //Spawn SFX
        GameObject newSFXTrack;

        //Instantiate New Audio Source At Location
        newSFXTrack = Instantiate(sfxTrack_Prefab, locationalParent.transform);

        //Random Choice
        int randomChoice = Random.Range(0, audioSO_List.Count);

        //SFX Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO_List[randomChoice]);
    }

    public void PlayTrackSFX(List<TM_Audio_SO> audioSO_List)
    {
        //Spawn SFX
        GameObject newSFXTrack;

        //Instantiate New Audio Source Unser Container
        newSFXTrack = Instantiate(sfxTrack_Prefab, sfxTrack_Container.transform);

        //Random Choice
        int randomChoice = Random.Range(0, audioSO_List.Count);

        //SFX Setup
        newSFXTrack.GetComponent<TM_AudioTab>().SetupAudioTrack(audioSO_List[randomChoice]);
    }

    /////////////////////////////////////////////////////////////////

    public void StopTrackSFX_Single(GameObject audioTrack)
    {

    }

    public void StopTrackSFX_All()
    {
        //Loop all Tabs
        foreach (Transform child in sfxTrack_Container.transform)
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
        //Loop All Current SFX Tracks
        foreach (Transform child in sfxTrack_Container.transform)
        {
            //Get Tab
            TM_AudioTab audioTab = child.gameObject.GetComponent<TM_AudioTab>();

            //Set Volume
            if (TM_DatabaseController.Instance.settings_SaveData.isSFXMute)
            {
                //Mute
                audioTab.audioSource.volume = 0;
            }
            else
            {
                //Update Volume
                float volumeMutiplyer = TM_DatabaseController.Instance.settings_SaveData.volumeTotal * TM_DatabaseController.Instance.settings_SaveData.volumeSFX;
                audioTab.audioSource.volume = (audioTab.currentAudio_SO.volume * volumeMutiplyer);
            }
        }
    }

    /////////////////////////////////////////////////////////////////
}

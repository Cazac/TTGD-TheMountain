using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_SoundManager 
/// 
/// </summary>
///////////////

public class TM_SoundManager : MonoBehaviour
{
    ////////////////////////////////

    [Header("SFX Prefab")]
    public GameObject SFXPrefab;

    [Header("SFX Parent")]
    public GameObject SFXParent;

    public AudioSource mainAudioSourceSoundtrack;
    public AudioSource mainAudioSourceUI;
    public bool IsMuteSoundtrack { get; set; }
    public bool IsMuteUI { get; set; }

    public bool ReturnControl { get => autoControl; set => autoControl = value; }


    public TM_SoundObject[] soundClips;
    //private List<GameObject> uiGeneratedSounds = new List<GameObject>();

    private AudioClip currentClip;
    private bool triggerOnLevelLoad = false;
    private bool autoControl = true;

    /////////////////////////////////////////////////////////////////

    private void AutoDestroySelf()
    {
        if (GameObject.FindObjectsOfType<TM_SoundManager>().Length > 1)
        {
            DestroyImmediate(this.gameObject);
            //this.GetComponent<AudioSource>().clip = null;
        }
    }

    /////////////////////////////////////////////////////////////////

    private void Update()
    {

        if (triggerOnLevelLoad)
        {
            LoopThroughSoundList(soundClips);
            triggerOnLevelLoad = false;
        }

        if (!mainAudioSourceSoundtrack.GetComponent<AudioSource>().isPlaying/* && autoControl*/)
        {
            LoopThroughSoundList(soundClips);
        }

        //if (!autoControl)
        //{
        //    LoopThroughSoundList(soundClips);
        //    autoControl = true;
        //}
   

        //if (waveManager!=null && waveManager.EnableSpawning == false)
        //    autoControl = false;
        //else
        //    autoControl = true;
    }

    public void PlaySpecificSound(String soundName)
    {
        foreach (var clip in soundClips)
        {
            if (clip.SoundName.Contains(soundName))
            {
                PlaySoundByObject(clip);
            }
        }
    }

    public void PlayOnUIClick(TM_SoundObject clip, float pitchRange)
    {
 
        GameObject newSFX = Instantiate(SFXPrefab, SFXParent.transform);

        newSFX.GetComponent<AudioSource>().clip = clip.AudioClip;
        newSFX.GetComponent<AudioSource>().pitch = 1 + (UnityEngine.Random.Range(-pitchRange, pitchRange));
        newSFX.GetComponent<AudioSource>().volume = mainAudioSourceUI.volume;
        newSFX.GetComponent<AudioSource>().Play();

        //Setup Auto Destruct
       // newSFX.GetComponent<SelfDestruct>().Setup(clip.AudioClip.length);


        /*
        if (mainAudioSourceUI.GetComponent<AudioSource>().isPlaying)
        {
            mainAudioSourceUI.clip = null;
        }

        mainAudioSourceUI.clip = clip.AudioClip;
        mainAudioSourceUI.Play();

        */
    }

    private void LoopThroughSoundList(TM_SoundObject[] clips)
    {
        foreach (var clip in clips)
        {
            if (clip.SoundName.Contains("Menu") && SceneManager.GetActiveScene().name.Contains("Menu") && autoControl)
            {
                PlaySoundByObject(clip);
            }

            if (clip.SoundName.Contains("Game") && SceneManager.GetActiveScene().name.Contains("Game") && autoControl)
            {
                PlaySoundByObject(clip);
            }

            if(clip.SoundName.Contains("Inter") && !autoControl)
            {
                PlaySoundByObject(clip);
            }
        }
    }

    public void PlaySoundByObject(TM_SoundObject audioClip)
    {
        //Set default value from SoundObject
        mainAudioSourceSoundtrack.clip = audioClip.AudioClip;
        mainAudioSourceSoundtrack.pitch = audioClip.Pitch;
        mainAudioSourceSoundtrack.loop = true;
        mainAudioSourceSoundtrack.Play();

        //Begin lerping volume of sound
        if (audioClip.IsAllowedAudioDampening == true)
        {
            //Debug.Log("Volume Dampening????");
            StartCoroutine(AudioVolumeDampeningOnLoad(mainAudioSourceSoundtrack, 0.1f, mainAudioSourceSoundtrack.volume, 0.25f));
        }
    }

    private IEnumerator AudioVolumeDampeningOnLoad(AudioSource audioSource, float smallestLerpValue, float initialVolumeValue, float lerpTime)
    {
        audioSource.volume = smallestLerpValue;

      

        while (audioSource.volume < initialVolumeValue)
        {
            if (audioSource.volume >= initialVolumeValue)
            {
                audioSource.volume = initialVolumeValue;
                //Debug.Log("Coroutine stopped");
                StopCoroutine(AudioVolumeDampeningOnLoad(audioSource, smallestLerpValue, initialVolumeValue, lerpTime));
            }


            if (Time.timeScale == 1)
            {
                audioSource.volume += lerpTime * Time.deltaTime;
            }
            else
            {
                audioSource.volume += lerpTime * 0.02f;
            }

            yield return 0.1f;
        }

       
    }

    /////////////////////////////////////////////////////////////////

    public void VolumeChangeSoundtrack(Slider slider)
    {
        mainAudioSourceSoundtrack.volume = slider.value;
    }

    public void VolumeChangeUI(Slider slider)
    {
        mainAudioSourceUI.volume = slider.value;
    }

    /////////////////////////////////////////////////////////////////

    public void MuteUI()
    {
        if (IsMuteUI)
        {
            IsMuteUI = false;
        }

        else
        {
            IsMuteUI = true;
        }
        mainAudioSourceUI.mute = IsMuteUI;
    }

    public void MuteSoundtrack()
    {

        if (IsMuteSoundtrack)
        {
            IsMuteSoundtrack = false;
        }
        else
        {
            IsMuteSoundtrack = true;
        }

        mainAudioSourceSoundtrack.mute = IsMuteSoundtrack;
    }

    /////////////////////////////////////////////////////////////////
}


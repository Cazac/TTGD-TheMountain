﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_AudioTab
/// 
/// TAB CLASS 
/// 
/// 
/// </summary>
///////////////

public class TM_AudioTab : MonoBehaviour
{
    ////////////////////////////////

    [Header("Audio Source")]
    public AudioSource audioSource;

    ////////////////////////////////

    [Header("Options")] 
    public TM_Audio_SO currentAudio_SO;

    /////////////////////////////////////////////////////////////////

    public void SetupAudioTrack(TM_Audio_SO audioSO, float spatialBlending, float specficTypeVolume, bool isMuted)
    {
        //Save Scriptable 
        currentAudio_SO = audioSO;

        //Settings
        audioSource.clip = audioSO.audioClip;
        audioSource.loop = audioSO.canLoop;
        audioSource.pitch = audioSO.pitch + (Random.Range(-audioSO.pitchRange, audioSO.pitchRange));
        audioSource.spatialBlend = spatialBlending;
        audioSource.volume = currentAudio_SO.volume;


        //A PROBLEM FOR ANOTHER TIME

        //Volume
        //if (isMuted)
        {
            //audioSource.volume = 0;
        }
       // else
        {
            //float volumeMutiplyer = TM_DatabaseController.Instance.settings_SaveData.volumeTotal * specficTypeVolume;
           // print("Test Code: " + currentAudio_SO.volume * volumeMutiplyer);
           // audioSource.volume = (currentAudio_SO.volume * volumeMutiplyer);
        }

        //Play Audio
        audioSource.Play();

        //Begin lerping volume of sound
        if (audioSO.canFadeIn == true)
        {
            //Begin lerping volume of sound
            StartCoroutine(AudioVolumeDampeningOnLoad((audioSource.volume / 60), audioSource.volume, currentAudio_SO.fadeInSpeed));
        }

        //Begin Audio Destruction Countdown
        if (audioSO.canLoop == false)
        {
            //Begin Audio Destruction Countdown
            StartCoroutine(AutoDestoryCountdown(currentAudio_SO.audioClip.length));
        }
    }

    /////////////////////////////////////////////////////////////////

    public IEnumerator AudioVolumeDampeningOnLoad(float startVolume, float finalVolume, float volumeRampUpSpeed)
    {
        //Set Default Value
        audioSource.volume = startVolume;

        //Loop Enum Til the max is hit
        while (audioSource.volume < finalVolume)
        {
            //Increase Volume Per Frame
            audioSource.volume += Time.deltaTime * volumeRampUpSpeed;

            if (audioSource.volume >= finalVolume)
            {
                //Max Out Volume and Break Enum
                audioSource.volume = finalVolume;
                yield return null;
            }

            //Wait For Next Frame
            yield return new WaitForEndOfFrame();
        }

        //Max Out Volume and Break Enum
        audioSource.volume = finalVolume;
        yield return null;
    }

    public IEnumerator AudioVolumeDampeningOnDestory(float volumeRampDownSpeed)
    {
        //Loop Enum Til the max is hit
        while (audioSource.volume > 0)
        {
            //Increase Volume Per Frame
            audioSource.volume -= Time.deltaTime * volumeRampDownSpeed;

            if (audioSource.volume <= 0)
            {
                //Max Out Volume and Break Enum
                audioSource.volume = 0;
                DestoryAudio();
                yield break;
            }

            //Wait For Next Frame
            yield return new WaitForEndOfFrame();
        }

        //Max Out Volume and Break Enum
        audioSource.volume = 0;
        DestoryAudio();
        yield break;
    }

    /////////////////////////////////////////////////////////////////

    private IEnumerator AutoDestoryCountdown(float clipLength)
    {
        //Wait Till Clip is over + buffer room
        yield return new WaitForSeconds(clipLength + 0.1f);

        //Destory Clip
        DestoryAudio();

        //Break Out
        yield break;
    }

    /////////////////////////////////////////////////////////////////

    public void DestoryAudio()
    {
        //Destory Clip
        Destroy(gameObject);
    }

    /////////////////////////////////////////////////////////////////
}
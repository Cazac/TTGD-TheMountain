using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_MusicTab
/// 
/// TAB CLASS 
/// 
/// 
/// </summary>
///////////////

public class TM_MusicTab : MonoBehaviour
{
    ////////////////////////////////

    [Header("Audio Source")]
    public AudioSource musicAudioSource;

    ////////////////////////////////

    [Header("Options")]
    public bool isAllowedLooping;
    public bool isAllowedProximity;
    public bool isAllowedAutoDestruct;
    public bool isAllowedAudioDampening;

    /////////////////////////////////////////////////////////////////

    public void SetupMusicTrack(TM_Music_SO musicSO)
    {
        musicAudioSource.clip = musicSO.audioClip;
        musicAudioSource.volume = musicSO.volume;
        musicAudioSource.pitch = musicSO.pitch;
        musicAudioSource.loop = musicSO.isAllowedLooping;

        musicAudioSource.Play();

        //musicAudioSource.clip = musicSO.audioClip;
        //musicAudioSource.clip = musicSO.audioClip;
        //musicAudioSource.clip = musicSO.audioClip;


        /*
        SoundName = soundName;
        AudioClip = audioClip;
        Volume = volume;
        Pitch = pitch;
        IsAllowedLooping = isAllowedLooping;
        IsAllowedAutoDestruct = isAllowedAutoDestruct;
        IsAllowedAudioDampening = isAllowedAudioDampening;
        */



        //Begin lerping volume of sound
        if (musicSO.isAllowedAudioDampening == true)
        {
            //Debug.Log("Volume Dampening????");
            StartCoroutine(AudioVolumeDampeningOnLoad((musicSO.volume / 60), musicSO.volume, 0.1f));
        }
    }

    private IEnumerator AudioVolumeDampeningOnLoad(float startVolume, float finalVolume, float volumeRampUpSpeed)
    {
        //Set Default Value
        musicAudioSource.volume = startVolume;

        //Loop Enum Til the max is hit
        while (musicAudioSource.volume < finalVolume)
        {
            //Increase Volume Per Frame
            musicAudioSource.volume += Time.deltaTime * volumeRampUpSpeed;

            if (musicAudioSource.volume >= finalVolume)
            {
                //Max Out Volume and Break Enum
                musicAudioSource.volume = finalVolume;
                yield return null;
            }

            //Wait For Next Frame
            yield return new WaitForEndOfFrame();
        }

        //Max Out Volume and Break Enum
        musicAudioSource.volume = finalVolume;
        yield return null;
    }

    /////////////////////////////////////////////////////////////////
}

using System;
using System.Collections;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_SoundObject 
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "SoundObject", menuName = "Scriptable Objects/Sound Object")]
public class TM_SoundObject : ScriptableObject
{
    ////////////////////////////////

    public string SoundName;
    public AudioClip AudioClip;
    public float Volume;
    public float Pitch;
    public Boolean IsAllowedLooping;
    public Boolean IsAllowedAutoDestruct;
    public Boolean IsAllowedAudioDampening;

    /////////////////////////////////////////////////////////////////

    public TM_SoundObject(string soundName, AudioClip audioClip, float volume, float pitch, bool isAllowedLooping, bool isAllowedAutoDestruct, bool isAllowedAudioDampening)
    {
        SoundName = soundName;
        AudioClip = audioClip;
        Volume = volume;
        Pitch = pitch;
        IsAllowedLooping = isAllowedLooping;
        IsAllowedAutoDestruct = isAllowedAutoDestruct;
        IsAllowedAudioDampening = isAllowedAudioDampening;
    }

    public TM_SoundObject()
    {

    }

    public void PlayClip(AudioSource audioSource)
    {
        audioSource.Play();
    }

    /////////////////////////////////////////////////////////////////
}

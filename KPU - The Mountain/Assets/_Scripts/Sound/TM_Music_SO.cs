using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Music", menuName = "Scriptables/New Music")]
public class TM_Music_SO : ScriptableObject
{
    ////////////////////////////////
    
    [Header("Clip")]
    public AudioClip audioClip;

    ////////////////////////////////

    [Header("Info")]
    public string musicName;
    public float volume;
    public float pitch;

    ////////////////////////////////

    [Header("Options")]
    public bool isAllowedLooping;
    public bool isAllowedProximity;
    public bool isAllowedAutoDestruct;
    public bool isAllowedAudioDampening;

    /////////////////////////////////////////////////////////////////
}

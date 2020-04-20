using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Audio_SO creates the Scriptable Objects for audio files used in both SFX and Music.
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Audio", menuName = "Scriptables/New Audio")]
public class TM_Audio_SO : ScriptableObject
{
    ////////////////////////////////
    
    [Header("Clip")]
    public AudioClip audioClip;

    ////////////////////////////////

    [Header("Settngs - Volume")]
    public float volume;

    [Header("Settngs - Pitch")]
    public float pitch;
    [Range(0, 5)]
    public float pitchRange;

    ////////////////////////////////

    [Header("Settngs - Looping")]
    public bool canLoop;

    [Header("Settngs - Fade In")]
    public bool canFadeIn;
    [Range(0, 3)]
    public float fadeInSpeed;

    [Header("Settngs - Fade Out")]
    public bool canFadeOut;
    [Range(0, 3)]
    public float fadeOutSpeed;

    /////////////////////////////////////////////////////////////////
}

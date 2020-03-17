using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TM_SettingsSaveData
{
    //////////////////////////////// - Audio

    [Header("Volume Values")]
    public float volumeTotal;
    public float volumeMusic;
    public float volumeAmbience;
    public float volumeSFX;

    [Header("Mute Values")]
    public bool isMusicMute;
    public bool isAmbienceMute;
    public bool isSFXMute;

    [Header("Mute Values")]
    public KeyCode keycode_MoveForward;
    public KeyCode keycode_MoveBackward;
    public KeyCode keycode_MoveLeft;
    public KeyCode keycode_MoveRight;







    /////////////////////////////////////////////////////////////////
}

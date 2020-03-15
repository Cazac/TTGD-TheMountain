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

    ////////////////////////////////

    //Graphics and Textures
    public int graphicRenderDistance;
    public int graphicTextureSize;

    ////////////////////////////////

    //Monitor and Display
    public int displayType;
    public int displaySize;

    ////////////////////////////////

    //Input
    public bool allowMouseInput;
    public bool allowDataCollection;

    /////////////////////////////////////////////////////////////////
}

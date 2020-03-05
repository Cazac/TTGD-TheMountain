using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_SFXData stores the sound effect data for the project as prebuilt sound objects ready for spawning.
/// 
/// DATA CLASS 
/// Data classes are used to store data under the TM_DatabaseController for better sorting
/// 
/// </summary>
///////////////

public class TM_SFXData : MonoBehaviour
{
    ////////////////////////////////

    [Header("General Use SFX")]
    public TM_SFXData buttonGeneralClick_SFX;
    public TM_SFXData buttonGeneralHover_SFX;
    public TM_SFXData buttonBack_SFX;

    public TM_SFXData buttonPurchase_SFX;
    public TM_SFXData buttonStats_SFX;

    [Header("End Turn SFX")]
    public TM_SFXData endTurnRoman_SFX;
    public TM_SFXData endTurnGreek_SFX;
    public TM_SFXData endTurnPersian_SFX;

    [Header("Bird SFX")]
    public TM_SFXData multiBird_SFX;
    public TM_SFXData sparrow_SFX;
    public TM_SFXData hawk_SFX;
    public TM_SFXData woodpecker_SFX;

    [Header("Amibient SFX")]
    public TM_SFXData amibientWind_SFX;

    [Header("Music Audio Source")]
    public AudioSource musicManager_AS;
    public AudioSource SFXManager_AS;

    [Header("SFX Audio Prefab")]
    public GameObject SFXPrefab;

    [Header("SFX Audio Prefab")]
    public GameObject soundParent;

    ////////////////////////////////
}

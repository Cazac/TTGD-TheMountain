using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_MusicData stores the music data for the project as prebuilt sound objects ready for spawning.
/// 
/// DATA CLASS 
/// Data classes are used to store data under the TM_DatabaseController for better sorting
/// 
/// </summary>
///////////////

public class TM_MusicData : MonoBehaviour
{
    ////////////////////////////////

    [Header("Boss Music")]
    public TM_Music_SO bossMusic_Minotaur;


    [Header("Credits Music")]
    public TM_Music_SO creditsMusic_MainTheme;


    [Header("Title Music")]
    public TM_Music_SO titleMusic_MainTheme;


    ////////////////////////////////
}
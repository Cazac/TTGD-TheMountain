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

    [Header("Title Music")]
    public TM_Audio_SO titleMainTheme_Music;
    //public TM_Audio_SO titleOtherTheme1_Music;

    ////////////////////////////////

    [Header("Credits Music")]
    public TM_Audio_SO creditsMusic_MainTheme;

    ////////////////////////////////

    [Header("Boss Music")]
   // public TM_Audio_SO bossMusic_Minotaur;

    ////////////////////////////////

    [Header("Combat Music")]
    //public TM_Audio_SO combatMusic_Theme1;

    ////////////////////////////////

    [Header("Home Music")]
    public TM_Audio_SO homeMusic_Theme1;
    public TM_Audio_SO homeMusic_Theme2;
    public TM_Audio_SO homeMusic_Theme3;

    ////////////////////////////////

    [Header("Death Music")]
    public TM_Audio_SO deathMusic_Theme1;

    ////////////////////////////////

    [Header("Exploring Music - Singles")]
    public TM_Audio_SO exploringMusic_Theme1;
    public TM_Audio_SO exploringMusic_Theme2;
    public TM_Audio_SO exploringMusic_Theme3;
    public TM_Audio_SO exploringMusic_Theme4;

    ////////////////////////////////


    ///////////////////////////////////////////////////////

    public void BuildDatabase_Lists()
    {

    }

    ///////////////////////////////////////////////////////
}
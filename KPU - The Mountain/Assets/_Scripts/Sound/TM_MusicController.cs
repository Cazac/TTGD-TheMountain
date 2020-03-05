using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_CreditsController controls the credits sequence at the end of the game or though the menu.
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_MusicController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_MusicController Instance;

    ////////////////////////////////

    [Header("Prefabs")]
    public GameObject musicTrack_Prefab;

    [Header("Containers")]
    public GameObject musicTrack_Container;

    ////////////////////////////////

    [Header("Current Tracks")]
    public List<GameObject> currentMusicTracks;

    ////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void PlayMusicTrack(TM_Music_SO musicSO)
    {
        //Stop Other Music

        //Spawn Music
        GameObject newMusicTrack = Instantiate(musicTrack_Prefab, musicTrack_Container.transform);

        //Music Setup
        newMusicTrack.GetComponent<TM_MusicTab>().SetupMusicTrack(musicSO);


        //Set Proximity


        //Reset Other Tracks


        //Add To List


        //Set TTL

    }

    public void StopMusicTrack(GameObject musicTrack_GO)
    {

    }

    ///////////////////////////////////////////////////////
}

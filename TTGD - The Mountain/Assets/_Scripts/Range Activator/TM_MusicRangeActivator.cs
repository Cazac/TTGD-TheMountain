using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_MusicRangeActivator : MonoBehaviour
{
    public List<TM_Audio_SO> musicOnActivate_List;
    private bool canPlayMusic;
    public bool isOneTimeUse;

    private void Awake()
    {
        canPlayMusic = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<TM_PlayerController_Movement>() != null)
        {
            if (TM_MusicController.Instance.currentMusicRange_GO == gameObject)
            {
                //This Range Activator is already playing here
                return;
            }


            if (canPlayMusic == true)
            {
  
               
                int randomChoice = Random.Range(0, musicOnActivate_List.Count);
                TM_MusicController.Instance.PlayTrackMusic(musicOnActivate_List[randomChoice]);
                TM_MusicController.Instance.currentMusicRange_GO = gameObject;

                if (isOneTimeUse == true)
                {
                    canPlayMusic = false;
                }
                else
                {
                    StartCoroutine(WaitToAllowNewMusicOnReentry());
                }
            }
        }
    }

    private IEnumerator WaitToAllowNewMusicOnReentry()
    {
        canPlayMusic = false;
        yield return new WaitForSeconds(10f);
        canPlayMusic = true;

        yield break;
    }

}

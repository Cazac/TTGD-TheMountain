using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_ExampleClass 
///
///
/// Class Type - 
///
/// 
/// </summary>
///////////////

public class TM_EXPSoulDropped : MonoBehaviour
{
    ////////////////////////////////

    [Header("Current Values")]
    public int expValue = 1;

    [Header("Collisions")]
    public bool hasCollided;

    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Movement>() != null)
        {
            if (hasCollided)
            {
                return;
            }
            else
            {
                //Set bool to allow single pickup
                hasCollided = true;

                //Play SFX
                TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.playerLevelUp_SFX);

                //Conversion To UI
                TM_PlayerController_Stats.Instance.player_Level += expValue;
                TM_PlayerController_Stats.Instance.player_SkillPointsAvalible += expValue;

                Destroy(gameObject);
            }
        }
    }

    ///////////////////////////////////////////////////////
}

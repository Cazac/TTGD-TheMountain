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
    public TM_Audio_SO attackHeavy_SFX;


    [Header("UI CLick")]
    public TM_Audio_SO clickUI_SFX;


    //public TM_Audio_SO _SFX;


    public TM_Audio_SO burningItem_SFX;

    [Header("Interaction - Door")]
    public TM_Audio_SO interactionDoor1_SFX;
    public TM_Audio_SO interactionDoor2_SFX;

    [Header("Interaction - Door")]
    public TM_Audio_SO playerFootsteps1_SFX;
    public TM_Audio_SO playerFootsteps2_SFX;
    public TM_Audio_SO playerFootsteps3_SFX;
    public TM_Audio_SO playerFootsteps4_SFX;

    public TM_Audio_SO playerPunch_SFX;

    [Header("Spawn")]
    public TM_Audio_SO enemySpawn_SFX;
    public TM_Audio_SO minotaurSpawn_SFX;

    public TM_Audio_SO minotaurRoar_SFX;
    public TM_Audio_SO minotaurDamaged_SFX;

    public TM_Audio_SO minotaurFootsteps1_SFX;
    public TM_Audio_SO minotaurFootsteps2_SFX;
    public TM_Audio_SO minotaurFootsteps3_SFX;
    public TM_Audio_SO minotaurFootsteps4_SFX;
    public TM_Audio_SO minotaurFootsteps5_SFX;

    ////////////////////////////////
}

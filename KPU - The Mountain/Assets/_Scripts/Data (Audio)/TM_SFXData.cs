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

    [Header("UI - Menus")]
    public TM_Audio_SO clickUI_SFX;
    public TM_Audio_SO burningItem_SFX;

    ////////////////////////////////

    [Header("Player - Footsteps")]
    public TM_Audio_SO playerFootsteps1_SFX;
    public TM_Audio_SO playerFootsteps2_SFX;
    public TM_Audio_SO playerFootsteps3_SFX;
    public TM_Audio_SO playerFootsteps4_SFX;

    [Header("Player - Attacks")]
    public TM_Audio_SO playerPunch_SFX;
    public TM_Audio_SO playerSword_SFX;
    public TM_Audio_SO playerMace_SFX;

    ////////////////////////////////

    [Header("Spawn - All")]
    public TM_Audio_SO enemySpawn_SFX;
    public TM_Audio_SO enemyDeath_SFX;

    [Header("Interaction - Door")]
    public TM_Audio_SO interactionDoor1_SFX;
    public TM_Audio_SO interactionDoor2_SFX;

    ////////////////////////////////

    [Header("Minotaur")]
    public TM_Audio_SO minotaurSpawn_SFX;
    public TM_Audio_SO minotaurRoar_SFX;
    public TM_Audio_SO minotaurDamaged1_SFX;
    public TM_Audio_SO minotaurDamaged2_SFX;


    public TM_Audio_SO minotaurPunch_SFX;
    public TM_Audio_SO minotaurDeath_SFX;


    public TM_Audio_SO minotaurFootsteps1_SFX;
    public TM_Audio_SO minotaurFootsteps2_SFX;
    public TM_Audio_SO minotaurFootsteps3_SFX;
    public TM_Audio_SO minotaurFootsteps4_SFX;
    public TM_Audio_SO minotaurFootsteps5_SFX;

    ////////////////////////////////

    //public TM_Audio_SO _SFX;

    public TM_Audio_SO playerLevelUp_SFX;


    public TM_Audio_SO playerConsumeItem_SFX;


    ////////////////////////////////
}

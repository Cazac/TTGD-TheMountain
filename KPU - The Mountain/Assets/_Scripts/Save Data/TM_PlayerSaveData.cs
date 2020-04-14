using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerSaveData
/// 
/// 
/// 
/////////////// 

[System.Serializable]
public class TM_PlayerSaveData 
{
    ////////////////////////////////

    public bool player_hasLoadedSaveBefore;

    ////////////////////////////////

    public string playerInfo_Name;
    public string playerInfo_Class;
    public int playerInfo_MapSeed;
    public int playerInfo_CyclesSurvived;
    public int playerInfo_BossesKilled;
    public int playerInfo_NotesCollected;


    ////////////////////////////////

    [Header("Player - Positions")]
    public Vector3 player_Position;
    //public Quaternion player_Rotation;

    ////////////////////////////////


    public bool player_HasUnlocked_Brewery;
    public bool player_HasUnlocked_Forge;
    public bool player_HasUnlocked_Canteen;
    public bool player_HasUnlocked_Storage;



    ////////////////////////////////

    public int player_CurrentHealth;
    public int player_MaxHealth;
    public int player_BaseHealth;

    ////////////////////////////////

    public int player_CurrentHunger;
    public int player_MaxHunger;
    public int player_BaseHunger;

    ////////////////////////////////

    public int player_CurrentFire;
    public int player_MaxFire;
    public int player_BaseFire;

    ////////////////////////////////

    ////////////////////////////////

    public int player_Level;
    public int player_Exp;


    ////////////////////////////////

    public int player_SkillPointsAvalible;
    public int player_SkillPointsSpent;

    ////////////////////////////////

    public int player_CurrentStat_STR;
    public int player_CurrentStat_DEX;
    public int player_CurrentStat_INT;
    public int player_CurrentStat_CON;

    ////////////////////////////////

    public TM_ItemUI[] player_Inventory;
    public TM_ItemUI[] player_Storage;


    ///////////////////////////////////////////////////////

    public void ConvertGameData_ToSaveData()
    {
        //Level Has Loaded
        player_hasLoadedSaveBefore = true;





        //Name Info
        playerInfo_Name = TM_PlayerController_Stats.Instance.playerInfo_Name;
        playerInfo_Class = TM_PlayerController_Stats.Instance.playerInfo_Class;
        playerInfo_CyclesSurvived = TM_PlayerController_Stats.Instance.playerInfo_CyclesSurvived;





        //Health
        player_CurrentHealth = TM_PlayerController_Stats.Instance.player_CurrentHealth;
        player_MaxHealth = TM_PlayerController_Stats.Instance.player_MaxHealth;
        player_BaseHealth = TM_PlayerController_Stats.Instance.player_BaseHealth;

        //Hunger
        player_CurrentHunger = TM_PlayerController_Stats.Instance.player_CurrentHunger;
        player_MaxHunger = TM_PlayerController_Stats.Instance.player_MaxHunger;
        player_BaseHunger = TM_PlayerController_Stats.Instance.player_BaseHunger;

        //Fire
        player_CurrentFire = TM_PlayerController_Stats.Instance.player_CurrentFire;
        player_MaxFire = TM_PlayerController_Stats.Instance.player_MaxFire;
        player_BaseFire = TM_PlayerController_Stats.Instance.player_BaseFire;

        //Levels
        player_Level = TM_PlayerController_Stats.Instance.player_Level;
        player_Exp = TM_PlayerController_Stats.Instance.player_Exp;

        //Skill Points
        player_SkillPointsAvalible = TM_PlayerController_Stats.Instance.player_SkillPointsAvalible;
        player_SkillPointsSpent = TM_PlayerController_Stats.Instance.player_SkillPointsSpent;

        //Stats
        player_CurrentStat_STR = TM_PlayerController_Stats.Instance.player_CurrentStat_STR;
        player_CurrentStat_DEX = TM_PlayerController_Stats.Instance.player_CurrentStat_DEX;
        player_CurrentStat_INT = TM_PlayerController_Stats.Instance.player_CurrentStat_INT;
        player_CurrentStat_CON = TM_PlayerController_Stats.Instance.player_CurrentStat_CON;

        //Inventory

        //Equipment



        //Notes

        //


        //Player Position / Rotation
        player_Position = TM_PlayerController_Stats.Instance.gameObject.transform.position;



    }

    ///////////////////////////////////////////////////////

    public void ConvertSaveData_ToGameData()
    {
        //Name Info
        TM_PlayerController_Stats.Instance.playerInfo_Name = playerInfo_Name;
        TM_PlayerController_Stats.Instance.playerInfo_Class = playerInfo_Class;
        TM_PlayerController_Stats.Instance.playerInfo_CyclesSurvived = playerInfo_CyclesSurvived;




        //Health
        TM_PlayerController_Stats.Instance.player_CurrentHealth = player_CurrentHealth;
        TM_PlayerController_Stats.Instance.player_MaxHealth = player_MaxHealth;
        TM_PlayerController_Stats.Instance.player_BaseHealth = player_BaseHealth;

        //Hunger
        TM_PlayerController_Stats.Instance.player_CurrentHunger = player_CurrentHunger;
        TM_PlayerController_Stats.Instance.player_MaxHunger = player_MaxHunger;
        TM_PlayerController_Stats.Instance.player_BaseHunger = player_BaseHunger;

        //Fire
        TM_PlayerController_Stats.Instance.player_CurrentFire = player_CurrentFire;
        TM_PlayerController_Stats.Instance.player_MaxFire = player_MaxFire;
        TM_PlayerController_Stats.Instance.player_BaseFire = player_BaseFire;

        //Levels
        TM_PlayerController_Stats.Instance.player_Level = player_Level;
        TM_PlayerController_Stats.Instance.player_Exp = player_Exp;

        //Skill Points
        TM_PlayerController_Stats.Instance.player_SkillPointsAvalible = player_SkillPointsAvalible;
        TM_PlayerController_Stats.Instance.player_SkillPointsSpent = player_SkillPointsSpent;

        //Stats
        TM_PlayerController_Stats.Instance.player_CurrentStat_STR = player_CurrentStat_STR;
        TM_PlayerController_Stats.Instance.player_CurrentStat_DEX = player_CurrentStat_DEX;
        TM_PlayerController_Stats.Instance.player_CurrentStat_INT = player_CurrentStat_INT;
        TM_PlayerController_Stats.Instance.player_CurrentStat_CON = player_CurrentStat_CON;









        //Player Position / Rotation
        TM_PlayerController_Stats.Instance.gameObject.transform.position = player_Position;










        /////////////////////////////////////////////////////// - Refresh Data

        TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_HungerValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_FireValue();

        ///////////////////////////////////////////////////////
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///////////////
/// <summary>
///     
/// TM_PlayerController_Stats
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Attributes : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Attributes Instance;

    ////////////////////////////////

    private int equipmentStat_STR;
    private int equipmentStat_DEX;
    private int equipmentStat_INT;
    private int equipmentStat_CON;

    ////////////////////////////////

    private int tempStat_STR;
    private int tempStat_DEX;
    private int tempStat_INT;
    private int tempStat_CON;

    ////////////////////////////////

    [Header("Buttons")]
    public GameObject STR_Button;
    public GameObject DEX_Button;
    public GameObject INT_Button;
    public GameObject CON_Button;

    ////////////////////////////////

    [Header("Text")]
    public TextMeshProUGUI skillPointAvalible_Text;
    public TextMeshProUGUI STR_Text;
    public TextMeshProUGUI DEX_Text;
    public TextMeshProUGUI INT_Text;
    public TextMeshProUGUI CON_Text;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        DebugSpawnStats();
    }

    ///////////////////////////////////////////////////////

    private void DebugSpawnStats()
    {
       TM_PlayerController_Stats.Instance.player_SkillPointsAvalible = Random.Range(3, 5);

        TM_PlayerController_Stats.Instance.player_CurrentStat_STR = Random.Range(2, 8);
        TM_PlayerController_Stats.Instance.player_CurrentStat_DEX = Random.Range(2, 8);
        TM_PlayerController_Stats.Instance.player_CurrentStat_INT = Random.Range(2, 8);
        TM_PlayerController_Stats.Instance.player_CurrentStat_CON = Random.Range(2, 8);
    }

    ///////////////////////////////////////////////////////

    public void Button_AddValue_STR()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_STR++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            RefreshStatsUI();
        }
    }

    public void Button_AddValue_DEX()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_DEX++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            RefreshStatsUI();
        }
    }

    public void Button_AddValue_INT()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_INT++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            RefreshStatsUI();
        }
    }

    public void Button_AddValue_CON()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_CON++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            RefreshStatsUI();
        }
    }

    ///////////////////////////////////////////////////////

    public void RefreshStatsUI()
    {
        skillPointAvalible_Text.text = "Skill Points Avalible: " + TM_PlayerController_Stats.Instance.player_SkillPointsAvalible;

        int additive_STR = equipmentStat_STR + tempStat_STR;
        int additive_DEX = equipmentStat_DEX + tempStat_DEX;
        int additive_INT = equipmentStat_INT + tempStat_INT;
        int additive_CON = equipmentStat_CON + tempStat_CON;

        if (additive_STR > 0)
        {
            STR_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (+<color=#ffff00>" + additive_STR + "</color>)";
        }
        else if (additive_STR < 0)
        {
            STR_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (-<color=#ffff00>" + additive_STR + "</color>)";
        }
        else
        {
            STR_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (+0)";
        }

        DEX_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_DEX + " (+0)";
        INT_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_INT + " (+0)";
        CON_Text.text = TM_PlayerController_Stats.Instance.player_CurrentStat_CON + " (+0)";

            
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible <= 0)
        {
            STR_Button.SetActive(false);
            DEX_Button.SetActive(false);
            INT_Button.SetActive(false);
            CON_Button.SetActive(false);
        } 
        else
        {
            STR_Button.SetActive(true);
            DEX_Button.SetActive(true);
            INT_Button.SetActive(true);
            CON_Button.SetActive(true);
        }
    }

    ///////////////////////////////////////////////////////
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerController_Stats
/// 
/// 
/// IF YOU WANT TO SAVE DUPPICATE THIS, CONTRSUTOR IT INTO A NEW SERILIZABLE CLASS, THIS IS GONNA BE MONO.
/// 
/// </summary>
///////////////

public class TM_PlayerController_Stats : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Stats Instance;

    ////////////////////////////////

    public string playerInfo_Name;

    ////////////////////////////////

    public string playerInfo_Class;
    public int playerInfo_CyclesSurvived;

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


    bool continueCoroutine_HungerDrain = true;
    bool continueCoroutine_FireDrain = true;

    private float secondsPer_HungerDrain = 10f;
    private float secondsPer_FireDrain = 5f;



    ////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        SetDebugStats();

        //Refresh the current values at first chance when systems are setup
        TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_HungerValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_FireValue();

        StartCoroutine(HungerDrain());
        StartCoroutine(FireDrain());
    }

    ///////////////////////////////////////////////////////

    public void LoadStats()
    {

    }

    private void SetDebugStats()
    {
        player_CurrentHealth = 100;
        player_MaxHealth = 100;
        player_BaseHealth = 100;

        player_CurrentHunger = 100;
        player_MaxHunger = 100;
        player_BaseHunger = 100;

        player_CurrentFire = 100;
        player_MaxFire = 100;
        player_BaseFire = 100;
    }

    private void FixedUpdate()
    {
        //ChangeHealth_Current(-1);
    }

    ///////////////////////////////////////////////////////

    public IEnumerator HungerDrain()
    {
        while (continueCoroutine_HungerDrain)
        {
            if (player_CurrentHunger > 0)
            {
                //Remove Hunger
                ChangeHunger_Current(-1);

                //Wait
                yield return new WaitForSeconds(secondsPer_HungerDrain);
            }
            else
            {
                //Remove Health due to lack of hunger
                ChangeHealth_Current(-1, "Hunger");

                //Wait
                yield return new WaitForSeconds(secondsPer_HungerDrain);
            }
        }
    }

    public IEnumerator FireDrain()
    {
        while (continueCoroutine_FireDrain)
        {
            if (player_CurrentFire > 0)
            {
                //Remove Hunger
                ChangeFire_Current(-1);

                //Wait
                yield return new WaitForSeconds(secondsPer_FireDrain);
            }
            else
            {
                //Death
                TM_PlayerMenuController_Death.Instance.StartDeathAnimation("Fire");

                //Wait
                yield return new WaitForSeconds(secondsPer_FireDrain);
            }
        }
    }

    ///////////////////////////////////////////////////////

    public int GetCurrentDamage(TM_Item_SO weaponSO)
    {



        return 5;
    }

    ///////////////////////////////////////////////////////

    public void ChangeHealth_Current(int changeValue, string damageType)
    {
        //Change Value
        player_CurrentHealth += changeValue;

        //Check For Overload
        if (player_CurrentHealth > player_MaxHealth)
        {
            //Cap at Max
            player_CurrentHealth = player_MaxHealth;
        }

        //Check For Death
        if (player_CurrentHealth <= 0)
        {
            //No HP
            player_CurrentHealth = 0;

            //Death
            TM_PlayerMenuController_Death.Instance.StartDeathAnimation(damageType);
        }

        //Update UI
        TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
    }

    public void ChangeHealth_Max()
    {


    }

    public void ChangeHealth_Base()
    {


    }

    ///////////////////////////////////////////////////////

    public void ChangeHunger_Current(int changeValue)
    {
        //Change Value
        player_CurrentHunger += changeValue;

        //Check For Overload
        if (player_CurrentHunger > player_MaxHunger)
        {
            //Cap at Max
            player_CurrentHunger = player_MaxHunger;
        }

        //Check For Death
        if (player_CurrentHunger <= 0)
        {
            //No HP
            player_CurrentHunger = 0;
        }

        //Update UI
        TM_PlayerMenuController_UI.Instance.UpdateUI_HungerValue();
    }

    public void ChangeHunger_Max()
    {


    }

    public void ChangeHunger_Base()
    {


    }

    ///////////////////////////////////////////////////////

    public void ChangeFire_Current(int changeValue)
    {
        //Change Value
        player_CurrentFire += changeValue;

        //Check For Overload
        if (player_CurrentFire > player_MaxFire)
        {
            //Cap at Max
            player_CurrentFire = player_MaxFire;
        }

        //Check For Death
        if (player_CurrentFire <= 0)
        {
            //No HP
            player_CurrentFire = 0;

            //Death
            TM_PlayerMenuController_Death.Instance.StartDeathAnimation("Fire");
        }

        //Update UI
        TM_PlayerMenuController_UI.Instance.UpdateUI_FireValue();
    }

    public void ChangeFire_Max()
    {


    }

    public void ChangeFire_Base()
    {


    }

    ///////////////////////////////////////////////////////
}

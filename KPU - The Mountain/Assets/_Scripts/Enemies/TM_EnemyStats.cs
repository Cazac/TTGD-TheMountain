using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyStats : MonoBehaviour
{
    ////////////////////////////////


    //Health
    public int enemy_CurrentHealth;
    public int enemy_MaxHealth;


    ///////////////////////////////////////////////////////

    private void Start()
    {
        SetDebugStats();
    }

    ///////////////////////////////////////////////////////

    private void SetDebugStats()
    {
        enemy_CurrentHealth = 200;
        enemy_MaxHealth = 200;
    }

    ///////////////////////////////////////////////////////


    public void ChangeHealth_Current(int changeValue)
    {

        StartCoroutine(gameObject.GetComponent<TM_EnemyDirector_Minotaur>().DamagedVisualFlash());


        //Change Value
        enemy_CurrentHealth += changeValue;

        //Check For Overload
        if (enemy_CurrentHealth > enemy_MaxHealth)
        {
            //Cap at Max
            enemy_CurrentHealth = enemy_MaxHealth;
        }

        //Check For Death
        if (enemy_CurrentHealth <= 0)
        {
            //No HP
            enemy_CurrentHealth = 0;

            //Death
            EnemyDeath();
        }




        //Update UI
        //TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
    }



    ///////////////////////////////////////////////////////

    public void EnemyDeath()
    {
        //print("Test Code: Enemy Has Died");

        gameObject.GetComponent<TM_EnemyDirector_Minotaur>().ChangeToState_Dying();




        //gameObject.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

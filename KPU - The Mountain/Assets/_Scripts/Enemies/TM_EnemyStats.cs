using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyStats : MonoBehaviour
{
    ////////////////////////////////

    [Header("Health")]
    public int enemy_CurrentHealth;
    public int enemy_MaxHealth;

    [Header("Enemy Type")]
    public TM_EnemyDirector_Minotaur minotaurDirector;
    public TM_EnemyDirector_Skeleton skeletonDirector;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        GetEnemy_Typed();
        SetStats_Typed();
    }

    ///////////////////////////////////////////////////////

    private void GetEnemy_Typed()
    {
        minotaurDirector = gameObject.GetComponent<TM_EnemyDirector_Minotaur>();
        skeletonDirector = gameObject.GetComponent<TM_EnemyDirector_Skeleton>();
    }

    private void SetStats_Typed()
    {
        if (minotaurDirector != null)
        {
            enemy_CurrentHealth = minotaurDirector.STARTING_HEALTH;
            enemy_MaxHealth = minotaurDirector.STARTING_HEALTH;
            return;
        }
        else if (skeletonDirector != null)
        {
            //enemy_CurrentHealth = skeletonDirector.STARTING_HEALTH;
            //enemy_MaxHealth = skeletonDirector.STARTING_HEALTH;
            return;
        }
        else
        {
            print("Test Code: Error");
            return;
        }

    }

    ///////////////////////////////////////////////////////

    public void ChangeHealth_Current(int changeValue)
    {
     


        //Set Visual Red Blink / Set Damage Popup
        SetVisualFlash_Typed();
        SetDamagePopup_Typed(changeValue);

        //Change Health Value
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
            EnemyDeath_Typed();
        }


        //Update Enemy UI Bar
        //TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
    }

    ///////////////////////////////////////////////////////
    
    private void SetVisualFlash_Typed()
    {
        if (minotaurDirector != null)
        {
            //Minotaur
            StartCoroutine(minotaurDirector.DamagedVisualFlash());
            return;
        }
        else if (skeletonDirector != null)
        {
            //enemy_CurrentHealth = skeletonDirector.STARTING_HEALTH;
            //enemy_MaxHealth = skeletonDirector.STARTING_HEALTH;
            return;
        }
        else
        {
            print("Test Code: Error");
            return;
        }

    }

    public void SetKnockback_Typed(Vector3 direction)
    {
        //Get Type
        if (minotaurDirector != null)
        {
            //Minotaur
            minotaurDirector.Knockback(direction.normalized, 20f);
            return;
        }
        else if (skeletonDirector != null)
        {
            //enemy_CurrentHealth = skeletonDirector.STARTING_HEALTH;
            //enemy_MaxHealth = skeletonDirector.STARTING_HEALTH;
            return;
        }
        else
        {
            print("Test Code: Error");
            return;
        }
    }

    private void SetDamagePopup_Typed(int damage)
    {
        //Invert Chnaged Value to Damage for Positive Value
        damage = damage * -1;

        //Get Type
        if (minotaurDirector != null)
        {
            //Minotaur
            minotaurDirector.DamagePopup(damage);
            return;
        }
        else if (skeletonDirector != null)
        {
            //enemy_CurrentHealth = skeletonDirector.STARTING_HEALTH;
            //enemy_MaxHealth = skeletonDirector.STARTING_HEALTH;
            return;
        }
        else
        {
            print("Test Code: Error");
            return;
        }
    }

    ///////////////////////////////////////////////////////

    public void EnemyDeath_Typed()
    {
        //Get Type
        if (minotaurDirector != null)
        {
            //Minotaur
            minotaurDirector.ChangeToState_Dying();
            return;
        }
        else if (skeletonDirector != null)
        {
            //enemy_CurrentHealth = skeletonDirector.STARTING_HEALTH;
            //enemy_MaxHealth = skeletonDirector.STARTING_HEALTH;
            return;
        }
        else
        {
            print("Test Code: Error");
            return;
        }
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyHitboxRangeCollider : MonoBehaviour
{

    public int colliderDamage;
    public string damageType;


    public bool hasCollided;


    private void OnTriggerEnter(Collider collider)
    {
        if (hasCollided)
        {
            return;
        }

        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Combat>() != null)
        {
            hasCollided = true;

            //Play SFX
            TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.playerHurt_SFX);

            //GET DAMAGE HERE????
            int damage = 15;

            //Calculate Damage Receieved
            damage = TM_PlayerController_Stats.Instance.CalculateDamageRecieved(damage);

            //Reverse Damage To Change Value
            damage = damage * -1;

            collider.gameObject.GetComponent<TM_PlayerController_Stats>().ChangeHealth_Current(damage, "Minotaur");
            TM_PlayerController_Combat.Instance.AddToHurtScreen(Mathf.Abs(damage));

            Destroy(gameObject);
        }
    }
}

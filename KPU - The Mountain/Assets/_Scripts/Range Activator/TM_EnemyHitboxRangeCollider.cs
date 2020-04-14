using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyHitboxRangeCollider : MonoBehaviour
{

    public int colliderDamage;
    public string damageType;



    private void OnTriggerEnter(Collider collider)
    {
        //print("Test Code: Collider?");

        //Check For Player
        if (collider.gameObject.GetComponent<TM_PlayerController_Combat>() != null)
        {
            //Play SFX
            TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.playerHurt_SFX);

            int damage = -15;

            collider.gameObject.GetComponent<TM_PlayerController_Stats>().ChangeHealth_Current(damage, "Minotaur");
            TM_PlayerController_Combat.Instance.AddToHurtScreen(Mathf.Abs(damage));



            //print("Test Code: Dealing Damage!");
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerHitboxRangeCollider : MonoBehaviour
{
    ///////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_EnemyStats>() != null)
        {
            //Get Item Held and Get Damage
            TM_ItemUI item = TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array[TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();
            int damage = TM_PlayerController_Stats.Instance.CalculateAttack_WithWep(item);

            //Get Stats Of Hit Enemy
            TM_EnemyStats enemyStats = collider.gameObject.GetComponent<TM_EnemyStats>();

            //Invert value for Neagtive Value
            damage = damage * -1;

            //Change Health Value
            enemyStats.ChangeHealth_Current(damage);

            //Get Direction Of Attack
            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;

            //Set Knockback
            enemyStats.SetKnockback_Typed(direction);

            //Remove Hitbox
            Destroy(gameObject);
        }
    }

    ///////////////////////////////////////////////////////
}

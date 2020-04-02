using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerHitboxRangeCollider : MonoBehaviour
{



    private void OnTriggerEnter(Collider collider)
    {
        //Check For Player
        if (collider.gameObject.GetComponent<TM_EnemyStats>() != null)
        {
            //Get Item Held
            TM_ItemUI item = TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array[TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();
            int damage = TM_PlayerController_Stats.Instance.CalculateAttack_WithWep(item);


            collider.gameObject.GetComponent<TM_EnemyDirector_Minotaur>().DamagePopup(damage);


            damage = damage * -1;

            print("Test Code: Damage " + damage);

            collider.gameObject.GetComponent<TM_EnemyStats>().ChangeHealth_Current(damage);



            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;



            collider.gameObject.GetComponent<TM_EnemyDirector_Minotaur>().Knockback(direction);


            //print("Test Code: Damaged!");
            Destroy(gameObject);
        }
    }





}

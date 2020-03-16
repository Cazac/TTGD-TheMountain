using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyAnimationTab : MonoBehaviour
{
  
    public TM_EnemyDirector_Minotaur enemyDirector;


    public void Attack1A_Hand()
    {

        enemyDirector.SpawnAttackHitbox(TM_DatabaseController.Instance.hitbox_DB.minotaur_Hitbox);

    }
    


}

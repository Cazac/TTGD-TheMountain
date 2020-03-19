using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_EnemyAnimationTab : MonoBehaviour
{
  
    public TM_EnemyDirector_Minotaur enemyDirector;

    public GameObject deathSmoke_Particle;

    public void Attack1A_Hand()
    {

        enemyDirector.SpawnAttackHitbox(TM_DatabaseController.Instance.hitbox_DB.minotaur_Hitbox);

    }

    public void FinishAttack()
    {

        enemyDirector.ChangeToState_Chasing();

    }


    public void DeathDelete()
    {
        //Destory
        Destroy(enemyDirector.gameObject);
    }

    public void DeathDissolve()
    {




    }

    public void DeathParticules()
    {
        //Particule Effect
        GameObject particule = Instantiate(deathSmoke_Particle, enemyDirector.gameObject.transform);
        particule.transform.position = enemyDirector.gameObject.transform.position;
        particule.transform.Translate(new Vector3(0, 3, -2));
        particule.transform.SetParent(enemyDirector.gameObject.transform.parent);

        //Speed
        var main = particule.GetComponent<ParticleSystem>().main;
        main.simulationSpeed = 10f;
    }

}

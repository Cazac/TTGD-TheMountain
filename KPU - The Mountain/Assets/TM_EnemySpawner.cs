using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_ExampleClass 
///
///
/// Class Type - 
///
/// 
/// </summary>
///////////////

public class TM_EnemySpawner : MonoBehaviour
{
    ////////////////////////////////

    [Header("Spawner")]
    public Animator spawner_Animator;
    public GameObject spawner_EnemyPrefab;
    public GameObject spawner_IntroSmoke;
    public GameObject spawner_SpawnSmoke;

    public GameObject spawner_EnemyContainer;

    ///////////////////////////////////////////////////////

    public void AnimationChange_FadeOut()
    {
        spawner_Animator.Play("Pentagram Fade");
    }

    public void AnimationChange_Idle()
    {
        spawner_Animator.Play("Pentagram Idle");
    }

    public void AnimationChange_Spawn()
    {
        spawner_Animator.Play("Pentagram Spawn");
    }

    ///////////////////////////////////////////////////////

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(AttemptEnemySpawnLoop());
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(AttemptEnemySpawnLoop());
    }

    ///////////////////////////////////////////////////////

    private IEnumerator AttemptEnemySpawnLoop()
    {
        while (true)
        {

        
            if (spawner_EnemyContainer.transform.childCount == 0)
            {
                AnimationChange_Spawn();
            }




            //Wait For 0.15 Seconds
            yield return new WaitForSeconds(10f);

        }




        //Break Out
        yield break;
    }

    public void AnimationEvent_SpawnEnemy()
    {
        //Start Spawning Coroutine
        StartCoroutine(SpawningEnemy());
    }

    private IEnumerator SpawningEnemy()
    {
        Vector3 additionalHeight = new Vector3(0, 2.5f, 0);

        //Spawn Smoke Screen
        GameObject smokeIntro = Instantiate(spawner_IntroSmoke, gameObject.transform.position, Quaternion.identity, spawner_EnemyContainer.transform);
        smokeIntro.GetComponent<TM_AutoDestoryTab>().Setup(2f);

        //Spawn Smoke Screen
        GameObject smokeSpawn = Instantiate(spawner_SpawnSmoke, gameObject.transform.position + additionalHeight, Quaternion.identity, spawner_EnemyContainer.transform);
        smokeSpawn.GetComponent<TM_AutoDestoryTab>().Setup(2f);

        //Wait For 0.2 Seconds
        yield return new WaitForSeconds(0.2f);

        //Spawn Enemy
        Instantiate(spawner_EnemyPrefab, gameObject.transform.position, Quaternion.identity, spawner_EnemyContainer.transform);

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////
}

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

    [Header("Candles Left")]
    public List<TM_SpawnerCandlesTab> spawner_Candles_List;
    public int spawner_CandlesBurningCount;

    [Header("Sound Effects")]
    private GameObject spawnerIdle_DeletableSFX;

    public bool isSpawnerFixedRangeActivation;

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
        RelightCandles();

        if (isSpawnerFixedRangeActivation)
        {
            StopAllCoroutines();
            StartCoroutine(AttemptEnemySpawnLoop());
        }
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(AttemptEnemySpawnLoop());
    }

    ///////////////////////////////////////////////////////

    public void RelightCandles()
    {
        //Play SFX
        spawnerIdle_DeletableSFX = TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.enemySpawnGlow_SFX, gameObject.transform.parent.gameObject);

        AnimationChange_Idle();

        foreach (TM_SpawnerCandlesTab candleTab in spawner_Candles_List)
        {
            candleTab.SetCandleActive();
        }
    }

    public void RefreshCandleCount()
    {
        //Reset Candle Count
        spawner_CandlesBurningCount = 0;

        //Loop All Candles
        foreach (TM_SpawnerCandlesTab candleTab in spawner_Candles_List)
        {
            //Check Status
            if (candleTab.isCandleActive)
            {
                //Add A Candle
                spawner_CandlesBurningCount++;
            }
        }
    }

    public void RemoveNextCandle()
    {
        foreach (TM_SpawnerCandlesTab candleTab in spawner_Candles_List)
        {
            if (candleTab.isCandleActive)
            {
                candleTab.SetCandleDeactive();
                return;
            }
        }
    }

    ///////////////////////////////////////////////////////

    private IEnumerator AttemptEnemySpawnLoop()
    {
        //Refresh Active Candles
        RefreshCandleCount();

        //Loop while candles are still active
        while (spawner_CandlesBurningCount > 0)
        {
            //Check Monster Spawn Cap is Reached
            if (spawner_EnemyContainer.transform.childCount == 0)
            {
                //Spawn Monster
                AnimationChange_Spawn();
            }
   
            //Wait For Next Loop
            yield return new WaitForSeconds(5f);
        }

        if (spawnerIdle_DeletableSFX != null)
        {
            Destroy(spawnerIdle_DeletableSFX);
        }

        AnimationChange_FadeOut();

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////

    public void AnimationEvent_SpawnEnemy()
    {
        //Play SFX
        spawnerIdle_DeletableSFX = TM_SFXController.Instance.PlayTrackSFX(TM_DatabaseController.Instance.sfx_DB.enemySpawn_SFX, gameObject.transform.parent.gameObject);

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

        //Remove A Candle
        RemoveNextCandle();

        //Refresh Active Candles
        RefreshCandleCount();

        //Wait For 0.2 Seconds
        yield return new WaitForSeconds(0.2f);

        //Spawn Enemy
        Instantiate(spawner_EnemyPrefab, gameObject.transform.position, Quaternion.identity, spawner_EnemyContainer.transform);

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////
}

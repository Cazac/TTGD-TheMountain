using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_Room is used to hold info on spawned room in the dungeon.
/// 
/// </summary>
///////////////

public class TM_NewRoom : MonoBehaviour
{
    ////////////////////////////////

    [Header("World Gen Biome")]
    public string Biome;

    ////////////////////////////////

    [Header("Doors Script")]
    public TM_DoorwayContainer doorContainer;

    [Header("Lights Script")]
    public TM_LightContainer lightContainer;

    [Header("Resource Script")]
    public TM_ResourceContainer resourceContainer;

    [Header("Item Spawn Script")]
    public TM_ItemSpawnContainer itemSpawnContainer;

    [Header("Enemy Spawn Script")]
    public TM_EnemySpawnContainer enemySpawnContainer;

    [Header("GenerationCollider Script")]
    public TM_GenerationColliderContainer generationColliderContainer;

    ////////////////////////////////
}

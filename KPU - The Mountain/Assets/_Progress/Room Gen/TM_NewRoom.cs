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

    [Header("Doors Script")]
    public TM_DoorwayContainer doorContainer;

    [Header("Lights Script")]
    public TM_LightContainer lightContainer;








    [Header("World Gen Colliders - COMPRESS ME")]
    public List<BoxCollider> roomGenerator_BoxCollider;

    //[Header("World Gen Biome")]
    //public string Biome;

    ////////////////////////////////
}

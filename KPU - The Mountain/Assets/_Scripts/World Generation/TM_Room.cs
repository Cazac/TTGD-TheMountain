using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_Room 
/// 
/// </summary>
///////////////

public class TM_Room : MonoBehaviour
{
    ////////////////////////////////
    
    [Header("All Doors in the room")]
    public List<TM_Door> doorways_LIST;

    [Header("World Gen Colliders")]
    public BoxCollider roomGenerator_BoxCollider;

    [Header("World Gen Biome")]
    public string Biome;

    ///////////////////////////////////////////////////////
}

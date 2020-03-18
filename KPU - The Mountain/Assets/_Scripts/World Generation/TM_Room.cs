﻿using System.Collections;
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

public class TM_Room : MonoBehaviour
{
    ////////////////////////////////
    
    [Header("All Room Doors")]
    public List<TM_Door> doorways_LIST;

    [Header("All Room Themes - REMOVE ME")]
    public List<TM_Theme> themes_LIST;

    [Header("World Gen Colliders - COMPRESS ME")]
    public List<BoxCollider> roomGenerator_BoxCollider;

    //[Header("World Gen Biome")]
    //public string Biome;

    ////////////////////////////////
}

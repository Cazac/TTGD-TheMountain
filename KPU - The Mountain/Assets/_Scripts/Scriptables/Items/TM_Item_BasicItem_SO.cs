using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Basic")]
public class TM_Item_BasicItem_SO : ScriptableObject
{
    //////////////////////////////// - Prefabs

    [Header("Item Prefabs")]
    public GameObject dropped_Prefab;
    public GameObject placed_Prefab;

    //////////////////////////////// - All Item Stats 

    [Header("Item Descriptions")]
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;

    [Header("Item UI Info")]
    public int maxDurablity;
    public int currentDurablity;
    public int maxStackSize;
    public int currentStackSize;

    [Header("Item UI Info")]
    public bool isBurnable;

    //////////////////////////////// - Equiptable Weapon Stats



    ///////////////////////////////////////////////////////
}
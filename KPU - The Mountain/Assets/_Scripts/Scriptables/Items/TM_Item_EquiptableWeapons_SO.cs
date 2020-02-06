using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_SO 
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Equiptable Weapon")]
public class TM_Item_EquiptableWeapons_SO : ScriptableObject
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

    [Header("Item Stats (Equiptable Weapon)")]
    public int weapon_Damage;
    public int weapon_Range;
    public int weapon_SwingSpeed;

    public int weaponReq_STR;
    public int weaponReq_DEX;
    public int weaponReq_INT;
    public int weaponReq_CON;

    ///////////////////////////////////////////////////////
}
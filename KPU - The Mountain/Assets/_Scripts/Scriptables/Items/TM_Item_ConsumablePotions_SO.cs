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

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Consumable Potion")]
public class TM_Item_ConsumablePotions_SO : ScriptableObject
{
    /////////////////////////////// - Prefabs

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

    //////////////////////////////// - Consumable Potion Stats

    [Header("Item Stats (Consumable Potions)")]
    public string hunger;
    public string health;

    ///////////////////////////////////////////////////////
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_SO is the scriptable object to create the Consumable Food Item.
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Consumable Food")]
public class TM_Item_ConsumableFood_SO : ScriptableObject
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

    //////////////////////////////// - Consumable Food Stats

    [Header("Item Stats (Consumable Food)")]
    public string hunger;
    public string health;

    ///////////////////////////////////////////////////////
}

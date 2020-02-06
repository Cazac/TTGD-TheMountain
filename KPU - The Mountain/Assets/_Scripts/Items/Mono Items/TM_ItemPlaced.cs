using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_ItemPlaced 
/// 
/// </summary>
///////////////

public class TM_ItemPlaced : MonoBehaviour
{
    ////////////////////////////////

    [Header("Scriptable Objects")]
    public TM_Item_ConsumableFood_SO originalScriptableItem_ConsumableFood;
    public TM_Item_ConsumablePotions_SO originalScriptableItem_ConsumablePotions;
    public TM_Item_EquiptableWeapons_SO originalScriptableItem_EquiptableWeapons;
    public TM_Item_EquiptableArmor_SO originalScriptableItem_EquiptableArmor;

    ////////////////////////////////

    public string ItemName { get; set; }
    public string ItemDesc { get; set; }

    public int MaxDurablity { get; set; }
    public int CurrentDurablity { get; set; }
    public int MaxStackSize { get; set; }
    public int CurrentStackSize { get; set; }

    ///////////////////////////////////////////////////////
}

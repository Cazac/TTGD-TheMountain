﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_UI 
/// 
/// </summary>
///////////////

public class TM_Item_ConsumableFood_UI : TM_ItemUI_Base
{
    ////////////////////////////////

    public TM_Item_ConsumableFood_SO originalScriptableItem;

    ////////////////////////////////

    public string ItemName { get; set; }
    public string ItemDesc { get; set; }
    public Sprite ItemIcon { get; set; }
    public int MaxDurablity { get; set; }
    public int CurrentDurablity { get; set; }
    public int MaxStackSize { get; set; }
    public int CurrentStackSize { get; set; }

    ////////////////////////////////

    [Header("Item Stats (Consumable Food)")]
    public string hunger;
    public string health;

    ///////////////////////////////////////////////////////

    public TM_Item_ConsumableFood_UI(TM_Item_ConsumableFood_SO scriptableItem)
    {
        //Set Original Scriptable Object
        originalScriptableItem = scriptableItem;

        //Interface Stats
        ItemName = originalScriptableItem.itemName;
        ItemDesc = originalScriptableItem.itemDesc;
        ItemIcon = originalScriptableItem.itemIcon;

        MaxDurablity = originalScriptableItem.maxDurablity;
        CurrentDurablity = originalScriptableItem.currentDurablity;
        MaxStackSize = originalScriptableItem.maxStackSize;
        CurrentStackSize = originalScriptableItem.currentStackSize;


        //Others
        hunger = originalScriptableItem.hunger;
        health = originalScriptableItem.health;
    }

    ///////////////////////////////////////////////////////
}

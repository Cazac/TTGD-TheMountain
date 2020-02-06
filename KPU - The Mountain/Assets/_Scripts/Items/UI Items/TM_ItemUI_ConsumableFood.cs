using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_UI 
/// 
/// </summary>
///////////////

public class TM_ItemUI_ConsumableFood : TM_ItemUI_Base
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
    public bool IsBurnable { get; set; }

    ////////////////////////////////

    [Header("Item Stats (Consumable Food)")]
    public string hunger;
    public string health;

    ///////////////////////////////////////////////////////

    public TM_ItemUI_ConsumableFood(TM_Item_ConsumableFood_SO scriptableItem)
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

    public TM_ItemUI_ConsumableFood(TM_ItemUI_ConsumableFood originalItem)
    {
        //Set Original Scriptable Object
        originalScriptableItem = originalItem.originalScriptableItem;

        //Interface Stats
        ItemName = originalItem.ItemName;
        ItemDesc = originalItem.ItemDesc;
        ItemIcon = originalItem.ItemIcon;

        MaxDurablity = originalItem.MaxDurablity;
        CurrentDurablity = originalItem.CurrentDurablity;
        MaxStackSize = originalItem.MaxStackSize;
        CurrentStackSize = originalItem.CurrentStackSize;


        //Others
        hunger = originalScriptableItem.hunger;
        health = originalScriptableItem.health; 
    }

    ///////////////////////////////////////////////////////
}

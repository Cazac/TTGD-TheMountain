/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemUI_ConsumablePotions : TM_ItemUI_Base
{
    ////////////////////////////////

    public TM_Item_ConsumablePotions_SO originalScriptableItem;

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

    //[Header("Item Stats (Equiptable Weapons)")]
    //public string hunger;
    //public string health;

    ///////////////////////////////////////////////////////

    public TM_ItemUI_ConsumablePotions(TM_Item_ConsumablePotions_SO scriptableItem)
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

        IsBurnable = originalScriptableItem.isBurnable;
       
        //Others
        // hunger = originalScriptableItem.hunger;
        //health = originalScriptableItem.health;
    }

    public TM_ItemUI_ConsumablePotions(TM_ItemUI_ConsumablePotions originalItem)
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

        IsBurnable = originalItem.IsBurnable;

        //Others
        //hunger = originalScriptableItem.hunger;
        //health = originalScriptableItem.health;
    }
}
*/

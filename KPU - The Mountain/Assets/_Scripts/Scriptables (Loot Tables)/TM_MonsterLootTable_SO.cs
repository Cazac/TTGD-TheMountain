using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable Monster", menuName = "Scriptables/LootTable Monster")]
public class TM_MonsterLootTable_SO : ScriptableObject
{
    ////////////////////////////////

    [Header("Common Loot")]
    [Range(0, 100)]
    public int commonChance;
    public int commonRolls;
    public List<TM_LootItem_SO> commonItems;

    [Header("Uncommon Loot")]
    [Range(0, 100)]
    public int uncommonChance;
    public int uncommonRolls;
    public List<TM_LootItem_SO> uncommonItems;

    [Header("Rare Loot")]
    [Range(0, 100)]
    public int rareChance;
    public int rareRolls;
    public List<TM_LootItem_SO> rareItems;

    /////////////////////////////////////////////////////////////////
}

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

    public List<TM_Item_SO> GetLootDrops()
    {
        //Setup List
        List<TM_Item_SO> item_List = new List<TM_Item_SO>();

        //Common Rolls
        for (int i = 0; i < commonRolls; i++)
        {
            //Get Random Value
            int randomChance = Random.Range(1, 100);

            //Common Chance
            if (randomChance <= commonChance)
            {
                //Get Random Loot Item
                TM_LootItem_SO listedItem = commonItems[Random.Range(0, commonItems.Count - 1)];

                //Get Item SO
                TM_Item_SO itemSO = listedItem.lootItem;

                //Loop Foreach Drop Count
                for (int f = 0; f < Random.Range(listedItem.minDropCount, listedItem.maxDropCount); f++)
                {
                    //Add To List
                    item_List.Add(itemSO);
                }
            }
        }


        //Uncommon Rolls
        for (int i = 0; i < uncommonRolls; i++)
        {
            //Get Random Value
            int randomChance = Random.Range(1, 100);

            //Uncommon Chance
            if (randomChance <= uncommonChance)
            {
                //Get Random Loot Item
                TM_LootItem_SO listedItem = uncommonItems[Random.Range(0, uncommonItems.Count - 1)];

                //Get Item SO
                TM_Item_SO itemSO = listedItem.lootItem;

                //Loop Foreach Drop Count
                for (int f = 0; f < Random.Range(listedItem.minDropCount, listedItem.maxDropCount); f++)
                {
                    //Add To List
                    item_List.Add(itemSO);
                }
            }
        }


        //Rare Rolls
        for (int i = 0; i < rareRolls; i++)
        {
            //Get Random Value
            int randomChance = Random.Range(1, 100);

            //Rare Chance
            if (randomChance <= rareChance)
            {
                //Get Random Loot Item
                TM_LootItem_SO listedItem = rareItems[Random.Range(0, rareItems.Count - 1)];

                //Get Item SO
                TM_Item_SO itemSO = listedItem.lootItem;

                //Loop Foreach Drop Count
                for (int f = 0; f < Random.Range(listedItem.minDropCount, listedItem.maxDropCount); f++)
                {
                    //Add To List
                    item_List.Add(itemSO);
                }
            }
        }


        //Return List
        return item_List;
    }

    /////////////////////////////////////////////////////////////////
}

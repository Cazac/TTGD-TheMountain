using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LootTable Item Node", menuName = "Scriptables/LootTable Item Node")]
public class TM_ItemNodeLootTable_SO : ScriptableObject
{
    ////////////////////////////////

    [Header("Loot")]
    [Range(0, 100)]
    public int lootChance;
    public List<TM_Item_SO> lootItems;

    /////////////////////////////////////////////////////////////////

    public TM_Item_SO GetLootDrop()
    {
        //Get Random Value
        int randomChance = Random.Range(1, 100);

        //Common Chance
        if (randomChance <= lootChance)
        {
            //Get Random Loot Item
            TM_Item_SO itemSO = lootItems[Random.Range(0, lootItems.Count - 1)];

            return itemSO;
        }
        else
        {
            return null;
        }
    }

    /////////////////////////////////////////////////////////////////

}

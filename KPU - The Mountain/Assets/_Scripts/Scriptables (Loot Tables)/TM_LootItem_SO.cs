using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loot Item", menuName = "Scriptable Objects/Loot Item")]
public class TM_LootItem_SO : ScriptableObject
{


    [Header("Item Scriptable")]
    public TM_Item_SO lootItem;

    [Header("Min Max")]
    public int minDropCount;
    public int maxDropCount;



}

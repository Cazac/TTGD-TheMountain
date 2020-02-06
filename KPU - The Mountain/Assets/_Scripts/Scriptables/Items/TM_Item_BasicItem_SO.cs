using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Basic")]
public class TM_Item_BasicItem_SO : ScriptableObject
{
    //////////////////////////////// - Prefabs

    [Header("Item Prefabs")]
    public GameObject UI_Prefab;
    public GameObject placed_Prefab;
    public GameObject dropped_Prefab;

    //////////////////////////////// - Consumable Food Stats

    [Header("Item Descriptions")]
    public string name;
    public string desc;

    public int stackSize;

    ///////////////////////////////////////////////////////

    public void SpawnItem_Placed()
    {
        Debug.Log("Test Code: Spawned");

        //Spawn Object
        GameObject spawnedItem = Instantiate(dropped_Prefab);


        //Position? 
        //Parents?


        //Get Script
        TM_ItemPlaced SpawnedItem_Script = spawnedItem.GetComponent<TM_ItemPlaced>();

        //Construct Values
        SpawnedItem_Script.name = name;
        SpawnedItem_Script.ItemDesc = desc;
        SpawnedItem_Script.CurrentStackSize = stackSize;

    }

    ///////////////////////////////////////////////////////
}
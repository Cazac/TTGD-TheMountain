using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item Consumable Potion")]
public class TM_Item_ConsumablePotions_SO : MonoBehaviour
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

    [Header("Item Stats")]
    public string hunger;
    public string health;


    ///////////////////////////////////////////////////////

    public void SpawnItem_Placed()
    {
        Debug.Log("Test Code: Spawned");

        //Spawn Object
        GameObject spawnedItem = Instantiate(dropped_Prefab);


        //Position? 
        //Parents?


        //Get Script
        TM_Item_ConsumableFood_Placed SpawnedItem_Script = spawnedItem.GetComponent<TM_Item_ConsumableFood_Placed>();

        //Construct Values
        SpawnedItem_Script.name = name;
        SpawnedItem_Script.desc = desc;
        SpawnedItem_Script.stackSize = stackSize;
        SpawnedItem_Script.hunger = hunger;
        SpawnedItem_Script.health = health;

    }

    ///////////////////////////////////////////////////////
}
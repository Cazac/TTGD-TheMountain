using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_SO is the scriptable object to create the Consumable Food Item.
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Items/Consumable Food")]
public class TM_Item_ConsumableFood_SO : ScriptableObject
{
    //////////////////////////////// - Prefabs

    [Header("Item Prefabs")]
    public GameObject placed_Prefab;
    public GameObject dropped_Prefab;

    //////////////////////////////// - Consumable Food Stats

    [Header("Item Descriptions")]
    public string name;
    public string desc;
    public Sprite icon;

    [Header("Item UI Info")]
    public int maxDurablity;
    public int currentDurablity;
    public int maxStackSize;

    ////////////////////////////////

    [Header("Item Stats (Consumable Food)")]
    public string hunger;
    public string health;

    ///////////////////////////////////////////////////////

    public void SpawnItem_Placed(Vector3 position, GameObject parent)
    {
        Debug.Log("Test Code: Spawned Item");

        //Spawn Object
        GameObject spawnedItem = Instantiate(dropped_Prefab);


        //Position? 
        //Parents?


        //Get Script
        TM_Item_ConsumableFood_Placed SpawnedItem_Script = spawnedItem.GetComponent<TM_Item_ConsumableFood_Placed>();

        //Construct Values
        SpawnedItem_Script.name = name;
        SpawnedItem_Script.desc = desc;
        SpawnedItem_Script.stackSize = maxStackSize;
        SpawnedItem_Script.hunger = hunger;
        SpawnedItem_Script.health = health;

    }

    ///////////////////////////////////////////////////////
}

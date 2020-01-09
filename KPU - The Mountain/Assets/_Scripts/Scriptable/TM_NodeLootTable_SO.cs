using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node LootTable", menuName = "Scriptable Objects/Node LootTable")]
public class TC_NodeLootTable_SO : ScriptableObject
{

    public List<int> minValues_list = new List<int>();
    public List<int> maxValues_list = new List<int>();
    public List<int> chanceValues_list = new List<int>();
    public List<float> percentValues_list = new List<float>();
    public List<GameObject> PrefabValues_list = new List<GameObject>();




    [Header("Banner ID")]
    public List<string> items;

    //public List<float>



    public void SelectLootItem()
    {
        //Get Random Gen Value From Controller


        //Get Random Item
        int randomValue = Random.Range(0, 101);



        float cumulative = 0f;

        //Loop All Loot Items
        for (int i = 0; i < percentValues_list.Count; i++)
        {
            //Add The Values Cumulativly to get the next range of probablity
            cumulative += percentValues_list[i];
            
            //Check if Item was found in the cumulative value
            if (randomValue < cumulative)
            {
            

                GameObject selectedItem = PrefabValues_list[i];

                Debug.Log("Test Code: Found " + selectedItem.name);
                break;
            }
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TM_BiomeGenerator : MonoBehaviour
{
    ////////////////////////////////

    [Header("Biome")]
    //public GameObject BiomeMapPreset;

    public GameObject BiomeSpawnParent;

    public GameObject BiomeSpawn_Prefab;
    public GridLayoutGroup gridLayout;


    private int currentIteration;
    private int[] currentBiomeMap;
    private int[] nextBiomeMap;
    private int[] coloredBiomeMap;


    ///////////////////////////////////////////////////////

    void Awake()
    {
        CreateDefaultBiome();




        StartCoroutine(SpawnDebugUI());



        Expand();
    }


    ///////////////////////////////////////////////////////



    private void CreateDefaultBiome()
    {
        ////////////////////////////////
       
        //Number Codes

        //Stone Dungeon     - 1
        //Fire Biome        - 2
        //Frost Biome       - 3

        ////////////////////////////////

        //Create Biome Array
        currentBiomeMap = new int[]
        {
            //Row 1
            3, 3, 2, 3, 3,

            //Row 2
            2, 1, 1, 1, 2,

            //Row 3 (Middle)
            2, 1, 1, 1, 2,

            //Row 4
            3, 1, 1, 1, 3,

            //Row 5
            2, 1, 1, 3, 3,
        };
    }

    private void SpawnIcon(int biomeInt)
    {
        //Spawn Prefab
        GameObject biomeNode = Instantiate(BiomeSpawn_Prefab, BiomeSpawnParent.transform);

        //set scale
        biomeNode.transform.localScale = new Vector3(1f, 1f, 1f);

        //set color
        switch (biomeInt)
        {
            case 0:
                biomeNode.GetComponent<Image>().color = Color.white;
                break;

            case 1:
                biomeNode.GetComponent<Image>().color = Color.grey;
                break;

            case 2:
                biomeNode.GetComponent<Image>().color = Color.red;
                break;

            case 3:
                biomeNode.GetComponent<Image>().color = Color.blue;
                break;
        }
    }

    private IEnumerator SpawnDebugUI()
    {

        foreach (int biomeInt in currentBiomeMap)
        {
            //Spawn
            SpawnIcon(biomeInt);

            //Wait
            yield return new WaitForSeconds(0.05f);
        }







        ////////////////////////////////

        //Expand
        foreach (Transform child_GO in BiomeSpawnParent.transform)
        {
            Destroy(child_GO.gameObject);
        }


        //print("Test Code: " + currentBiomeMap.Length);

        //int nextSize = (int)Mathf.Pow(currentBiomeMap.Length, 2f);
        int nextSize = currentBiomeMap.Length * 4;
        int rowSize = currentBiomeMap.Length * 2;

        //print("Test Code: " + nextSize);

        nextBiomeMap = new int[nextSize];
        coloredBiomeMap = new int[nextSize];

        //////////////////////////////// - coloring






        int counter = 0;
        int coloringCounter = 0;

        foreach (int biomeInt in currentBiomeMap)
        {

            //First is empty
            nextBiomeMap[counter] = 0;

            //Second Is Full
            nextBiomeMap[counter + 1] = biomeInt;

            counter++;
            counter++;


            if (counter % 10 == 0)
            {
                counter += 10;
            }


        }


        //Filter out whuite values
        foreach (int biomeInt in nextBiomeMap)
        {
            if (biomeInt == 0)
            {
                //Look for new node from left or right



                //coloredBiomeMap[]
            }




        }




        gridLayout.cellSize = new Vector3(50f, 50f);
        gridLayout.constraintCount = gridLayout.constraintCount * 2;







        ////////////////////////////////

        foreach (int biomeInt in nextBiomeMap)
        {
            //Spawn
            SpawnIcon(biomeInt);

            //Wait
            yield return new WaitForSeconds(0.1f);
        }



        yield break;
    }



    private void CheckForValidValue()
    {

    }

    private int ChoseRandomValue(int NorthValue, int EastValue, int SouthValue, int WestValue)
    {
        int FinalValue = 1;



        List<int> Values_LIST = new List<int>();
        List<int> NewValues_LIST = new List<int>();

        Values_LIST.Add(NorthValue);
        Values_LIST.Add(EastValue);
        Values_LIST.Add(SouthValue);
        Values_LIST.Add(WestValue);

        foreach (int value in Values_LIST)
        {
            //THIS IS NOT VALID????
            if (value != null)
            {
                NewValues_LIST.Add(value);
            }
        }



        int randomValue = Random.Range(0, Values_LIST.Count + 1);
        print("Test Code: Random " + randomValue);



        FinalValue = Values_LIST[randomValue];



        return FinalValue;
    }



    private void Expand()
    {
        

    }


    ///////////////////////////////////////////////////////
}

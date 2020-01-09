using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TC_NodeLootTable_SO))]
public class TM_NodeLootTable_GUI : Editor
{
    [SerializeField]
    int lootTableCount = 0;

    [SerializeField]
    List<int> minValues_list = new List<int>();

    [SerializeField]
    List<int> maxValues_list = new List<int>();

    [SerializeField]
    List<int> chanceValues_list = new List<int>();

    [SerializeField]
    List<float> chancePercent_list = new List<float>();

    [SerializeField]
    List<GameObject> PrefabValues_list = new List<GameObject>();


    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        //Get Target Loot Table Scriptable Object
        TC_NodeLootTable_SO loot = (TC_NodeLootTable_SO)target;

        //Title Bar
        EditorGUILayout.InspectorTitlebar(true, loot);
        GUILayout.Space(10);

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);


        //Button
        if (GUILayout.Button("Load Table", GUILayout.Height(30)))
        {
            minValues_list.Clear();
            maxValues_list.Clear();
            chanceValues_list.Clear();
            chancePercent_list.Clear();
            PrefabValues_list.Clear();

            lootTableCount = loot.maxValues_list.Count;

            //Loop Each Item In Table
            for (int i = 0; i < lootTableCount; i++)
            {
                minValues_list.Add(loot.minValues_list[i]);
                maxValues_list.Add(loot.maxValues_list[i]);
                chanceValues_list.Add(loot.chanceValues_list[i]);
                chancePercent_list.Add(loot.percentValues_list[i]);
                PrefabValues_list.Add(loot.PrefabValues_list[i]);
            }

            Debug.Log("Test Code: Loaded");
        }


        //Button
        if (GUILayout.Button("Save Table", GUILayout.Height(30)))
        {
            loot.minValues_list.Clear();
            loot.maxValues_list.Clear();
            loot.chanceValues_list.Clear();
            loot.percentValues_list.Clear();
            loot.PrefabValues_list.Clear();

            //Loop Each Item In Table
            for (int i = 0; i < lootTableCount; i++)
            {
                loot.minValues_list.Add(minValues_list[i]);
                loot.maxValues_list.Add(maxValues_list[i]);
                loot.chanceValues_list.Add(chanceValues_list[i]);
                loot.percentValues_list.Add(chancePercent_list[i]);
                loot.PrefabValues_list.Add(PrefabValues_list[i]);
            }

            Debug.Log("Test Code: Saved");
        }

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        //Top Bar
        EditorGUILayout.BeginHorizontal("GroupBox");
        lootTableCount = EditorGUILayout.IntField("Loot Items Count", lootTableCount);
        EditorGUILayout.EndHorizontal();

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        //If Needed Add More Values
        while (minValues_list.Count < lootTableCount)
        {
            minValues_list.Add(0);
            maxValues_list.Add(0);
            chanceValues_list.Add(0);
            chancePercent_list.Add(0);
            PrefabValues_list.Add(null);
        }

        //Loop Each Item In Table
        for (int i = 0; i < lootTableCount; i++)
        {
            //Start Box
            EditorGUILayout.BeginVertical("GroupBox");

            //Top Line
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Item Prefab");
            //EditorGUILayout.ObjectField(PrefabValues_list[i], typeof(GameObject), false);
            PrefabValues_list[i] = EditorGUILayout.ObjectField(PrefabValues_list[i], typeof(GameObject), false) as GameObject;
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();

            GUILayout.Label("Min");
            minValues_list[i] = EditorGUILayout.IntField(minValues_list[i]);

            GUILayout.Label("Max");
            maxValues_list[i] = EditorGUILayout.IntField(maxValues_list[i]);

            GUILayout.Label("Chance");
            chanceValues_list[i] = EditorGUILayout.IntField(chanceValues_list[i]);

            float chanceSum = chanceValues_list.Sum();
            float chanceInt = chanceValues_list[i];
            float chancePercent = (chanceInt / chanceSum) * 100;
            string chanceString = string.Format("{0:00.0}", chancePercent);

            chancePercent_list[i] = chancePercent;

            GUILayout.Label("Spawn %");
            EditorGUILayout.TextField(chanceString);

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);


        /*

        //Button
        if (GUILayout.Button("Trim List", GUILayout.Height(30)))
        {
            GUI.backgroundColor = Color.yellow;

            if (lootTableCount <= 0)
            {
                minValues_list.Clear();
                maxValues_list.Clear();
                chanceValues_list.Clear();
                PrefabValues_list.Clear();
            }
            else
            {
                while (minValues_list.Count > lootTableCount)
                {
                    minValues_list.RemoveAt(lootTableCount - 1);
                }

                while (maxValues_list.Count > lootTableCount)
                {
                    maxValues_list.RemoveAt(lootTableCount - 1);
                }

                while (chanceValues_list.Count > lootTableCount)
                {
                    chanceValues_list.RemoveAt(lootTableCount - 1);
                }

                while (PrefabValues_list.Count > lootTableCount)
                {
                    PrefabValues_list.RemoveAt(lootTableCount - 1);
                }
            }

            Debug.Log("Test Code: Trimmed");
        }

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        //Button
        if (GUILayout.Button("Clear List", GUILayout.Height(30)))
        {
            lootTableCount = 0;

            minValues_list.Clear();
            maxValues_list.Clear();
            chanceValues_list.Clear();
            PrefabValues_list.Clear();

            Debug.Log("Test Code: Cleared");
        }

        //Spacing bar
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

    */
    }
}

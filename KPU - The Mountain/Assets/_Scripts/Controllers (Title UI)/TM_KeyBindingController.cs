﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_KeyBindingController 
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_KeyBindingController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_KeyBindingController Instance;

    ////////////////////////////////

    public static string KB_PATH; //Uses a persistent data path that will never change because it is based on the system, not the application

    //Reference for the initial button text names
    public GameObject BindingInputs;

    GameObject currentButton;//Used OnClick() to hold a reference to button that is currently being changed
    KeyCode newKey;//New key to be set
    bool waitingForKey = false;//Flag to wait for the key press


    string jsonFile;
    //JSON File used to initialize dictionary



    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
        KB_PATH = Application.persistentDataPath + "/keybindings.json";
    }

    private void Start()
    {
        if (System.IO.File.Exists(KB_PATH))//Tries to find saved JSON file in cache
        {
            jsonFile = System.IO.File.ReadAllText(KB_PATH);
            //Debug.Log("Loaded bindings from saved file");
        }
        else //If not, loads default JSON file
        {
            TextAsset jsonAsset = Resources.Load("keybindings") as TextAsset;
            jsonFile = jsonAsset.text;
            //Debug.Log("Loaded default bindings");
        }
        TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary = new Dictionary<string, KeyCode>(); //Initialize keycode dictionary
        KeyBindingList bindingsInJSON = JsonUtility.FromJson<KeyBindingList>(jsonFile);//Convert JSON into serializable strings

        foreach (KeyBinding k in bindingsInJSON.bindings)
        {
            //Debug.Log("Found binding: " + k.key + " for  " + k.action);

            TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary.Add(k.action, (KeyCode)System.Enum.Parse(typeof(KeyCode), k.key));//Adds binding to dictionary
        }
        //Debug.Log("Successfully parsed initial JSON bindings");

        //Setting initial loaded bindings as button texts
        for (int i = 0; i < BindingInputs.transform.childCount; i++)
        {

            GameObject button = BindingInputs.transform.GetChild(i).gameObject;
            //print("Test Code: " + button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().name);
            button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary[button.name].ToString());

            //print("Test Code: " + button.name);
        }
    }

    private void OnGUI()
    {
        Event e = Event.current; //Captures anything that is happening in game
        if (e.shift && waitingForKey)//If Shift is pressed as key
        {
            if (Input.GetKey(KeyCode.LeftShift))//Left Shift
            {
                newKey = KeyCode.LeftShift;
            }
            else if (Input.GetKey(KeyCode.RightShift))//Right Shift
            {
                newKey = KeyCode.RightShift;
            }
            waitingForKey = false;
        }
        else if (e.isKey && waitingForKey)//Everything else
        {
            newKey = e.keyCode; //Set that key as keycode
            waitingForKey = false; //Stop waiting for key
        }
        else if (e.isMouse)
        {
            if (e.button == 0)
            {
                newKey = KeyCode.Mouse0;
                waitingForKey = false;
            }
            else if (e.button == 1)
            {
                newKey = KeyCode.Mouse1;
                waitingForKey = false;
            }
            else if (e.button == 2)
            {
                newKey = KeyCode.Mouse2;
                waitingForKey = false;
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void ChangeKeyStart(GameObject button)
    {
        if (!waitingForKey)//Allows only one binding to be changed at a time
        {
            currentButton = button;
            string txt = currentButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;
            //Set text to red
            currentButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText("<color=#FF0800>" + txt + "</color>");
            waitingForKey = true;
            StartCoroutine(EditKeyFlag());
        }
    }

    public void ChangeKeyEnd()
    {
        if (newKey == KeyCode.Escape)
        {
            newKey = KeyCode.None;
            TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary[currentButton.name] = newKey;//Sets new key as part of binding dictionary
            SaveToJSON();
        }
        else
        {
            if (!TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary.ContainsValue(newKey))//Checks if binding already exists for a different key (or the current key)
            {
                TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary[currentButton.name] = newKey;//Sets new key as part of binding dictionary
                SaveToJSON();
            }
        }

        
        //Sets text so that it turns back to white regardless of changed key or not
        currentButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary[currentButton.name].ToString());
        StopCoroutine(EditKeyFlag());//Save potential resources
    }
    //Converts current Dictionary structure into JSON string and saves into file
    public void SaveToJSON()
    {
        List<string> bindingActions = new List<string>(TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary.Keys);//Grab only keys
        List<KeyBinding> bindingKeys = new List<KeyBinding>();//Create list of KeyBinding class/struct
        foreach (string a in bindingActions)
        {
            bindingKeys.Add(new KeyBinding() { action = a, key = TM_DatabaseController.Instance.settings_SaveData.keybindings_Dictonary[a].ToString() });//Add each keybinding from dictionary into a List of struct KeyBinding
        }
        KeyBindingList saveBindingList = new KeyBindingList() { bindings = bindingKeys.ToArray() };//Convert into KeyBindingList

        string json = JsonUtility.ToJson(saveBindingList);//Convert to JSON
        System.IO.File.WriteAllText(KB_PATH, json);//Writes to file
    }

    //Coroutine to loop while we wait for a key to be pressed TODO: Maybe add a way to prevent other things from being able to be pressed?
    IEnumerator EditKeyFlag()
    {
        while (waitingForKey)
        {
            yield return null;
        }
        ChangeKeyEnd();
    }

    //Serialized structure used in parsing JSON
    [System.Serializable]
    public class KeyBinding
    {
        //these variables are case sensitive and must match the strings in the JSON.
        public string action;
        public string key;
    }
    //Serialized Array structure used in parsing JSON
    [System.Serializable]
    public class KeyBindingList
    {
        //bindings is case sensitive and must match the string "bindings" in the JSON.
        public KeyBinding[] bindings;
    }
}

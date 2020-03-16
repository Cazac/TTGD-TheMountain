using System.Collections;
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

    public static Dictionary<string, KeyCode> keybindings;

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
            Debug.Log("Loaded bindings from saved file");
        }
        else //If not, loads default JSON file
        {
            TextAsset jsonAsset = Resources.Load("keybindings") as TextAsset;
            jsonFile = jsonAsset.text;
            Debug.Log("Loaded default bindings");
        }
        keybindings = new Dictionary<string, KeyCode>(); //Initialize keycode dictionary
        KeyBindingList bindingsInJSON = JsonUtility.FromJson<KeyBindingList>(jsonFile);//Convert JSON into serializable strings

        foreach (KeyBinding k in bindingsInJSON.bindings)
        {
            Debug.Log("Found binding: " + k.key + " for  " + k.action);

            keybindings.Add(k.action, (KeyCode)System.Enum.Parse(typeof(KeyCode), k.key));//Adds binding to dictionary
        }
        Debug.Log("Successfully parsed initial JSON bindings");

        //Setting initial loaded bindings as button texts
        for(int i = 0; i < BindingInputs.transform.childCount; i++)
        {
            GameObject button = BindingInputs.transform.GetChild(i).gameObject;
            button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(keybindings[button.name].ToString());
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
    }

    ///////////////////////////////////////////////////////

    public void ChangeKeyStart(GameObject button)
    {
        if (!waitingForKey)//Allows only one binding to be changed at a time
        {
            currentButton = button;
            waitingForKey = true;
            StartCoroutine(EditKeyFlag());
        }
    }

    public void ChangeKeyEnd()
    {
        if (!keybindings.ContainsValue(newKey))//Checks if binding already exists for a different key (or the current key)
        {
            keybindings[currentButton.name] = newKey;//Sets new key as part of binding dictionary
            SaveToJSON();
            currentButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(keybindings[currentButton.name].ToString());
        }
        StopCoroutine(EditKeyFlag());//Save potential resources
    }
    //Converts current Dictionary structure into JSON string and saves into file
    public void SaveToJSON()
    {
        List<string> bindingActions = new List<string>(keybindings.Keys);//Grab only keys
        List<KeyBinding> bindingKeys = new List<KeyBinding>();//Create list of KeyBinding class/struct
        foreach (string a in bindingActions)
        {
            bindingKeys.Add(new KeyBinding() {action = a, key = keybindings[a].ToString()});//Add each keybinding from dictionary into a List of struct KeyBinding
        }
        KeyBindingList saveBindingList = new KeyBindingList(){bindings = bindingKeys.ToArray()};//Convert into KeyBindingList

        string json = JsonUtility.ToJson(saveBindingList);//Convert to JSON
        System.IO.File.WriteAllText(KB_PATH, json);//Writes to file
        Debug.Log("Saved to File");
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

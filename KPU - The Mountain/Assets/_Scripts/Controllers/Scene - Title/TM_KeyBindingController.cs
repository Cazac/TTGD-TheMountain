using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_KeyBindingController : MonoBehaviour
{
    public static TM_KeyBindingController Instance;

    public KeyCode newKey;
    public bool waitingForKey = false;//Waits for the key press
    public GameObject currentButton;

    public static Dictionary<string, KeyCode> keybindings;

    public TextAsset jsonFile;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        jsonFile = Resources.Load("keybindings") as TextAsset; //Loads JSON File
        keybindings = new Dictionary<string, KeyCode>(); //Initialize keycode dictionary
        KeyBindingList bindingsInJSON = JsonUtility.FromJson<KeyBindingList>(jsonFile.text);//Convert JSON into serializable strings

        foreach (KeyBinding k in bindingsInJSON.bindings)
        {
            Debug.Log("Found binding: " + k.key + " for  " + k.action);

            keybindings.Add(k.action, (KeyCode)System.Enum.Parse(typeof(KeyCode), k.key));
        }
        Debug.Log("Successfully parsed initial JSON bindings");
    }

    void OnGUI()
    {
        Event e = Event.current; //Captures anything that is happening in the game
        if (e.shift && waitingForKey)
        {
            Debug.Log(e.modifiers);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                newKey = KeyCode.LeftShift;
            }
            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                newKey = KeyCode.RightShift;
            }
            waitingForKey = false; //Stop waiting for key
        }
        else if (e.isKey && waitingForKey)
        {
            newKey = e.keyCode; //Set that key as keycode
            waitingForKey = false; //Stop waiting for key
        }
    }

    public void ChangeKeyStart(GameObject button)
    {
        if (!waitingForKey)//Allows only one binding to be changed at a time
        {
            currentButton = button;
            Debug.Log(currentButton.name + " is pressed");
            waitingForKey = true;
            Debug.Log("Current Binding: " + keybindings[button.name]);
            StartCoroutine(EditKeyFlag());
        }
    }

    public void ChangeKeyEnd()
    {
        Debug.Log(newKey);
        StopCoroutine(EditKeyFlag());//Save potential resources
        Debug.Log("end coroutine");        
    }

    IEnumerator EditKeyFlag() //Coroutine to loop while we wait for a key to be pressed
    {
        Debug.Log("start coroutine");
        while (waitingForKey)
        {
            yield return null;
        }
        ChangeKeyEnd();
    }

    [System.Serializable]
    public class KeyBinding
    {
        //these variables are case sensitive and must match the strings in the JSON.
        public string action;
        public string key;
    }

    [System.Serializable]
    public class KeyBindingList
    {
        //bindings is case sensitive and must match the string "bindings" in the JSON.
        public KeyBinding[] bindings;
    }
}

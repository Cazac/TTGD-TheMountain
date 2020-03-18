using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///////////////
/// <summary>
///     
/// TM_KeyBindingController is the converted version of Shawn's Keybinding with formatting and Savedata 
/// 
/// WORK IN PROGRESS NOT CURRENTLY ACTIVE
/// 
/// 
/// </summary>
///////////////

public class NewKeybinging : MonoBehaviour
{
    ////////////////////////////////

    public static NewKeybinging Instance;

    ////////////////////////////////


    //public TextMeshProUGUI moveLeftButton_Text



    public List<GameObject> BindingInputs_Lists;


    private GameObject currentButton;//Used OnClick() to hold a reference to button that is currently being changed


    KeyCode newKey;//New key to be set
    bool waitingForKey = false;//Flag to wait for the key press



    ////////////////////////////////





    


    ///////////////////////////////////////////////////////

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Load Keybindings From Player
        //TM_DatabaseController.Instance.settings_SaveData.keycode_MoveLeft;


        SetValuesToButtons();





        
  
    }





    private void SetValuesToButtons()
    {



        //Setting initial loaded bindings as button texts
        //for (int i = 0; i < BindingInputs.transform.childCount; i++)
        {

            //GameObject button = BindingInputs.transform.GetChild(i).gameObject;
            //print("Test Code: " + button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().name);
            //button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(keybindings[button.name].ToString());

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
        //if (!keybindings.ContainsValue(newKey))//Checks if binding already exists for a different key (or the current key)
        {
            //keybindings[currentButton.name] = newKey;//Sets new key as part of binding dictionary
            //SaveToJSON();
            //currentButton.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().SetText(keybindings[currentButton.name].ToString());
        }
        StopCoroutine(EditKeyFlag());//Save potential resources
    }








    //Converts current Dictionary structure into JSON string and saves into file
    public void SaveToJSON()
    {
        //List<string> bindingActions = new List<string>(keybindings.Keys);//Grab only keys
        List<KeyBinding> bindingKeys = new List<KeyBinding>();//Create list of KeyBinding class/struct
       // foreach (string a in bindingActions)
        //{
            //bindingKeys.Add(new KeyBinding() { action = a, key = keybindings[a].ToString() });//Add each keybinding from dictionary into a List of struct KeyBinding
       /// }
        //KeyBindingList saveBindingList = new KeyBindingList() { bindings = bindingKeys.ToArray() };//Convert into KeyBindingList

        //string json = JsonUtility.ToJson(saveBindingList);//Convert to JSON
        //System.IO.File.WriteAllText(KB_PATH, json);//Writes to file
        //Debug.Log("Saved to File");
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

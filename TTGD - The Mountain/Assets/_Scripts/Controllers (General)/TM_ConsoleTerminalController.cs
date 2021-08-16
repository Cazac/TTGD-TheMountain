using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///////////////
/// <summary>
///     
/// TM_ConsoleTerminalController 
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////


public class TM_ConsoleTerminalController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ConsoleTerminalController Instance;

    ////////////////////////////////

    //Open Console Terminal Panel
    public GameObject terminal_Panel;


    public bool terminal_IsActive;


    public TMP_InputField terminal_Inputfield;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        LookForCommandKey_Terminal();
    }

    ///////////////////////////////////////////////////////

    private void LookForCommandKey_Terminal()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (terminal_IsActive)
            {
                DeactivateTerminal();
            }
            else
            {
                ActivateTerminal();
            }
        }

        if (terminal_IsActive)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ProcessTerminalInput();
                DeactivateTerminal();
            }
        }
    }

    ///////////////////////////////////////////////////////

    private void ActivateTerminal()
    {
        //Open Termianl
        terminal_Panel.SetActive(true);

        //Pause Game
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = true;
        Time.timeScale = 0;


        //Read Input
        //terminal_Inputfield.ActivateInputField();
        terminal_Inputfield.Select();




        //Reverse Active State

        terminal_IsActive = true;


        Debug.Log("activated input field: " + terminal_Inputfield.isFocused);
    }

    private void DeactivateTerminal()
    {

        //Hide Terminal
        terminal_Panel.SetActive(false);

        terminal_Inputfield.ReleaseSelection();


        //Unpause Game
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = false;
        Time.timeScale = 1;

        //Set Bool
        terminal_IsActive = false;
    }

    ///////////////////////////////////////////////////////

    private void ProcessTerminalInput()
    {
        //Get String and Split it
        string[] splitInput_Array = terminal_Inputfield.text.Split(" "[0]);

        //Setup Command and Array
        string command = splitInput_Array[0];
        string value = "";


        print("Test Code: Command " + command);

        //Set Value
        if (splitInput_Array.Length > 1)
        {
            value = splitInput_Array[1];

            print("Test Code: Values " + value);
        }

        //Reset Input Field
        terminal_Inputfield.text = "";

        //Process Command
        switch (command)
        {
            case "Spawn":

               SpawnItem(value);

                break;
            case "FillHealth":
                
                break;
            case "FillHunger":
                
                break;
            case "FillStamina":
              
                break;
            case "invincible":
               
                break;
            case "help":
                 break;
            case "refillberries":
            
            default:

                //Set Help Text in debug log
                print("Test Code: Help");

                break;
        }
    }

    ///////////////////////////////////////////////////////

    private void SpawnItem(string itemID)
    {
        print("Test Code: Spawning Item...");

        //Process Value
        switch (itemID)
        {
            case "1":

                print("Test Code: Item 1 Spawned!");

                //TM_PlayerController_Inventory.Instance.toolbarItemSlots_Array[0] =

                break;

            default:

                //Set Help Text in debug log

                break;
        }


    }

    ///////////////////////////////////////////////////////
}

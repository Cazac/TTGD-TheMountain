using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_InputController_UI is used to search for keyboard input keys to use the basic UI menus.
/// This does not include the Item interaction menus.
/// 
/// </summary>
///////////////

public class TM_InputController_UI : MonoBehaviour
{
    ////////////////////////////////

    public static TM_InputController_UI Instance;

    ////////////////////////////////

    public GameObject PauseMenu_Panel;
    public GameObject InventoryMenu_Panel;
    public GameObject EventLogMenu_Panel;

    public bool gameState_IsPasued;
    public bool gameState_IsPlaying;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        //Search for keys
        LookForMenuKey_Pause();
        LookForMenuKey_Inventory();
        LookForMenuKey_Equipment();
        LookForMenuKey_Notes();
    }

    /////////////////////////////////////////////////////// - Menus

    private void LookForMenuKey_Pause()
    {
        //Check for Pause button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState_IsPasued)
            {
                //Close Panel
                PauseMenu_Panel.SetActive(false);
                gameState_IsPasued = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = false;
            }
            else
            {
                //Open Panel
                PauseMenu_Panel.SetActive(true);
                gameState_IsPasued = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
            }
        }
    }

    private void LookForMenuKey_Inventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {


        }
    }

    private void LookForMenuKey_Equipment()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {


        }
    }

    private void LookForMenuKey_Notes()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {


        }
    }

    /////////////////////////////////////////////////////// - Toolbar

    private void LookForMouseScroll_Toolbar()
    {

    }

    private void LookForSwapKey_Toolbar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_InputKey(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_InputKey(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_InputKey(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_InputKey(4);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_InputKey(5);
        }
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_PlayerController_UI controles the UI shown to the player
/// 
/// </summary>
///////////////

public class TM_PlayerController_UI : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_UI Instance;

    ////////////////////////////////

    [Header("Pause Menu")]
    public GameObject PauseMenu_Panel;

    [Header("Player Menus")]
    public GameObject PlayerMenu_Panel;
    public GameObject StatsMenu_Panel;
    public GameObject InventoryMenu_Panel;
    public GameObject EquipmentMenu_Panel;
    public GameObject LoreMenu_Panel;

    [Header("Home Base Menus")]
    public GameObject Fire_Panel;

    [Header("Other Menus")]
    public GameObject EventLogMenu_Panel;

    ////////////////////////////////

    [Header("Game Menu States")]
    public bool gameState_IsPasued;
    public bool gameState_IsMenu;
    public bool gameState_IsPlaying;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }
    
    private void Update()
    {
        //Look for key inputs
        LookForMenuKey_Pause();
        LookForMenuKey_Inventory();
        LookForMenuKey_Equipment();
    }

    ///////////////////////////////////////////////////////

    public void Button_Pause_Continue()
    {
        //Close Panel
        PauseMenu_Panel.SetActive(false);
        gameState_IsPasued = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Button_Pause_Settings()
    {
        //Save

        //Load Title Screen


    }

    public void Button_Pause_Save()
    {
        //Save

        //Load Title Screen


    }

    public void Button_Pause_Quit()
    {
        //Save

        //Load Title Screen


        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

        //Quit Application
        Application.Quit();

    }

    ///////////////////////////////////////////////////////

    public void Action_Fire_OpenUI()
    {
        //Tunr On Panel
        Fire_Panel.SetActive(true);

        //Enable Mouse
        UnlockMouse();

  

        //Load Stuff

    }

    public void Action_Fire_CloseUI()
    {
        //Tunr Off Panel
        Fire_Panel.SetActive(false);

        //Disable Mouse
        LockMouse();



        //Load Stuff


    }

    public void Action_Workbench_OpenUI()
    {

    }

    ///////////////////////////////////////////////////////

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
                LockMouse();
            }
            else
            {
                //Open Panel
                PauseMenu_Panel.SetActive(true);
                gameState_IsPasued = true;
                Time.timeScale = 0;
                UnlockMouse();
            }
        }
    }

    private void LookForMenuKey_Inventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameState_IsMenu)
            {
                //Close Panel
                PlayerMenu_Panel.SetActive(false);
                gameState_IsMenu = false;
                LockMouse();
            }
            else
            {
                //Open Panel
                PlayerMenu_Panel.SetActive(true);
                gameState_IsMenu = true;
                //InventoryMenu_Panel.SetActive(true);
                UnlockMouse();
            }
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

    private void LookForMenuKey_Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Look For Colliders To Interact with

        }

        if (Input.GetKey(KeyCode.F))
        {
            //Look For Colliders To Interact with

        }
    }

    ///////////////////////////////////////////////////////
    
    public void LockMouse()
    {
        //Hide Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Enable Movement
        TM_PlayerController_Movement.Instance.canPlayerMove = true;

        //Disable Interaction UI
        TM_InteractionController.Instance.playerInteraction_Text.gameObject.SetActive(true);
    }

    public void UnlockMouse()
    {
        //Allow Cusror to show
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Disable Movement
        TM_PlayerController_Movement.Instance.canPlayerMove = false;

        //Disable Interaction UI
        TM_InteractionController.Instance.playerInteraction_Text.gameObject.SetActive(false);
    }

    ///////////////////////////////////////////////////////
}

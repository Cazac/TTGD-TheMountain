using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// TM_PlayerController_UI controles the UI shown to the player
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_UI : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_UI Instance;

    ////////////////////////////////
    
    [Header("Player Menus")]
    public GameObject PlayerMenu_Panel;
    public GameObject InventoryMenu_Panel;
    public GameObject NotesMenu_Panel;
    public GameObject StatsMenu_Panel;

    [Header("Home Base Menus")]
    public GameObject Bed_Panel;
    public GameObject Brewery_Panel;
    public GameObject Canteen_Panel;
    public GameObject Dispenser_Panel;
    public GameObject Forge_Panel;
    public GameObject Fire_Panel;
    public GameObject Storage_Panel;
    public GameObject Workshop_Panel;

    [Header("Pause Menu")]
    public GameObject PauseMenu_Panel;
    public Image PauseMenu_PlayerClass_Image;
    public TextMeshProUGUI PauseMenu_PlayerName_Text;
    public TextMeshProUGUI PauseMenu_PlayerCycles_Text;

    [Header("System Menus")]
    public GameObject EventLogMenu_Panel;

    ////////////////////////////////

    [Header("Player Health UI")]
    public Image player_HealthCircleValue_Image;
    public TextMeshProUGUI player_HealthCircleValue_Text;

    [Header("Player Hunger UI")]
    public Image player_HungerCircleValue_Image;
    public TextMeshProUGUI player_HungerCircleValue_Text;

    [Header("Player Fire UI")]
    public Image player_FireCircleValue_Image;
    public TextMeshProUGUI player_FireCircleValue_Text;
    
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

        //Toolbar
        LookForMouseScroll_Toolbar();
        LookForSwapKey_Toolbar();
    }

    /////////////////////////////////////////////////////// - Button Inputs (Systems Menu)

    public void Button_Pause_Continue()
    {
        //Close Panel
        //Close Panel
        PauseMenu_Panel.SetActive(false);
        gameState_IsPasued = false;
        Time.timeScale = 1;
        LockMouse();
    }

    public void Button_Pause_Settings()
    {
        //Settings
        print("Test Code: Error No Settings Ready");

    }

    public void Button_Pause_Save()
    {
        //Save
        TM_SaveController.Instance.PlayerData_SaveGameData();
    }

    public void Button_Pause_Quit()
    {
        //Save
        TM_SaveController.Instance.PlayerData_SaveGameData();

        //Quit Editor
        #if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        #else
            //Application.Quit();
        #endif

        Time.timeScale = 1;

        //Quit Application
        SceneManager.LoadScene("TM_Title");
    }

    /////////////////////////////////////////////////////// - Button Inputs (Player Menu)

    public void Button_InventoryTab()
    {
        //Turn Off All Panels
        PlayerMenu_TurnOffPanels();

        //Open Panel
        PlayerMenu_Panel.SetActive(true);
        InventoryMenu_Panel.SetActive(true);
        gameState_IsMenu = true;
        UnlockMouse();
    }

    public void Button_StatsTab()
    {
        //Turn Off All Panels
        PlayerMenu_TurnOffPanels();

        //Open Panel
        PlayerMenu_Panel.SetActive(true);
        StatsMenu_Panel.SetActive(true);
        gameState_IsMenu = true;
        UnlockMouse();

        //Setup Panel
        TM_PlayerMenuController_Attributes.Instance.RefreshStatsUI();
    }

    public void Button_NotesTab()
    {
        //Turn Off All Panels
        PlayerMenu_TurnOffPanels();

        //Open Panel
        PlayerMenu_Panel.SetActive(true);
        NotesMenu_Panel.SetActive(true);
        gameState_IsMenu = true;
        UnlockMouse();
    }

    /////////////////////////////////////////////////////// - Look For Key Inputs

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

                PauseMenu_PlayerName_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name;
                PauseMenu_PlayerCycles_Text.text = "Cycles Survivied " + TM_PlayerController_Stats.Instance.playerInfo_CyclesSurvived.ToString();
                PauseMenu_PlayerClass_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(TM_PlayerController_Stats.Instance.playerInfo_Class);
            }
        }
    }

    private void LookForMenuKey_Inventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameState_IsMenu && InventoryMenu_Panel.activeSelf == true)
            {
                //Turn Off All Panels
                PlayerMenu_TurnOffPanels();

                //Close Panel
                PlayerMenu_Panel.SetActive(false);
                gameState_IsMenu = false;
                LockMouse();
            }
            else if (gameState_IsMenu && InventoryMenu_Panel.activeSelf == false)
            {
                //Turn Off All Panels
                PlayerMenu_TurnOffPanels();

                //Close Panel
                PlayerMenu_Panel.SetActive(false);
                gameState_IsMenu = false;
                LockMouse();
            }
            else
            {
                //Turn Off All Panels
                PlayerMenu_TurnOffPanels();

                //Open Panel
                PlayerMenu_Panel.SetActive(true);
                InventoryMenu_Panel.SetActive(true);
                gameState_IsMenu = true;
                UnlockMouse();
            }
        }
    }

    private void LookForMenuKey_Notes()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {

          
        }
    }

    private void LookForMenuKey_Stats()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

       
        }
    }

    private void LookForMenuKey_Map()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {


        }
    }

    ///////////////////////////////////////////////////////

    public void UpdateUI_HealthValue()
    {
        //Get Values
        int playerCurrentHealth = TM_PlayerController_Stats.Instance.player_CurrentHealth;
        int playerMaxHealth = TM_PlayerController_Stats.Instance.player_MaxHealth;

        //Set Values
        player_HealthCircleValue_Image.fillAmount = (float)((float)playerCurrentHealth / (float)playerMaxHealth);
        player_HealthCircleValue_Text.text = playerCurrentHealth + " / " + playerMaxHealth;
    }

    public void UpdateUI_HungerValue()
    {
        //Get Values
        int playerCurrentHunger = TM_PlayerController_Stats.Instance.player_CurrentHunger;
        int playerMaxHunger = TM_PlayerController_Stats.Instance.player_MaxHunger;

        //Set Values
        player_HungerCircleValue_Image.fillAmount = (float)((float)playerCurrentHunger / (float)playerMaxHunger);
        player_HungerCircleValue_Text.text = playerCurrentHunger + " / " + playerMaxHunger;
    }

    public void UpdateUI_FireValue()
    {
        //Get Values
        int playerCurrentFire = TM_PlayerController_Stats.Instance.player_CurrentFire;
        int playerMaxFire = TM_PlayerController_Stats.Instance.player_MaxFire;

        //Set Values
        player_FireCircleValue_Image.fillAmount = (float)((float)playerCurrentFire / (float)playerMaxFire);
        player_FireCircleValue_Text.text = playerCurrentFire + " / " + playerMaxFire;
    }

    /////////////////////////////////////////////////////// - Toolbar

    private void LookForMouseScroll_Toolbar()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            int newValue = TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition + 1;

            //Cap
            if (newValue > 8)
            {
                newValue = 0;
            }


            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(newValue);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // backwards
        {
            int newValue = TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition - 1;

            //Cap
            if (newValue < 0)
            {
                newValue = 8;
            }


            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(newValue);
        }
    }

    private void LookForSwapKey_Toolbar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(9);
        }
    }

    /////////////////////////////////////////////////////// - Utility

    public void PlayerMenu_TurnOffPanels()
    {
        //Basic Menus
        InventoryMenu_Panel.SetActive(false);
        StatsMenu_Panel.SetActive(false);
        NotesMenu_Panel.SetActive(false);

        //Other Menus
        if (Fire_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Fire.Instance.FireMenu_CloseUI();
        }
        if (Dispenser_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Dispenser.Instance.DispenserMenu_CloseUI();
        }
        if (Storage_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Storage.Instance.StorageMenu_CloseUI();
        }
        if (Brewery_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Brewery.Instance.BreweryMenu_CloseUI();
        }
        if (Canteen_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Canteen.Instance.CanteenMenu_CloseUI();
        }
        if (Forge_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Forge.Instance.ForgeMenu_CloseUI();
        }
        if (Workshop_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Workshop.Instance.WorkshopMenu_CloseUI();
        }
        if (Bed_Panel.activeSelf == true)
        {
            TM_HomeMenuController_Bed.Instance.BedMenu_CloseUI();
        }

        //Prob should be somewhere else
        TM_CursorController.Instance.Cursor_DropItem();
    }

    /////////////////////////////////////////////////////// - Utility

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

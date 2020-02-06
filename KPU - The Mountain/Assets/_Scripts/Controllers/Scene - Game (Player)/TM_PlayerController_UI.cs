using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

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
    public GameObject InventoryMenu_Panel;
    public GameObject NotesMenu_Panel;
    public GameObject StatsMenu_Panel;

    [Header("Home Base Menus")]
    public GameObject Fire_Panel;
    public GameObject Workshop_Panel;
    public GameObject Forge_Panel;

    [Header("Other Menus")]
    public GameObject EventLogMenu_Panel;

    ////////////////////////////////

    [Header("Game Menu States")]
    public bool gameState_IsPasued;
    public bool gameState_IsMenu;
    public bool gameState_IsPlaying;

    ////////////////////////////////

    [Header("Fire")]
    public GameObject fire_BurnableItem_Prefab;
    public GameObject fire_ContentContainer_GO;
    private GameObject fire_selectedBurnable_GO;
    public Button fire_burnItem_Button;


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
        TM_PlayerController_Stats.Instance.RefreshStatsUI();
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

    ///////////////////////////////////////////////////////



    /////////////////////////////////////////////////////// - Fire UI

    public void Action_Fire_OpenUI()
    {
        //Tunr On Panel
        Fire_Panel.SetActive(true);

        //Enable Mouse
        UnlockMouse();

        //Setup
        Action_Fire_RefreshList();
        Action_Fire_RefreshBar();
        Action_Fire_RefreshBurnButton();
    }

    public void Button_Fire_SelectBurnable(Button button)
    {
        if (fire_selectedBurnable_GO == button.gameObject)
        {
            fire_selectedBurnable_GO = null;
        }
        else
        {
            print("Test Code: Setting");
            fire_selectedBurnable_GO = button.gameObject;
        }

        Action_Fire_RefreshBurnButton();
    }

    public void Button_Fire_BurnItem()
    {

    }



    private void Action_Fire_RefreshList()
    {
        //Burnable Lists
        List<TM_ItemUI_Base> itemsBurnable_List = new List<TM_ItemUI_Base>();
        List<TM_ItemUI_Base> itemsBurnableFiltered_List = new List<TM_ItemUI_Base>();


        //Remove Old List Values
        foreach (Transform oldItem in fire_ContentContainer_GO.transform)
        {
            Destroy(oldItem.gameObject);
        }

        //Find Slots in Toolbar
        foreach (GameObject itemSlot in TM_PlayerController_Inventory.Instance.toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.currentItem != null)
            {
                if (slot.currentItem.IsBurnable)
                {
                    itemsBurnable_List.Add(slot.currentItem);
                }
            }
        }

        //Find Slots in Inventory
        foreach (GameObject itemSlot in TM_PlayerController_Inventory.Instance.playerItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.currentItem != null)
            {
                if (slot.currentItem.IsBurnable)
                {
                    itemsBurnable_List.Add(slot.currentItem);
                }
            }
        }


        bool canPass = false;
        TM_ItemUI_Base mergingItem = null;
        TM_ItemUI_Base removalItem_Basic = null;
        TM_ItemUI_Base removalItem_Listed = null;

        //Merge Items
        while (canPass == false)
        {
            for (int i = 0; i < itemsBurnable_List.Count; i++)
            {
                foreach (TM_ItemUI_Base item in itemsBurnable_List)
                {
                    if (itemsBurnable_List[i] != item)
                    {
                        if (itemsBurnable_List[i].ItemName == item.ItemName && itemsBurnable_List[i].CurrentDurablity == item.CurrentDurablity)
                        {
                            //Set Item Removal
                            removalItem_Basic = item;
                            removalItem_Listed = itemsBurnable_List[i];

                            //Set Merge Item
                            mergingItem = item;
                            mergingItem.CurrentStackSize += itemsBurnable_List[i].CurrentStackSize;

                            //Skip Loops, A Match Was Found
                            goto BreakLoops;
                        }
                    }
                }
            }

            //Made the Full Loop, Break Out
            canPass = true;

            //Goto Pointer
            BreakLoops:

            //Add and Remove Merged Items
            if (removalItem_Basic != null && removalItem_Listed != null & mergingItem != null)
            {
                itemsBurnable_List.Remove(removalItem_Basic);
                itemsBurnable_List.Remove(removalItem_Listed);
                itemsBurnable_List.Add(mergingItem);
            }
        }

        //Create and Fill Prefabs
        foreach (TM_ItemUI_Base item in itemsBurnable_List)
        {
            GameObject newItem = Instantiate(fire_BurnableItem_Prefab, fire_ContentContainer_GO.transform);

            //Fill Out Info
            newItem.transform.Find("Item Name Text").GetComponent<TextMeshProUGUI>().text = item.ItemName;
            newItem.transform.Find("Item Count Text").GetComponent<TextMeshProUGUI>().text = item.CurrentStackSize.ToString();
            newItem.transform.Find("Item Desc Text").GetComponent<TextMeshProUGUI>().text = item.ItemDesc;
            newItem.transform.Find("Item BG").transform.Find("Item Icon").GetComponent<Image>().sprite = item.ItemIcon;
        }
    }

    private void Action_Fire_RefreshBar()
    {

    }

    private void Action_Fire_RefreshBurnButton()
    {
        if (fire_selectedBurnable_GO != null)
        {
            fire_burnItem_Button.interactable = true;
        }
        else
        {
            fire_burnItem_Button.interactable = false;
        }
    }

    public void Action_Fire_CloseUI()
    {
        //Tunr Off Panel
        Fire_Panel.SetActive(false);

        //Disable Mouse
        LockMouse();



        //Load Stuff


    }

    /////////////////////////////////////////////////////// - Workbench UI

    public void Action_Workbench_OpenUI()
    {

    }

    /////////////////////////////////////////////////////// - Toolbar

    private void LookForMouseScroll_Toolbar()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            int newValue = TM_PlayerController_Inventory.Instance.currentToolbarPosition + 1;

            //Cap
            if (newValue > 8)
            {
                newValue = 0;
            }


            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(newValue);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // backwards
        {
            int newValue = TM_PlayerController_Inventory.Instance.currentToolbarPosition - 1;

            //Cap
            if (newValue < 0)
            {
                newValue = 8;
            }


            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(newValue);
        }
    }

    private void LookForSwapKey_Toolbar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TM_PlayerController_Inventory.Instance.Toolbar_MoveSelector_SetHover(9);
        }
    }

    /////////////////////////////////////////////////////// - Utility

    public void PlayerMenu_TurnOffPanels()
    {
        InventoryMenu_Panel.SetActive(false);
        StatsMenu_Panel.SetActive(false);
        NotesMenu_Panel.SetActive(false);

        //Prob should be somewhere else
        TM_CursorController.Instance.Cursor_DropItem();
    }

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

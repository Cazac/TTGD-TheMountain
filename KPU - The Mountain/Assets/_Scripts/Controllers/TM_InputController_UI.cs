using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_InputController_UI : MonoBehaviour
{

    public GameObject PauseMenu_Panel;
    public GameObject InventoryMenu_Panel;
    public GameObject EventLogMenu_Panel;

    public bool gameState_IsPasued;
    public bool gameState_IsPlaying;

    ///////////////////////////////////////////////////////

    private void Update()
    {


        LookForMenuKey_Pause();

        LookForMenuKey_Inventory();


        LookForMenuKeyEquipment();
    }

    ///////////////////////////////////////////////////////



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

    private void LookForMenuKeyEquipment()
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
}

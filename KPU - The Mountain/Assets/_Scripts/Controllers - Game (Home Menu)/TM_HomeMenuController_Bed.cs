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

public class TM_HomeMenuController_Bed : MonoBehaviour
{
    ////////////////////////////////

    public static TM_HomeMenuController_Bed Instance;

    ////////////////////////////////






    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////// - Fire UI

    public void BedMenu_OpenUI()
    {
        //Turn On Panel
        TM_PlayerMenuController_UI.Instance.Bed_Panel.SetActive(true);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;

        //Enable Mouse
        TM_PlayerMenuController_UI.Instance.UnlockMouse();
    }

    public void BedMenu_CloseUI()
    {
        //Tunr Off Panel
        TM_PlayerMenuController_UI.Instance.Bed_Panel.SetActive(false);

        //Change Game State
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;

        //Disable Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();
    }

    ///////////////////////////////////////////////////////






    ///////////////////////////////////////////////////////
}

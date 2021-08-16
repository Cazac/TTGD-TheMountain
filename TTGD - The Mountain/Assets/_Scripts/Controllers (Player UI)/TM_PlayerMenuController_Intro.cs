using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

///////////////
/// <summary>
///     
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Intro : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Intro Instance;

    ////////////////////////////////

    [Header("Intro Panels")]
    public GameObject introPanel;
    public TextMeshProUGUI intro_introText_Text;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        //Startup
        StartIntroAnimation();
    }

    ///////////////////////////////////////////////////////

    public void StartIntroAnimation()
    {
        //Lock Mouse
        TM_PlayerMenuController_UI.Instance.LockMouse();

        //Set Panel Active To Set Animation CLip
        introPanel.SetActive(true);

        //Set Pause State
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = true;
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = true;
        TM_PlayerController_Movement.Instance.canPlayerMove = false;

        //Set Text
        intro_introText_Text.text = "<b>" + TM_PlayerController_Stats.Instance.playerInfo_Name + "</b> has accepted the challenge of becoming the keeper of<br><b>The Mountain</b><br><br>The fire keeps The Mountain alive...";
    }

    public void StartFadeOutAnimation()
    {
        introPanel.GetComponent<Animator>().SetBool("IsReady", true);

    }

    ///////////////////////////////////////////////////////

    public void AnimationEvent_IntroDone()
    {
        print("Test Code: Starting Game!");

        //Set Panel Active To Set Animation CLip
        introPanel.SetActive(false);

        //Set Pause State
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = false;
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;
        TM_PlayerController_Movement.Instance.canPlayerMove = true;

        //Refresh the current values at first chance when systems are setup
        TM_PlayerMenuController_UI.Instance.UpdateUI_HealthValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_HungerValue();
        TM_PlayerMenuController_UI.Instance.UpdateUI_FireValue();

        StartCoroutine(TM_PlayerController_Stats.Instance.HungerDrain());
        StartCoroutine(TM_PlayerController_Stats.Instance.FireDrain());
    }

    ///////////////////////////////////////////////////////
}

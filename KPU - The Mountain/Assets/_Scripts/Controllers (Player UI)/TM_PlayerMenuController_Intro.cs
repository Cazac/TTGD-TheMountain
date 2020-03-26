using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    [Header("Death Panels")]
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

        //Set Text
        intro_introText_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name + " has accepted the challenge of becoming the keeper of<br><b>The Mountain</b><br><br>The fire keeps The Mountain alive...";
    }

    public void StartFadeOutAnimation()
    {
        introPanel.GetComponent<Animator>().SetBool("IsReady", true);

    }

    ///////////////////////////////////////////////////////

    public void AnimationEvent_IntroDone()
    {
        //Set Panel Active To Set Animation CLip
        introPanel.SetActive(false);

        //Set Pause State
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = false;
        TM_PlayerMenuController_UI.Instance.gameState_IsMenu = false;
    }

    ///////////////////////////////////////////////////////
}

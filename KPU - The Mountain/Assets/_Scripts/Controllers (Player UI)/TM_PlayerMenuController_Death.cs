using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

///////////////
/// <summary>
///     
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Death : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Death Instance;

    ////////////////////////////////

    [Header("Death Panels")]
    public GameObject deathPanel;
    public TextMeshProUGUI death_PlayerName_Text;
    public TextMeshProUGUI death_PlayerCycles_Text;
    public TextMeshProUGUI death_Cause_Text;
    public Image death_PlayerClass_Image;

    ////////////////////////////////

    [Header("Death")]
    public bool hasDied;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    ///////////////////////////////////////////////////////

    public void StartDeathAnimation(string causeOfDeath)
    {
        print("Test Code: Death");

        //Check If Death has been triggered already
        if (hasDied)
        {
            print("Test Code: Died! ...Again???");
            return;
        }



        //Set Panel Active To Set Animation CLip
        deathPanel.SetActive(true);
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = true;
        //Time.timeScale = 0;
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Set Text
        death_PlayerName_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name;
        death_PlayerCycles_Text.text = "Cycles Survivied " + TM_PlayerController_Stats.Instance.playerInfo_CyclesSurvived.ToString();
        death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name + " has died an hornarable death to keep the mountain lit.";
        death_PlayerClass_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(TM_PlayerController_Stats.Instance.playerInfo_Class);


        //Desc Text Of Death
        switch (causeOfDeath)
        {
            case "Fire":
                death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name +
                    " has failed to protect the fire, it has extiguished and with it your soul.";
                break;

            case "Hunger":
                death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name +
                    " has died of an empty stomatch.";
                break;

            case "Minotaur":
                death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name +
                    " was crushed by the mighty Minotaur, they died valiantly to protect the fire.";
                break;

            case "MapBounds":
                death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name +
                    " fell outside of the map, OOOPS!";
                break;

            case "DeathCycle":
                death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name +
                    " The Mountain has claimed your soul, the enviroment was too tough to endure.";
                break;

                    
        }





        //Stop All Inputs

        //SFX


        //Music





    }






    ///////////////////////////////////////////////////////

}

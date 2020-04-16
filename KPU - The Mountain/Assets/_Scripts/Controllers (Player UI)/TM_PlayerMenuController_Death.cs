using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public TextMeshProUGUI death_Bury_Text;
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
        //Check If Death has been triggered already
        if (hasDied)
        {
            print("Test Code: Died! ...Again???");
            return;
        }

        //Boost the player 200ft in the air so no one can attack them lol
        TM_PlayerController_Movement.Instance.gameObject.transform.position += new Vector3(0, 200f, 0);

        //Play Music 
        TM_MusicController.Instance.PlayTrackMusic(TM_DatabaseController.Instance.music_DB.deathMusic_Theme1);

        //Set Panel Active To Set Animation CLip
        deathPanel.SetActive(true);
        TM_PlayerMenuController_UI.Instance.gameState_IsPasued = true;
        //Time.timeScale = 0;
        TM_PlayerMenuController_UI.Instance.UnlockMouse();

        //Set Text
        death_PlayerName_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name;
        death_PlayerCycles_Text.text = "Cycles Survivied " + TM_PlayerController_Stats.Instance.playerInfo_CyclesSurvived.ToString();
        death_Cause_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name + " has died an hornarable death to keep the mountain lit.";
        death_Bury_Text.text = TM_PlayerController_Stats.Instance.playerInfo_Name + " has been buried in the mourge.";
        death_PlayerClass_Image.sprite = TM_DatabaseController.Instance.icon_DB.FindData_ClassIcon(TM_PlayerController_Stats.Instance.playerInfo_Class);



        //Stop All Inputs




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
    }

    public void Button_ConfirmDeath()
    {
        //Delete Save File
        TM_SaveController.Instance.PlayerData_DeleteSaveFile(TM_SaveController.Instance.currentSaveSlotID);
        
        //Reset Time Scale TO Allow Loading
        Time.timeScale = 1;

        //Quit Application
        SceneManager.LoadScene("TM_Title");
    }

    ///////////////////////////////////////////////////////
}

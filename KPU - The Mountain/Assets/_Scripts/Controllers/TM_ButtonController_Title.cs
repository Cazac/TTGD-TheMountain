using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ButtonController_Title : MonoBehaviour
{
    ////////////////////////////////

    public static TM_ButtonController_Title Instance { set; get; }

    ////////////////////////////////




    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        SetSingleton();
    }

    /////////////////////////////////////////////////////////////////

    private void SetSingleton()
    {
        //Set Static Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public void Button_NewGame()
    {
        //Close All Other Panels

        //Check if Settings Should Be Saved With A Confim Prompt? ???

        //Open Load Game Panel
    }

    public void Button_LoadGame()
    {
        //Close All Other Panels

        //Check if Settings Should Be Saved With A Confim Prompt? ???

        //Open Load Game Panel
    }

    public void Button_Settings()
    {
        //Open Settings Panel
    }

    public void Button_Quit()
    {
        //Quit Application
        Application.Quit();
    }

    /////////////////////////////////////////////////////////////////


    public void Button_SettingsConfirm()
    {

    }

    public void Button_SettingsBack()
    {

    }

    public void Slider_TotalVolume()
    {

    }

    /////////////////////////////////////////////////////////////////

}

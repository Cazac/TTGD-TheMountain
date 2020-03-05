using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_EventLogController
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_EventLogController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_EventLogController Instance;

    ////////////////////////////////

    private bool eventLog_IsActive;


    //private List<string> eventLog_List;

    public GameObject eventText_Container;
    public GameObject eventText_Prefab;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    void Update()
    {
        if (!eventLog_IsActive)
        {
            return;
        }
        else
        {
            //Fade
        }
    }

    ///////////////////////////////////////////////////////

    public void AddNewEvent(string eventText, int length)
    {
        //Spawn Text
        GameObject newEventText = Instantiate(eventText_Prefab, eventText_Container.transform);

        //Set Position
        newEventText.transform.SetAsFirstSibling();

        //Set Text Value



        //Make the event show



    }



    ///////////////////////////////////////////////////////
}

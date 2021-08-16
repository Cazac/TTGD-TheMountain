using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_CycleController Controls the cycle clock in the UI and the effect it produces in the world.
/// 
/// CONTROLLER CLASS
/// Controller classes are used as a manager of an entire system. 
/// Each controller is assigned a singleton for easy access.
/// 
/// </summary>
///////////////

public class TM_CyclesController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_CyclesController Instance;

    ////////////////////////////////

    [Header("Container")]
    public GameObject cycleContainer;

    ////////////////////////////////

    //Number of Panels to be used
    public static readonly int NumOfPanels = 6;

    //Cycle time in seconds
    private readonly float cycleDuration = 60f;

    //Dictory Of Possible Cycles
    private Dictionary<GameObject, TM_Cycle> CyclePanelList;



    ////////////////////////////////

    private Coroutine currentCycleEffect_Enum;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Reference
        Instance = this;
    }

    private void Start()
    {
        Setup();
    }

    ///////////////////////////////////////////////////////

    private void Setup()
    {
        //Randomly sets the seed
        Random.InitState(TM_DatabaseController.Instance.player_SaveData.playerInfo_MapSeed);


        //Initialize a dictionary/mapping to hold all the cycles
        CyclePanelList = new Dictionary<GameObject, TM_Cycle>();

        //Add each cycle panel from right to left (from the view of the player)
        for (int x = 0; x < NumOfPanels; x++)
        {
            GameObject panel = cycleContainer.transform.GetChild(x).gameObject;
            TM_Cycle cycle = new TM_Cycle();
            cycle.SetRandomCycle();
            //panel.GetComponent<Image>().color = cycle.cycleColor;
            panel.GetComponent<Image>().sprite = cycle.cycleSprite;
            panel.name = cycle.cycleName;

            //Sets the initial panel and its cycle type
            CyclePanelList.Add(panel, cycle);
        }


        //Starts the first cycle
        StartCoroutine(CycleClock());
    }

    ///////////////////////////////////////////////////////




    private IEnumerator CycleClock()
    {
        float normalizedTime = 0;

        //Continuously loops while cycle is running
        while (normalizedTime <= 1f)
        {
            yield return null;
            //Normalizing Time.deltaTime
            normalizedTime += Time.deltaTime / cycleDuration;
            foreach (KeyValuePair<GameObject, TM_Cycle> g in CyclePanelList)
            {
                //Grabs width of the particular panel (may be useless)
                float panelWidth = g.Key.GetComponent<RectTransform>().rect.width;
                float movingDist = (panelWidth / cycleDuration) * Time.deltaTime;
                g.Key.transform.localPosition += new Vector3(movingDist, 0, 0);
            }
        }

        //Sets the next cycle
        NextCycle();
    }

    private void NextCycle()
    {
        //Stops the previous cycle timer
        StopCoroutine(CycleClock());

        //Stop Current Cycle Effect
        if (currentCycleEffect_Enum != null)
        {
            //Stop Old Cycle
            StopCoroutine(currentCycleEffect_Enum);
        }


        //Grabs the fore-most panel
        GameObject cycleGO = cycleContainer.transform.GetChild(0).gameObject;
        //Grabs the related TM_Cycle object
        TM_Cycle cycle = CyclePanelList[cycleGO];

        //Sets new random cycle type for that panel
        cycle.SetRandomCycle();
        //Sets panel name as cycle type/name
        cycleGO.name = cycle.cycleName;
        //Sets new color for panel corresponding to the cycle type/name
        //cycleGO.GetComponent<Image>().color = cycle.cycleColor;
        cycleGO.GetComponent<Image>().sprite = cycle.cycleSprite;

        //Debug.Log(string.Concat("Cycle Name: ", cycle.cycleName, " Cycle Color: ", cycle.cycleColor.ToString()));

        //Moves panel to the end of the line   
        cycleGO.transform.SetAsLastSibling();

        SetCycle(cycle.cycleSO);

        //Starts the next cycle timer
        StartCoroutine(CycleClock());
    }



    ///////////////////////////////////////////////////////

    private void SetCycle(TM_Cycle_SO cycleSO)
    {
        switch (cycleSO.cycleName)
        {
            case "Basic":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Basic());
                break;

            case "Death":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Death());
                break;

            case "Life":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Life());
                break;

            case "Darkness":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Burning());
                break;

            case "Growth":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Darkness());
                break;

            case "Burning":
                currentCycleEffect_Enum = StartCoroutine(CycleEffect_Growth());
                break;
        }
    }

    private IEnumerator CycleEffect_Basic()
    {
        print("Test Code: Starting New Cycle Basic");


        //Effect Icons


        //Break Out
        yield break;
    }

    private IEnumerator CycleEffect_Death()
    {
        print("Test Code: Starting New Cycle Death");

        //Stats
        int secondsPerTick = 3;
        int damgepePerTick = -1;

        //Keep Looping
        while (true)
        {
            //Deal Damage
            TM_PlayerController_Stats.Instance.ChangeHealth_Current(damgepePerTick, "DeathCycle");

            //Wait For Next Tick
            yield return new WaitForSeconds(secondsPerTick);
        }


        //Break Out
        yield break;
    }

    private IEnumerator CycleEffect_Life()
    {
        print("Test Code: Starting New Cycle Life");

        //Stats
        int secondsPerTick = 3;
        int damgepePerTick = 1;

        //Keep Looping
        while (true)
        {
            //Deal Damage
            TM_PlayerController_Stats.Instance.ChangeHealth_Current(damgepePerTick, "LifeCycle");

            //Wait For Next Tick
            yield return new WaitForSeconds(secondsPerTick);
        }


        //Break Out
        yield break;
    }

    private IEnumerator CycleEffect_Burning()
    {
        print("Test Code: Starting New Cycle Burning");


        //Effect Icons


        //Break Out
        yield break;
    }

    private IEnumerator CycleEffect_Darkness()
    {
        print("Test Code: Starting New Cycle Darkness");


        //Effect Icons


        //Break Out
        yield break;
    }

    private IEnumerator CycleEffect_Growth()
    {
        print("Test Code: Starting New Cycle Growth");


        //Effect Icons


        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_CycleController Controls the cycle clock in the UI and the effect it produces in the world.
/// 
/// </summary>
///////////////

public class TM_CycleClockController : MonoBehaviour
{
    //////////IMPORTANT VARIABLES//////////////////////
    public static TM_CycleClockController Instance;
    public GameObject cycleContainer;
    public static readonly int NumOfPanels = 4; //Number of Panels to be used
    ///////////Clock Properties/////////////////////
    public static Dictionary<GameObject, TM_Cycle> CyclePanelList;
    private readonly float cycleDuration = 2f; //Cycle time in seconds
    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Reference
        Instance = this;
    }
    private void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond); //Randomly sets the seed for the timer based on system clock
        CyclePanelList = new Dictionary<GameObject, TM_Cycle>(); //Initialize a dictionary/mapping to hold all the cycles
        for (int x = 0; x < NumOfPanels; x++) //Add each cycle panel from right to left (from the view of the player)
        {
            GameObject panel = cycleContainer.transform.GetChild(x).gameObject;
            TM_Cycle cycle = new TM_Cycle();
            cycle.SetRandomCycle();
            panel.GetComponent<Image>().color = cycle.cycleColor;
            panel.name = cycle.cycleName;
            CyclePanelList.Add(panel, cycle); //Sets the initial panel and its cycle type
            Debug.Log(string.Concat("Cycle Name: ", cycle.cycleName, " Cycle Color: ", cycle.cycleColor.ToString()));
        }
        StartCoroutine(CycleClock()); //Starts the first cycle
    }
    IEnumerator CycleClock()
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)//Continuously loops while cycle is running
        {
            yield return null;
            normalizedTime += Time.deltaTime / cycleDuration; //Normalizing Time.deltaTime
            foreach (KeyValuePair<GameObject, TM_Cycle> g in CyclePanelList)
            {
                float panelWidth = g.Key.GetComponent<RectTransform>().rect.width; //Grabs width of the particular panel (may be useless)
                float movingDist = (panelWidth / cycleDuration) * Time.deltaTime;
                g.Key.transform.localPosition += new Vector3(movingDist, 0, 0);
            }
        }
        Debug.Log("Cycle Complete");
        Debug.Log(Time.time);
        NextCycle();//Sets the next cycle
    }

    private void NextCycle()
    {
        StopCoroutine(CycleClock()); //Stops the previous cycle timer

        GameObject g = cycleContainer.transform.GetChild(0).gameObject;//Grabs the fore-most panel
        TM_Cycle c = CyclePanelList[g]; //Grabs the related TM_Cycle object

        c.SetRandomCycle();//Sets new random cycle type for that panel
        g.name = c.cycleName; //Sets panel name as cycle type/name
        g.GetComponent<Image>().color = c.cycleColor; //Sets new color for panel corresponding to the cycle type/name
        Debug.Log(string.Concat("Cycle Name: ", c.cycleName, " Cycle Color: ", c.cycleColor.ToString()));
        g.transform.SetAsLastSibling();//Moves panel to the end of the line     

        StartCoroutine(CycleClock()); //Starts the next cycle timer
    }
    private void Update()
    {
        /*numCycles++;
        foreach (GameObject g in CyclePanelList)
        {
            float panelWidth = g.GetComponent<RectTransform>().rect.width; //Grabs width of the particular panel (I just realized this would be useless, because they all need to stay linked side by side)
            float movingDist = (panelWidth / cycleDuration) * Time.deltaTime;
            //Debug.Log(movingDist);
            g.transform.localPosition += new Vector3(movingDist, 0, 0);
        }
        
        if(numCycles == 60)
        {
            Time.timeScale = 0;
            Debug.Log(numCycles);
        }
        //Debug.Log(Time.time);*/
    }

    ///////////////////////////////////////////////////////
}

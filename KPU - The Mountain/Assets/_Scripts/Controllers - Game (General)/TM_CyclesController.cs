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
    public static Dictionary<GameObject, TM_Cycle> CyclePanelList;

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

    private void Setup()
    {
        //Randomly sets the seed for the timer based on system clock
        Random.InitState(System.DateTime.Now.Millisecond);
        //Initialize a dictionary/mapping to hold all the cycles
        CyclePanelList = new Dictionary<GameObject, TM_Cycle>();

        //Add each cycle panel from right to left (from the view of the player)
        for (int x = 0; x < NumOfPanels; x++) 
        {
            GameObject panel = cycleContainer.transform.GetChild(x).gameObject;
            TM_Cycle cycle = new TM_Cycle();
            cycle.SetRandomCycle();
            panel.GetComponent<Image>().color = cycle.cycleColor;
            panel.name = cycle.cycleName;
            //Sets the initial panel and its cycle type
            CyclePanelList.Add(panel, cycle); 
            //Debug.Log(string.Concat("Cycle Name: ", cycle.cycleName, " Cycle Color: ", cycle.cycleColor.ToString()));
        }

        //Starts the first cycle
        StartCoroutine(CycleClock()); 
    }

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

        //Debug.Log("Cycle Complete");
        //Debug.Log(Time.time);
        //Sets the next cycle
        NextCycle();
    }

    private void NextCycle()
    {
        //Stops the previous cycle timer
        StopCoroutine(CycleClock()); 

        //Grabs the fore-most panel
        GameObject g = cycleContainer.transform.GetChild(0).gameObject;
        //Grabs the related TM_Cycle object
        TM_Cycle c = CyclePanelList[g]; 

        //Sets new random cycle type for that panel
        c.SetRandomCycle();
        //Sets panel name as cycle type/name
        g.name = c.cycleName; 
        //Sets new color for panel corresponding to the cycle type/name
        g.GetComponent<Image>().color = c.cycleColor; 
        //Debug.Log(string.Concat("Cycle Name: ", c.cycleName, " Cycle Color: ", c.cycleColor.ToString()));
        //Moves panel to the end of the line   
        g.transform.SetAsLastSibling();  

        //Starts the next cycle timer
        StartCoroutine(CycleClock()); 
    }

    ///////////////////////////////////////////////////////
}

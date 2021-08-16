using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///
/// Class: TM_Cycle
/// Purpose: To manage the properties of each cycle
/// 
/// </summary>
///////////////

public class TM_Cycle
{
    ////////////////////////////////

    //Single instance of the shuffle bag that is shared amongst all TM_Cycle Objects
    public static TM_CycleShuffleBag shuffleBag;

    ////////////////////////////////

    //CYCLE PROPERTIES
    private static readonly string[] cycleNameList = { "PlayerDMG_Down", "EnemyDMG_Up", "EnemySPD_Up", "PlayerSPD_UP", "PlayerDies" };
    private static readonly Color[] colorList = { Color.yellow, Color.blue, Color.red, Color.green, Color.white };
    private static readonly int[] cycleFrequency = { 1, 1, 1, 1, 1 };


    //TESTING WITH SCRIPTALBE OBJS


    ////////////////////////////////

    public static int NumOfTotalTypes;

    ////////////////////////////////

    //Panel's Current Cycle Color
    //public Color cycleColor; 
    public Sprite cycleSprite;
    //Panel's Current Cycle Name
    public string cycleName;

    public List<TM_Cycle_SO> cycleData;
    public TM_Cycle_SO cycleSO;

    ///////////////////////////////////////////////////////
    //Scriptable Object Version
    public TM_Cycle()
    {
        cycleData = TM_DatabaseController.Instance.cycle_DB.allCycles_List;
        NumOfTotalTypes = cycleData.Count;

        //For now, since there's only 1 of each Cycle Type TODO: Cycle through each type and get a frequency value to add together
        shuffleBag = new TM_CycleShuffleBag(3);

        for (int x = 0; x < NumOfTotalTypes; x++)
        {
            cycleSO = cycleData[x];
            string name = cycleSO.cycleName;
            Sprite s = cycleSO.cycleIcon;
            shuffleBag.AddCycle(new KeyValuePair<string, Sprite>(name, s), 1);
        }
    }
    public void SetRandomCycle()
    {
        //Sets a random cycle using the Shuffle Bag technique
        KeyValuePair<string, Sprite> nextCycle = shuffleBag.NextCycle();
        cycleName = nextCycle.Key;
        cycleSprite = nextCycle.Value;
    }

    //Default (non-SO)
    /*
    public TM_Cycle()
    {
        shuffleBag = new TM_CycleShuffleBag(14);
        for (int x = 0; x < NumOfTotalTypes; x++)
        {
            string name = cycleNameList[x];
            Color c = colorList[x];
            shuffleBag.AddCycle(new KeyValuePair<string, Color>(name, c), cycleFrequency[x]);
        }
    }

    public void SetRandomCycle()
    {
        //Sets a random cycle using the Shuffle Bag technique
        KeyValuePair<string, Color> nextCycle = shuffleBag.NextCycle();
        cycleName = nextCycle.Key;
        cycleColor = nextCycle.Value;
    }
    */

    ///////////////////////////////////////////////////////
}

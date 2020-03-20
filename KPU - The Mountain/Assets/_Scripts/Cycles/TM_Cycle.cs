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

    ////////////////////////////////

    public static readonly int NumOfTotalTypes = 5;

    ////////////////////////////////

    //Panel's Current Cycle Color
    public Color cycleColor; 
    //Panel's Current Cycle Name
    public string cycleName;

    public TM_Cycle_SO cycleSO;

    ///////////////////////////////////////////////////////

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

    ///////////////////////////////////////////////////////
}

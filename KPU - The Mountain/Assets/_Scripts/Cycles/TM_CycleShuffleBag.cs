using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///
/// Class: TM_CycleShuffleBag
/// Purpose: A version of the shuffle bag technique to help balance the probabilities of the cycle types
/// 
/// </summary>
///////////////

public class TM_CycleShuffleBag
{
    ////////////////////////////////

    //List<KeyValuePair<string, Color>> cycleTypes;
    List<KeyValuePair<string, Sprite>> cycleTypes;

    //Current cycle in the draw
    //private KeyValuePair<string, Color> currentCycle;
    private KeyValuePair<string, Sprite> currentCycle;
    //Current position in the bag
    private int currentPos;

    ////////////////////////////////

    private int Capacity { get { return cycleTypes.Capacity; } }
    private int Size { get { return cycleTypes.Count; } }

    ///////////////////////////////////////////////////////

    public TM_CycleShuffleBag(int initialCapacity)
    {
        cycleTypes = new List<KeyValuePair<string, Sprite>>(initialCapacity);
    }

    public void AddCycle(KeyValuePair<string, Sprite> cycle, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            cycleTypes.Add(cycle);
        }
        currentPos = Size - 1;
    }

    public KeyValuePair<string, Sprite> NextCycle()
    {
        if (currentPos < 1)
        {
            currentPos = Size - 1;
            currentCycle = cycleTypes[0];
            return currentCycle;
        }

        int pos = Random.Range(0, currentPos);
        //Debug.Log(pos);
        currentCycle = cycleTypes[pos];
        cycleTypes[pos] = cycleTypes[currentPos];
        cycleTypes[currentPos] = currentCycle;

        return currentCycle;
    }

    /*
    public TM_CycleShuffleBag(int initialCapacity)
    {
        cycleTypes = new List<KeyValuePair<string, Color>>(initialCapacity);
    }

    public void AddCycle(KeyValuePair<string, Color> cycle, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            cycleTypes.Add(cycle);
        }
        currentPos = Size - 1;
    }

    public KeyValuePair<string, Color> NextCycle()
    {
        if (currentPos < 1)
        {
            currentPos = Size - 1;
            currentCycle = cycleTypes[0];
            return currentCycle;
        }

        int pos = Random.Range(0, currentPos);
        //Debug.Log(pos);
        currentCycle = cycleTypes[pos];
        cycleTypes[pos] = cycleTypes[currentPos];
        cycleTypes[currentPos] = currentCycle;

        return currentCycle;
    }
    */

    ///////////////////////////////////////////////////////
}
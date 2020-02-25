using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Class: TM_CycleShuffleBag
/// Purpose: A version of the shuffle bag technique to help balance the probabilities of the cycle types
/// </summary>
public class TM_CycleShuffleBag
{
    List<KeyValuePair<string, Color>> cycleTypes;

    private KeyValuePair<string, Color> currentCycle; //Current cycle in the draw
    private int currentPos; //Current position in the bag

    private int Capacity { get { return cycleTypes.Capacity; } }
    private int Size { get { return cycleTypes.Count; } }

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
        Debug.Log(pos);
        currentCycle = cycleTypes[pos];
        cycleTypes[pos] = cycleTypes[currentPos];
        cycleTypes[currentPos] = currentCycle;

        return currentCycle;
    }
}
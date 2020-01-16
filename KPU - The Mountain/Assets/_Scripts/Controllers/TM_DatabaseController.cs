using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// </summary>
///////////////

public class TM_DatabaseController : MonoBehaviour
{
    ////////////////////////////////

    public static TM_DatabaseController Instance;

    ////////////////////////////////

    public List<TM_Item_ConsumableFood_SO> consumableFood_LIST;




    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        //DEBUG
        if (Input.GetKeyDown(KeyCode.R))
        {
            consumableFood_LIST[0].SpawnItem_Placed();

        }
    }


    /////////////////////////////////////////////////////////////////
}

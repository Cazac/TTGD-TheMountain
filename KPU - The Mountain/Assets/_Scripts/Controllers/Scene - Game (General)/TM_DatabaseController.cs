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

    [Header("Prebuilt Item Lists")]
    public List<TM_Item_ConsumableFood_SO> consumableFood_LIST;
    public List<TM_Item_ConsumablePotions_SO> consumablePotions_LIST;
    public List<TM_Item_EquiptableArmor_SO> equiptableArmor_LIST;
    public List<TM_Item_EquiptableWeapons_SO> equiptableWeapon_LIST;

    //[Header("Enemy Lists")]


    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        SpawnDebugItemPlaced();
    }

    /////////////////////////////////////////////////////////////////

    private void SpawnDebugItemPlaced()
    {
        //DEBUG SPAWN
        if (Input.GetKeyDown(KeyCode.R))
        {
            //consumableFood_LIST[0].SpawnItem_Placed();
        }
    }

    /////////////////////////////////////////////////////////////////
}

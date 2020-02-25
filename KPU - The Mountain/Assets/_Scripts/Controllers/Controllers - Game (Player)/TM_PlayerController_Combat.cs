using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerController_Combat : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Combat Instance;

    ////////////////////////////////






    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        LookForCombatKeys_Attack();
        LookForCombatKeys_Magic();
    }


    private void LookForCombatKeys_Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TM_PlayerController_Animation.Instance.SetAnimationValue_QuickAttack();
        }
    }


    private void LookForCombatKeys_Magic()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //TM_PlayerController_Animation.Instance.att
        }
    }

    ///////////////////////////////////////////////////////





    ///////////////////////////////////////////////////////
}

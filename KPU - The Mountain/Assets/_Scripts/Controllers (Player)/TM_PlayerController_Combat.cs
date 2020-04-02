using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TM_PlayerController_Combat : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Combat Instance;

    ////////////////////////////////

    public GameObject hitboxContainter;


    public Image hurtScreen;
    public float hurtScreenDuration;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Update()
    {
        LookForCombatKeys_Attack();
        LookForCombatKeys_Action();
    }

    ///////////////////////////////////////////////////////

    private void LookForCombatKeys_Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu)
            {
                return;
            }


            if (TM_PlayerMenuController_Inventory.Instance.isHoldingItem)
            {
                //Get Item Held
                TM_ItemUI item = TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array[TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

                //Use a Basic Punch
                TM_PlayerController_Animation.Instance.SetAnimationValue_PunchAttack();
            }
            else if (TM_PlayerMenuController_Inventory.Instance.isHoldingWeapon)
            {
                //Get Item Held
                TM_ItemUI item = TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array[TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

                //Get Weapon Animation Attack
                TM_PlayerController_Animation.Instance.SetAnimationValue_SwordAttack();
            }
            else
            {
                TM_PlayerController_Animation.Instance.SetAnimationValue_PunchAttack();
            }
        }
    }

    private void LookForCombatKeys_Action()
    {
        if (Input.GetMouseButton(1))
        {
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsConsumingItem(true);
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsBlockingWeapon(true);
        }
        else
        {
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsConsumingItem(false);
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsBlockingWeapon(false);
        }
    }

    ///////////////////////////////////////////////////////

    public void AddToHurtScreen(int additionHurting)
    {
        if (hurtScreenDuration == 0)
        {
            hurtScreenDuration = additionHurting * 2.5f;

            //Cap Hurt Timer
            if (hurtScreenDuration > 90)
            {
                hurtScreenDuration = 90;
            }

            StartCoroutine(FadeOutHurtScreen());
        }
        else
        {
            hurtScreenDuration += additionHurting * 1.5f;

            //Cap Hurt Timer
            if (hurtScreenDuration > 90)
            {
                hurtScreenDuration = 90;
            }
        }
    }

    public IEnumerator FadeOutHurtScreen()
    {
        yield return new WaitForSeconds(0.2f);


        while (hurtScreenDuration > 0)
        {


            hurtScreenDuration -= 1.2f;


            hurtScreen.color = new Color(1, 1, 1, hurtScreenDuration * 0.01f);

            yield return new WaitForSeconds(0.1f);
        }

        hurtScreenDuration = 0;
        hurtScreen.color = new Color(1, 1, 1, 0);

        yield break;


    }

    ///////////////////////////////////////////////////////

    public void SpawnAttackHitbox(GameObject hitboxPrefab, float duration)
    {
        GameObject hitbox_GO = Instantiate(hitboxPrefab, hitboxContainter.transform);


        //Set Auto Destruct

        StartCoroutine(AutoDestoryCountdown(duration, hitbox_GO));

    }

    private IEnumerator AutoDestoryCountdown(float clipLength, GameObject hitBox)
    {
        //Wait Till Clip is over + buffer room
        yield return new WaitForSeconds(clipLength + 0.1f);

        //Destory Clip
        Destroy(hitBox);

        //Break Out
        yield break;
    }

    ///////////////////////////////////////////////////////
}

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
    public int hurtScreenDuration;

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

    ///////////////////////////////////////////////////////

    private void LookForCombatKeys_Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TM_PlayerMenuController_UI.Instance.gameState_IsMenu)
            {
                return;
            }


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

    public void AddToHurtScreen(int additionHurting)
    {
        if (hurtScreenDuration == 0)
        {
            hurtScreenDuration = additionHurting * 3;
            StartCoroutine(FadeOutHurtScreen());
        }
        else
        {
            hurtScreenDuration += additionHurting * 3;
        }
    }

    public IEnumerator FadeOutHurtScreen()
    {
        yield return new WaitForSeconds(0.2f);


        while (hurtScreenDuration > 0)
        {


            hurtScreenDuration -= 1;


            hurtScreen.color = new Color(1, 1, 1, hurtScreenDuration * 0.01f);

            yield return new WaitForSeconds(0.1f);
        }

        hurtScreenDuration = 0;
        hurtScreen.color = new Color(1, 1, 1, 0);

        yield break;


    }

    ///////////////////////////////////////////////////////

    public void SpawnAttackHitbox(GameObject hitboxPrefab)
    {
        GameObject hitbox_GO = Instantiate(hitboxPrefab, hitboxContainter.transform);


        //Set Auto Destruct

        StartCoroutine(AutoDestoryCountdown(0.3f, hitbox_GO));

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

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_PlayerController_Animation : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerController_Animation Instance;

    ////////////////////////////////

    public GameObject playerHead_GO;
    public GameObject firstPersonCamera_GO;
    public GameObject thirdPersonCamera_GO;

    ////////////////////////////////

    [Header("Hand Spawn Points")]
    public GameObject playerRightHandSpawnPoint_GO;
    public GameObject playerLeftHandSpawnPoint_GO;

    ////////////////////////////////

    private Animator playerAnimator;

    ////////////////////////////////

    /*
    float TypeID_Running;
    float TypeID_Walking;
    float TypeID_Idling;
    float PlayerSpeed;
    bool IsGrounded;
    bool IsDashing;
    bool IsAttacking_MeleeQuick;
    bool IsAttacking_MeleeStrong;
    bool IsAttacking_MagicQuick;
    */

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;

        //Get Animator
        playerAnimator = gameObject.GetComponent<Animator>();
    }
   
    private void Update()
    {
        LookForAnimationKeys_ViewType();
        LookForAnimationKeys_DebugChanges();
    }

    ///////////////////////////////////////////////////////

    public void SetAnimationValue_PunchAttack()
    {
        playerAnimator.Play("Attack Punch");
    }

    public void SetAnimationValue_SwordAttack()
    {
        playerAnimator.Play("Attack Melee Quick");
    }

    public void SetAnimationValue_PlayerSpeed(float value)
    {
        playerAnimator.SetFloat("PlayerSpeed", value);



    }

    public void SetAnimationValue_IsGrounded(bool value)
    {

        playerAnimator.SetBool("IsGrounded", value);
    }

    public void SetAnimationValue_IsHoldingItem(bool value)
    {
        playerAnimator.SetBool("IsHoldingToolbarItem", value);
    }

    public void SetAnimationValue_IsHoldingWeapon(bool value)
    {
        playerAnimator.SetBool("IsHoldingToolbarWeapon", value);
    }

    public void SetAnimationValue_IsConsumingItem(bool value)
    {
        playerAnimator.SetBool("IsConsumingToolbarItem", value);
    }

    public void SetAnimationValue_IsBlockingWeapon(bool value)
    {
        playerAnimator.SetBool("IsBlockingToolbarWeapon", value);
    }

    ///////////////////////////////////////////////////////

    public void RemoveItemInHand_Right()
    {
        //Remove Old Item In Hand
        foreach (Transform child in playerRightHandSpawnPoint_GO.transform)
        {
            //Remove Children
            Destroy(child.gameObject);
        }
    }

    public void SpawnItemInHand_Hover(TM_Item_SO original_SO)
    {
        //Remove Old Item
        RemoveItemInHand_Right();


        if (original_SO.held_Prefab != null)
        {
            Instantiate(original_SO.held_Prefab, playerRightHandSpawnPoint_GO.transform);
        }
        else
        {
            print("Test Code: Oops");
        }
    }

    public void SpawnItemInHand_Combat(TM_Item_SO original_SO)
    {
        //Remove Old Item
        RemoveItemInHand_Right();


        if (original_SO.held_Prefab != null)
        {
            Instantiate(original_SO.held_Prefab, playerRightHandSpawnPoint_GO.transform);
        }
        else
        {
            print("Test Code: Oops");
        }
    }

    ///////////////////////////////////////////////////////

    private void LookForAnimationKeys_ViewType()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (firstPersonCamera_GO.activeSelf == true)
            {
                //Cameras
                firstPersonCamera_GO.SetActive(false);
                thirdPersonCamera_GO.SetActive(true);

                //Head
                playerHead_GO.SetActive(true);
            }
            else if (thirdPersonCamera_GO.activeSelf == true)
            {
                //Cameras
                firstPersonCamera_GO.SetActive(true);
                thirdPersonCamera_GO.SetActive(false);

                //Head
                playerHead_GO.SetActive(false);
            }
        }
    }

    private void LookForAnimationKeys_DebugChanges()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerAnimator.SetFloat("TypeID_Walking", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerAnimator.SetFloat("TypeID_Walking", 2.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerAnimator.SetFloat("TypeID_Walking", 3.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerAnimator.SetFloat("TypeID_Walking", 4.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
         
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_SetHover(9);
        }
    }

    ///////////////////////////////////////////////////////

    public void LoadHitbox_Attack1()
    {
        TM_PlayerController_Combat.Instance.SpawnAttackHitbox(TM_DatabaseController.Instance.hitbox_DB.playerPunch_Hitbox);

    }

    ///////////////////////////////////////////////////////



    public void AnimationEvent_PunchHitbox()
    {
        TM_PlayerController_Combat.Instance.SpawnAttackHitbox(TM_DatabaseController.Instance.hitbox_DB.playerPunch_Hitbox);

    }


    public void AnimationEvent_ConsumeItem()
    {
        //Check If Slot has an Item
        if (TM_PlayerMenuController_Inventory.Instance.isHoldingItem)
        {
            //Get Item Held
            TM_ItemUI item = TM_PlayerMenuController_Inventory.Instance.toolbarItemSlots_Array[TM_PlayerMenuController_Inventory.Instance.currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

            //Check If Consumable
            if (item.isConsumable)
            {


                TM_PlayerController_Stats.Instance.ChangeHealth_Current(item.consumable_Health, "Healing");
                TM_PlayerController_Stats.Instance.ChangeHunger_Current(item.consumable_Hunger);



                //EFFECTS??


                TM_PlayerMenuController_Inventory.Instance.Inventory_FindAndRemoveItem(item.itemName);

                //Consume SFX?


            }
            else
            {
                //Error SFX?
            }
        }


        //Can consume

        //Consumable

        //remove

        //Refresh
        TM_PlayerMenuController_Inventory.Instance.Toolbar_MoveSelector_RefreshCurrent();
    }


    public void AnimationEvent_HideItem()
    {
        //Check If Slot has an Item
        playerRightHandSpawnPoint_GO.SetActive(false);


    }

    public void AnimationEvent_ShowItem()
    {
        //Check If Slot has an Item
        playerRightHandSpawnPoint_GO.SetActive(true);



    }

    ///////////////////////////////////////////////////////
}

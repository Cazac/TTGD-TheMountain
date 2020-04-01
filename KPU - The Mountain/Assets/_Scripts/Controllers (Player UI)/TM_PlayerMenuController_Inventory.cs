using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

///////////////
/// <summary>
///     
/// TM_PlayerController_Movement takes input and moves the player.
/// 
/// </summary>
///////////////

public class TM_PlayerMenuController_Inventory : MonoBehaviour
{
    ////////////////////////////////

    public static TM_PlayerMenuController_Inventory Instance;

    ////////////////////////////////

    [Header("Item Slots")]
    public GameObject[] toolbarItemSlots_Array;
    public GameObject[] playerItemSlots_Array;

    ////////////////////////////////

    public int currentToolbarPosition;

    [Header("Toolbar - Bools")]
    public bool isHoldingItem;
    public bool isHoldingWeapon;

    ////////////////////////////////

    [Header("Stats - Buttons")]
    public GameObject STR_Button;
    public GameObject DEX_Button;
    public GameObject INT_Button;
    public GameObject CON_Button;

    ////////////////////////////////

    [Header("Stats - Text")]
    public TextMeshProUGUI skillPointAvalible_Text;
    public TextMeshProUGUI STR_Text;
    public TextMeshProUGUI DEX_Text;
    public TextMeshProUGUI INT_Text;
    public TextMeshProUGUI CON_Text;

    [Header("Stats - Text")]
    public TextMeshProUGUI stats_Attack_Text;
    public TextMeshProUGUI stats_Magic_Text;
    public TextMeshProUGUI stats_Defense_Text;
    public TextMeshProUGUI stats_Resistance_Text;
    public TextMeshProUGUI stats_Speed_Text;
    public TextMeshProUGUI stats_Health_Text;
    public TextMeshProUGUI stats_Stamina_Text;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    private void Start()
    {
        //Set First Item By Default
        Toolbar_MoveSelector_SetHover(0);


    }

    private void Update()
    {
        LookForItemDropKeys();

    }

    ///////////////////////////////////////////////////////

    public void Setup()
    {
  
        DebugSpawnStats();
        Stats_RefreshUI();
    }

    private void DebugSpawnStats()
    {
        TM_PlayerController_Stats.Instance.player_SkillPointsAvalible += 1;
    }

    ///////////////////////////////////////////////////////

    public void Button_AddValue_STR()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_STR++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            Stats_RefreshUI();
        }
    }

    public void Button_AddValue_DEX()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_DEX++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            Stats_RefreshUI();
        }
    }

    public void Button_AddValue_INT()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_INT++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            Stats_RefreshUI();
        }
    }

    public void Button_AddValue_CON()
    {
        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible > 0)
        {
            //Add Stat
            TM_PlayerController_Stats.Instance.player_CurrentStat_CON++;

            //Remove Point
            TM_PlayerController_Stats.Instance.player_SkillPointsAvalible--;

            //Refresh UI
            Stats_RefreshUI();
        }
    }

    ///////////////////////////////////////////////////////

    public void Stats_RefreshUI()
    {
        skillPointAvalible_Text.text = "Skill Points: " + TM_PlayerController_Stats.Instance.player_SkillPointsAvalible;

        int additive_STR = TM_PlayerController_Stats.Instance.tempStat_STR; //TM_PlayerController_Stats.Instance.equipmentStat_STR +
        int additive_DEX = TM_PlayerController_Stats.Instance.tempStat_DEX; //TM_PlayerController_Stats.Instance.equipmentStat_DEX + 
        int additive_INT = TM_PlayerController_Stats.Instance.tempStat_INT; //TM_PlayerController_Stats.Instance.equipmentStat_INT + 
        int additive_CON = TM_PlayerController_Stats.Instance.tempStat_CON; //TM_PlayerController_Stats.Instance.equipmentStat_CON + 

        if (additive_STR > 0)
        {
            STR_Text.text = "STR: " + TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (+<color=#ffff00>STR:" + additive_STR + "</color>)";
        }
        else if (additive_STR < 0)
        {
            STR_Text.text = "STR: " + TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (-<color=#ffff00>STR:" + additive_STR + "</color>)";
        }
        else
        {
            STR_Text.text = "STR: " + TM_PlayerController_Stats.Instance.player_CurrentStat_STR + " (+0)";
        }

        DEX_Text.text = "DEX: " + TM_PlayerController_Stats.Instance.player_CurrentStat_DEX + " (+0)";
        INT_Text.text = "INT: " + TM_PlayerController_Stats.Instance.player_CurrentStat_INT + " (+0)";
        CON_Text.text = "CON: " + TM_PlayerController_Stats.Instance.player_CurrentStat_CON + " (+0)";


        if (TM_PlayerController_Stats.Instance.player_SkillPointsAvalible <= 0)
        {
            STR_Button.SetActive(false);
            DEX_Button.SetActive(false);
            INT_Button.SetActive(false);
            CON_Button.SetActive(false);
        }
        else
        {
            STR_Button.SetActive(true);
            DEX_Button.SetActive(true);
            INT_Button.SetActive(true);
            CON_Button.SetActive(true);
        }


        TM_PlayerController_Stats.Instance.CalculateAttack_NoWep();
        TM_PlayerController_Stats.Instance.CalculateMagic_NoSpell();
        TM_PlayerController_Stats.Instance.CalculateDefense();
        TM_PlayerController_Stats.Instance.CalculateResistance();
        TM_PlayerController_Stats.Instance.CalculateSpeed();
        TM_PlayerController_Stats.Instance.CalculateHealth();
        TM_PlayerController_Stats.Instance.CalculateStamina();

        stats_Attack_Text.text = "Attack: " + TM_PlayerController_Stats.Instance.player_CurrentAttack;
        stats_Magic_Text.text = "Magic: " + 0;
        stats_Defense_Text.text = "Defense: " + TM_PlayerController_Stats.Instance.player_CurrentDefense;
        stats_Resistance_Text.text = "Resistance: " + 0;
        stats_Speed_Text.text = "Speed: " + 0;
        stats_Health_Text.text = "Health: " + TM_PlayerController_Stats.Instance.player_MaxHealth;
        stats_Stamina_Text.text = "Stamina: " + 0;

    }


    ///////////////////////////////////////////////////////

    public TM_ItemUI[] Inventory_GetItemsToArray()
    {
        //Create The Array
        TM_ItemUI[] itemArray = new TM_ItemUI[20];

        //Reset Counter
        int counter = 0;

        //Loop All Slots
        foreach (GameObject itemSlot_GO in playerItemSlots_Array)
        {
            //Confirm Item
            if (itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
            {
                //Add Item + Position
                itemArray[counter] = itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_GetItem();
            }

            //Update Counter
            counter++;
        }

        //Return Filled Array
        return itemArray;
    }

    public void Inventory_SetItemsFromArray(TM_ItemUI[] itemArray)
    {
        //Clear Inventory First
        foreach (GameObject itemSlot_GO in playerItemSlots_Array)
        {
            itemSlot_GO.GetComponent<TM_ItemSlot>().ItemSlot_RemoveItem();
        }

        //Reset Counter
        int counter = 0;

        //Loop All Array Items
        foreach (TM_ItemUI itemUI in itemArray)
        {
            //Confirm Item
            if (itemUI != null)
            {
                //Set Item
                playerItemSlots_Array[counter].GetComponent<TM_ItemSlot>().ItemSlot_SetItem(itemUI);
            }

            //Update Counter
            counter++;
        }
    }

    ///////////////////////////////////////////////////////


    private void LookForItemDropKeys()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Attept To Drop SIngle Item From Hotbar
            if (isHoldingItem)
            {
                //Drop Item
                toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_DropItemSingle();
            }
            else if (isHoldingWeapon)
            {
                //Drop Item
                toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_DropItemSingle();
            }
        }
    }

    public void Inventory_FindAndRemoveItem(string itemName)
    {
        //Find Slots in Toolbar
        foreach (GameObject itemSlot in toolbarItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();


            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == itemName)
                {
                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    return;
                }
            }
        }

        //Find Slots in Inventory
        foreach (GameObject itemSlot in playerItemSlots_Array)
        {
            //Get Slot
            TM_ItemSlot slot = itemSlot.GetComponent<TM_ItemSlot>();

            if (slot.ItemSlot_GetItem() != null)
            {
                if (slot.ItemSlot_GetItem().itemName == itemName)
                {

                    slot.ItemSlot_GetItem().currentStackSize--;
                    slot.ItemSlot_UpdateItem();
                    return;
                }
            }
        }
    }

    ///////////////////////////////////////////////////////

    public void Toolbar_MoveSelector_SetHover(int hoverPosition)
    {
        //Remove other hovers
        foreach (GameObject toolbar in toolbarItemSlots_Array)
        {
            //Update Color to dark
            toolbar.GetComponent<Image>().color = new Color32(164, 164, 164, 255);
        }

        //Update Color to light
        toolbarItemSlots_Array[hoverPosition].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //Set New Position
        currentToolbarPosition = hoverPosition;

        //Refresh Held Item Status
        Toolbar_MoveSelector_RefreshCurrent();
    }

    public void Toolbar_MoveSelector_RefreshCurrent()
    {
        //Check If Slot has an Item
        if (toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem() != null)
        {
            //Check If Weapon
            if (toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem().isWeapon)
            {
                //Set Animation Value
                isHoldingItem = false;
                isHoldingWeapon = true;

                TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(isHoldingItem);
                TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingWeapon(isHoldingWeapon);

                //Get Scriptable To Hold
                TM_ItemUI item = toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

                //Spawn Item
                TM_PlayerController_Animation.Instance.SpawnItemInHand_Combat(item.original_SO);
            }
            else
            {
                //Set Animation Value
                isHoldingItem = true;
                isHoldingWeapon = false;

                TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(isHoldingItem);
                TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingWeapon(isHoldingWeapon);

                //Get Scriptable To Hold
                TM_ItemUI item = toolbarItemSlots_Array[currentToolbarPosition].GetComponent<TM_ItemSlot>().ItemSlot_GetItem();

                //Spawn Item
                TM_PlayerController_Animation.Instance.SpawnItemInHand_Hover(item.original_SO);
            }
        }
        else
        {
            //Set Animation Value
            isHoldingItem = false;
            isHoldingWeapon = false;

            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingItem(isHoldingItem);
            TM_PlayerController_Animation.Instance.SetAnimationValue_IsHoldingWeapon(isHoldingWeapon);

            //Remove Old Item
            TM_PlayerController_Animation.Instance.RemoveItemInHand_Right();
        }
    }

    ///////////////////////////////////////////////////////
}

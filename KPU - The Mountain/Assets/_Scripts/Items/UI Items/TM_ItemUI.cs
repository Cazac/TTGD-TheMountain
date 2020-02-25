using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemUI : MonoBehaviour
{
    ////////////////////////////////

    public TM_Item_SO orginal_SO;

    ////////////////////////////////

    [Header("Item Descriptions")]
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;

    ////////////////////////////////

    [Header("Durablity Info")]
    public int maxDurablity;
    public int currentDurablity;

    ////////////////////////////////

    [Header("Stack Sizes Info")]
    public int maxStackSize;
    public int currentStackSize;

    ////////////////////////////////

    [Header("Burnable Status")]
    public bool isBurnable;

    public int burn_FireValue;
    public int burn_FireEffect;

    ////////////////////////////////

    [Header("Consumable Status")]
    public bool isConsumable;

    public int consumable_Category;
    public int consumable_Hunger;
    public int consumable_Health;
    public int consumable_Stamina;
    public int consumable_DamageBuffValue;
    public int consumable_DamageBuffDuration;
    public int consumable_DefenseBuffValue;
    public int consumable_DefenseBuffDuration;
    public int consumable_SpeedBuffValue;
    public int consumable_SpeedBuffDuration;
    public int consumable_StaminaBuffValue;
    public int consumable_StaminaBuffDuration;

    ////////////////////////////////

    [Header("Weapon Status")]
    public bool isWeapon;

    public int weapon_Tier;
    public int weapon_Damage;
    public int weapon_Range;
    public int weapon_Speed;
    public int weapon_Knockback;
    public int weapon_StaminaQuick;
    public int weapon_StaminaPower;
    public int weapon_BlockSpeed;
    public int weapon_BlockNegation;
    public int weapon_BlockParryTime;

    ////////////////////////////////

    [Header("Armor Status")]
    public bool isArmorHead;
    public bool isArmorChest;
    public bool isArmorArm;
    public bool isArmorGlove;
    public bool isArmorLeg;
    public bool isArmorBoot;

    public int armor_Tier;
    public int armor_Defense;
    public int armor_Speed;
    public int armor_MaxHealth;

    ////////////////////////////////

    [Header("Stat Requirement Status")]
    public bool isStatRequired;

    public int statReq_STR;
    public int statReq_DEX;
    public int statReq_INT;
    public int statReq_CON;

    ///////////////////////////////////////////////////////
}

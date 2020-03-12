using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemUI
{
    ////////////////////////////////

    public TM_Item_SO original_SO;

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

    public string consumable_Category;
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
    public float weapon_Range;
    public float weapon_Speed;
    public float weapon_Knockback;
    public int weapon_StaminaQuick;
    public int weapon_StaminaPower;
    public float weapon_BlockSpeed;
    public int weapon_BlockNegation;
    public float weapon_BlockParryTime;

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

    public TM_ItemUI(TM_Item_SO itemScriptable)
    {
        this.original_SO = itemScriptable;

        this.itemName = itemScriptable.itemName;
        this.itemDesc = itemScriptable.itemDesc;
        this.itemIcon = itemScriptable.itemIcon;

        this.maxDurablity = itemScriptable.maxDurablity;
        this.currentDurablity = maxDurablity;
        this.maxStackSize = itemScriptable.maxStackSize;
        this.currentStackSize = 1;

        this.isBurnable = itemScriptable.isBurnable;
        this.burn_FireValue = itemScriptable.burn_FireValue;
        this.burn_FireEffect = itemScriptable.burn_FireEffect;

        this.isConsumable = itemScriptable.isConsumable;
        this.consumable_Category = itemScriptable.consumable_Category;
        this.consumable_Hunger = itemScriptable.consumable_Hunger;
        this.consumable_Health = itemScriptable.consumable_Health;
        this.consumable_Stamina = itemScriptable.consumable_Stamina;
        this.consumable_DamageBuffValue = itemScriptable.consumable_DamageBuffValue;
        this.consumable_DamageBuffDuration = itemScriptable.consumable_DamageBuffDuration;
        this.consumable_DefenseBuffValue = itemScriptable.consumable_DefenseBuffValue;
        this.consumable_DefenseBuffDuration = itemScriptable.consumable_DefenseBuffDuration;
        this.consumable_SpeedBuffValue = itemScriptable.consumable_SpeedBuffValue;
        this.consumable_SpeedBuffDuration = itemScriptable.consumable_SpeedBuffDuration;
        this.consumable_StaminaBuffValue = itemScriptable.consumable_StaminaBuffValue;
        this.consumable_StaminaBuffDuration = itemScriptable.consumable_StaminaBuffDuration;

        this.isWeapon = itemScriptable.isWeapon;
        this.weapon_Tier = itemScriptable.weapon_Tier;
        this.weapon_Damage = itemScriptable.weapon_Damage;
        this.weapon_Range = itemScriptable.weapon_Range;
        this.weapon_Speed = itemScriptable.weapon_Speed;
        this.weapon_Knockback = itemScriptable.weapon_Knockback;
        this.weapon_StaminaQuick = itemScriptable.weapon_StaminaQuick;
        this.weapon_StaminaPower = itemScriptable.weapon_StaminaPower;
        this.weapon_BlockSpeed = itemScriptable.weapon_BlockSpeed;
        this.weapon_BlockNegation = itemScriptable.weapon_BlockNegation;
        this.weapon_BlockParryTime = itemScriptable.weapon_BlockParryTime;

        this.isArmorHead = itemScriptable.isArmorHead;
        this.isArmorChest = itemScriptable.isArmorChest;
        this.isArmorArm = itemScriptable.isArmorArm;
        this.isArmorGlove = itemScriptable.isArmorGlove;
        this.isArmorLeg = itemScriptable.isArmorLeg;
        this.isArmorBoot = itemScriptable.isArmorBoot;
        this.armor_Tier = itemScriptable.armor_Tier;
        this.armor_Defense = itemScriptable.armor_Defense;
        this.armor_Speed = itemScriptable.armor_Speed;
        this.armor_MaxHealth = itemScriptable.armor_MaxHealth;

        this.isStatRequired = itemScriptable.isStatRequired;
        this.statReq_STR = itemScriptable.statReq_STR;
        this.statReq_DEX = itemScriptable.statReq_DEX;
        this.statReq_INT = itemScriptable.statReq_INT;
        this.statReq_CON = itemScriptable.statReq_CON;
    }

    public TM_ItemUI(TM_ItemUI itemUI)
    {
        this.original_SO = itemUI.original_SO;

        this.itemName = itemUI.itemName;
        this.itemDesc = itemUI.itemDesc;
        this.itemIcon = itemUI.itemIcon;

        this.maxDurablity = itemUI.maxDurablity;
        this.currentDurablity = maxDurablity;
        this.maxStackSize = itemUI.maxStackSize;
        this.currentStackSize = maxStackSize;

        this.isBurnable = itemUI.isBurnable;
        this.burn_FireValue = itemUI.burn_FireValue;
        this.burn_FireEffect = itemUI.burn_FireEffect;

        this.isConsumable = itemUI.isConsumable;
        this.consumable_Category = itemUI.consumable_Category;
        this.consumable_Hunger = itemUI.consumable_Hunger;
        this.consumable_Health = itemUI.consumable_Health;
        this.consumable_Stamina = itemUI.consumable_Stamina;
        this.consumable_DamageBuffValue = itemUI.consumable_DamageBuffValue;
        this.consumable_DamageBuffDuration = itemUI.consumable_DamageBuffDuration;
        this.consumable_DefenseBuffValue = itemUI.consumable_DefenseBuffValue;
        this.consumable_DefenseBuffDuration = itemUI.consumable_DefenseBuffDuration;
        this.consumable_SpeedBuffValue = itemUI.consumable_SpeedBuffValue;
        this.consumable_SpeedBuffDuration = itemUI.consumable_SpeedBuffDuration;
        this.consumable_StaminaBuffValue = itemUI.consumable_StaminaBuffValue;
        this.consumable_StaminaBuffDuration = itemUI.consumable_StaminaBuffDuration;

        this.isWeapon = itemUI.isWeapon;
        this.weapon_Tier = itemUI.weapon_Tier;
        this.weapon_Damage = itemUI.weapon_Damage;
        this.weapon_Range = itemUI.weapon_Range;
        this.weapon_Speed = itemUI.weapon_Speed;
        this.weapon_Knockback = itemUI.weapon_Knockback;
        this.weapon_StaminaQuick = itemUI.weapon_StaminaQuick;
        this.weapon_StaminaPower = itemUI.weapon_StaminaPower;
        this.weapon_BlockSpeed = itemUI.weapon_BlockSpeed;
        this.weapon_BlockNegation = itemUI.weapon_BlockNegation;
        this.weapon_BlockParryTime = itemUI.weapon_BlockParryTime;

        this.isArmorHead = itemUI.isArmorHead;
        this.isArmorChest = itemUI.isArmorChest;
        this.isArmorArm = itemUI.isArmorArm;
        this.isArmorGlove = itemUI.isArmorGlove;
        this.isArmorLeg = itemUI.isArmorLeg;
        this.isArmorBoot = itemUI.isArmorBoot;
        this.armor_Tier = itemUI.armor_Tier;
        this.armor_Defense = itemUI.armor_Defense;
        this.armor_Speed = itemUI.armor_Speed;
        this.armor_MaxHealth = itemUI.armor_MaxHealth;

        this.isStatRequired = itemUI.isStatRequired;
        this.statReq_STR = itemUI.statReq_STR;
        this.statReq_DEX = itemUI.statReq_DEX;
        this.statReq_INT = itemUI.statReq_INT;
        this.statReq_CON = itemUI.statReq_CON;
    }

    ///////////////////////////////////////////////////////
}

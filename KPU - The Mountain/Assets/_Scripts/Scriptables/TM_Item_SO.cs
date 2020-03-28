using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptables/New Item")]
public class TM_Item_SO : ScriptableObject
{
    //////////////////////////////// - Prefabs

    [Header("Item Prefabs")]
    public GameObject dropped_Prefab;
    public GameObject placed_Prefab;
    public GameObject held_Prefab;
    public GameObject equipped_Prefab;

    //////////////////////////////// - All Item Stats 

    [Header("Item Descriptions")]
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;

    ////////////////////////////////

    [Header("Durablity / Stack Info")]
    public int maxDurablity;
    public int maxStackSize;

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

    [Header("Consumable Buffs")]
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

    public TM_Item_SO weaponUpgrade_Mat1;
    public TM_Item_SO weaponUpgrade_Mat2;
    public TM_Item_SO weaponUpgrade_Mat3;

    public TM_Item_SO weaponUpgrade_UpgradedWeapon;

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

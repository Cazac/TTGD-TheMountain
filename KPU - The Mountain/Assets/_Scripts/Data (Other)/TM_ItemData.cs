using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemData : MonoBehaviour
{
    ////////////////////////////////

    [Header("Items - Baisc")]
    public TM_Item_SO Logs_SO;
    public TM_Item_SO IronBar_SO;

    ////////////////////////////////

    [Header("Items - Consumable Cooked")]
    public TM_Item_SO Bread_SO;
    public TM_Item_SO Hamburger_SO;
    public TM_Item_SO Sandwich_SO;

    [Header("Items - Consumable Fruit")]
    public TM_Item_SO Blueberry_SO;
    public TM_Item_SO Grape_SO;
    public TM_Item_SO GreenApple_SO;
    public TM_Item_SO Lemon_SO;
    public TM_Item_SO Orange_SO;
    public TM_Item_SO RedApple_SO;
    public TM_Item_SO Strawberry_SO;
    public TM_Item_SO Watermelon_SO;

    [Header("Items - Consumable Meat")]
    public TM_Item_SO CookedMeat_SO;
    public TM_Item_SO CookedMeatStick_SO;
    public TM_Item_SO CookedMorsel_SO;
    public TM_Item_SO CookedMysteryMeat_SO;
    public TM_Item_SO CookedSteak_SO;
    public TM_Item_SO RawMeat_SO;
    public TM_Item_SO RawMeatStick_SO;
    public TM_Item_SO RawMorsel_SO;
    public TM_Item_SO RawMysteryMeat_SO;
    public TM_Item_SO RawSteak_SO;

    [Header("Items - Consumable Vegetable")]
    public TM_Item_SO BellPepper_SO;
    public TM_Item_SO Carrot_SO;
    public TM_Item_SO Corn_SO;
    public TM_Item_SO Healshroom_SO;
    public TM_Item_SO HotPepper_SO;
    public TM_Item_SO Potato_SO;
    public TM_Item_SO Speedshroom_SO;
    public TM_Item_SO Stamshroom_SO;

    ////////////////////////////////

    [Header("Items - Weapons Axe")]
    public TM_Item_SO GimliAxe_SO;
    public TM_Item_SO IronAxe_SO;
    public TM_Item_SO SilverAxe_SO;
    public TM_Item_SO SteelAxe_SO;
    public TM_Item_SO StoneAxe_SO;

    [Header("Items - Weapons Maces")]
    public TM_Item_SO DwarvenMace_SO;
    public TM_Item_SO IronMace_SO;
    public TM_Item_SO SilverMace_SO;
    public TM_Item_SO SteelMace_SO;
    public TM_Item_SO StoneMace_SO;

    [Header("Items - Weapons Staffs")]
    public TM_Item_SO CedarStaff_SO;
    public TM_Item_SO CobaltStaff_SO;
    public TM_Item_SO EmeraldStaff_SO;
    public TM_Item_SO HackberryStaff_SO;
    public TM_Item_SO RubyStaff_SO;

    [Header("Items - Weapons Sword")]
    public TM_Item_SO DwarvenSword_SO;
    public TM_Item_SO IronScimitar_SO;
    public TM_Item_SO IronSword_SO;
    public TM_Item_SO LegendaryEmeraldSword_SO;
    public TM_Item_SO LegendaryFlameSword_SO;
    public TM_Item_SO LegendaryPoisonSword_SO;
    public TM_Item_SO LegendaryRubySword_SO;
    public TM_Item_SO SilverBroadsword_SO;
    public TM_Item_SO SilverScimitar_SO;
    public TM_Item_SO SteelBroadsword_SO;
    public TM_Item_SO SteelSword_SO;
    public TM_Item_SO StoneSword_SO;

    [Header("Items - Weapons Wands")]
    public TM_Item_SO CedarWand_SO;
    public TM_Item_SO CobaltWand_SO;
    public TM_Item_SO EmeraldWand_SO;
    public TM_Item_SO HackberryWand_SO;
    public TM_Item_SO RubyWand_SO;

    ////////////////////////////////

    [Header("Items - Armor Enhanced Steampunk")]
    public TM_Item_SO EnhancedSteampunkArmGuard_SO;
    public TM_Item_SO EnhancedSteampunkBoots_SO;
    public TM_Item_SO EnhancedSteampunkChestGuard_SO;
    //public TM_Item_SO EnhancedSteampunkGlove_SO;
    public TM_Item_SO EnhancedSteampunkHelmet_SO;
    public TM_Item_SO EnhancedSteampunkLegGuard_SO;

    [Header("Items - Armor Gold")]
    public TM_Item_SO GoldArmGuard_SO;
    public TM_Item_SO GoldBoots_SO;
    public TM_Item_SO GoldChestGuard_SO;
    //public TM_Item_SO GoldGlove_SO;
    public TM_Item_SO GoldHelmet_SO;
    public TM_Item_SO GoldLegGuard_SO;

    ////////////////////////////////

    [Header("Lists")]
    public List<TM_Item_SO> basicItems_List;
    public List<TM_Item_SO> consumableItems_List;
    public List<TM_Item_SO> weaponsItems_List;
    public List<TM_Item_SO> armorItems_List;


    ///////////////////////////////////////////////////////

    public void BuildDatabase()
    {
        //Basic
        BuildDatabase_Basic();

        //Consumables
        BuildDatabase_Consumables();

        //Weapons
        BuildDatabase_Weapons();

        //Armor
        BuildDatabase_Armor();

    }


    private void BuildDatabase_Basic()
    {
        //Basic
        basicItems_List.Add(Logs_SO);
        basicItems_List.Add(IronBar_SO);
    }


    private void BuildDatabase_Consumables()
    {
        //Consumable Fruit
        consumableItems_List.Add(Blueberry_SO);
        consumableItems_List.Add(Grape_SO);
        consumableItems_List.Add(GreenApple_SO);
        consumableItems_List.Add(Lemon_SO);
        consumableItems_List.Add(Orange_SO);
        consumableItems_List.Add(RedApple_SO);
        consumableItems_List.Add(Strawberry_SO);
        consumableItems_List.Add(Watermelon_SO);
        
        //Consumable Vegetable
        consumableItems_List.Add(BellPepper_SO);
        consumableItems_List.Add(Carrot_SO);
        consumableItems_List.Add(Corn_SO);
        consumableItems_List.Add(Healshroom_SO);
        consumableItems_List.Add(HotPepper_SO);
        consumableItems_List.Add(Potato_SO);
        consumableItems_List.Add(Speedshroom_SO);
        consumableItems_List.Add(Stamshroom_SO);

        //Consumable Meats
        consumableItems_List.Add(CookedMeat_SO);
        consumableItems_List.Add(CookedMeatStick_SO);
        //consumableItems_List.Add(CookedMorsel_SO);
        //consumableItems_List.Add(CookedMysteryMeat_SO);
        //consumableItems_List.Add(CookedSteak_SO);
        //consumableItems_List.Add(RawMeat_SO);
        //consumableItems_List.Add(RawMeatStick_SO);
        //consumableItems_List.Add(RawMorsel_SO);
        //consumableItems_List.Add(RawMysteryMeat_SO);
        //consumableItems_List.Add(RawSteak_SO);

        //Consumable Cooked
        consumableItems_List.Add(Bread_SO);
        consumableItems_List.Add(Hamburger_SO);
        consumableItems_List.Add(Sandwich_SO);
    }

    private void BuildDatabase_Weapons()
    {
        //Weapons Axe
        weaponsItems_List.Add(GimliAxe_SO);
        weaponsItems_List.Add(IronAxe_SO);
        weaponsItems_List.Add(SilverAxe_SO);
        weaponsItems_List.Add(SteelAxe_SO);
        weaponsItems_List.Add(StoneAxe_SO);

        //Weapons Maces
        weaponsItems_List.Add(DwarvenMace_SO);
        weaponsItems_List.Add(IronMace_SO);
        weaponsItems_List.Add(SilverMace_SO);
        weaponsItems_List.Add(SteelMace_SO);
        weaponsItems_List.Add(StoneMace_SO);


        //Weapons Staff
        weaponsItems_List.Add(CedarStaff_SO);
        weaponsItems_List.Add(CobaltStaff_SO);
        weaponsItems_List.Add(EmeraldStaff_SO);
        weaponsItems_List.Add(HackberryStaff_SO);
        weaponsItems_List.Add(RubyStaff_SO);

        /*
        //Weapons Sword
        weaponsItems_List.Add(DwarvenSword_SO);
        weaponsItems_List.Add(IronScimitar_SO);
        weaponsItems_List.Add(IronSword_SO);
        weaponsItems_List.Add(LegendaryEmeraldSword_SO);
        weaponsItems_List.Add(LegendaryFlameSword_SO);
        weaponsItems_List.Add(LegendaryPoisonSword_SO);
        weaponsItems_List.Add(LegendaryRubySword_SO);
        weaponsItems_List.Add(SilverBroadsword_SO);
        weaponsItems_List.Add(SilverScimitar_SO);
        weaponsItems_List.Add(SteelBroadsword_SO);
        weaponsItems_List.Add(SteelSword_SO);
        weaponsItems_List.Add(StoneSword_SO);

        //Weapons Wand
        weaponsItems_List.Add(CedarWand_SO);
        weaponsItems_List.Add(CobaltWand_SO);
        weaponsItems_List.Add(EmeraldWand_SO);
        weaponsItems_List.Add(HackberryWand_SO);
        weaponsItems_List.Add(RubyWand_SO);
        */
    }

    private void BuildDatabase_Armor()
    {
        //Armor Enhanced Steampunk"
        armorItems_List.Add(EnhancedSteampunkArmGuard_SO);
        armorItems_List.Add(EnhancedSteampunkBoots_SO);
        armorItems_List.Add(EnhancedSteampunkChestGuard_SO);
        //armorItems_List.Add(EnhancedSteampunkGlove_SO);
        armorItems_List.Add(EnhancedSteampunkHelmet_SO);
        armorItems_List.Add(EnhancedSteampunkLegGuard_SO);

        //Armor Gold
        armorItems_List.Add(GoldArmGuard_SO);
        armorItems_List.Add(GoldBoots_SO);
        armorItems_List.Add(GoldChestGuard_SO);
        //armorItems_List.Add(GoldGlove_SO);
        armorItems_List.Add(GoldHelmet_SO);
        armorItems_List.Add(GoldLegGuard_SO);
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_ItemData : MonoBehaviour
{
    ////////////////////////////////

    [Header("Items - Consumable")]
    public TM_Item_SO RedApple_SO;
    public TM_Item_SO GreenApple_SO;
    public TM_Item_SO Blueberry_SO;
    public TM_Item_SO Watermelon_SO;
    public TM_Item_SO Orange_SO;
    public TM_Item_SO Grape_SO;
    public TM_Item_SO Lemon_SO;
    public TM_Item_SO Strawberry_SO;


    /*

   Raw Morsel
       Cooked Morsel
       Raw Meat
       Cooked Meat
       Raw Steak
       Cooked Steak
       Raw Mystery Meat
       Cooked Mystery Meat
       Raw Meat Stick
       Cooked Meat Stick

       */


    public TM_Item_SO Healshroom_SO;
    public TM_Item_SO Speedshroom_SO;
    public TM_Item_SO Stamshroom_SO;
    public TM_Item_SO Potato_SO;
    public TM_Item_SO Corn_SO;
    public TM_Item_SO Carrot_SO;
    public TM_Item_SO HotPepper_SO;
    public TM_Item_SO BellPepper_SO;
    public TM_Item_SO Bread_SO;
    public TM_Item_SO Sandwich_SO;
    public TM_Item_SO Hamburger_SO;





   
        
        
        
     


    ////////////////////////////////

    [Header("Items - Consumable")]
    public List<TM_Item_SO> consumableItems_List;

    ////////////////////////////////


    [Header("Items - Weapons")]
    public TM_Item_SO IronAxe_SO;
    public TM_Item_SO GimliAxe_SO;
    public TM_Item_SO SilverAxe_SO;
    public TM_Item_SO SteelAxe_SO;
    public TM_Item_SO StoneAxe_SO;

    public TM_Item_SO SilverBroadsword_SO;
    public TM_Item_SO IronScimitar_SO;
    public TM_Item_SO SilverScimitar_SO;
    public TM_Item_SO SteelBroadsword_SO;

    public TM_Item_SO SteelSword_SO;
    public TM_Item_SO IronSword_SO;
    public TM_Item_SO DwarvenSword_SO;
    public TM_Item_SO StoneSword_SO;

    public TM_Item_SO DwarvenMace_SO;
    public TM_Item_SO SilverMace_SO;
    public TM_Item_SO SteelMace_SO;
    public TM_Item_SO IronMace_SO;
    public TM_Item_SO StoneMace_SO;

    public TM_Item_SO EmeraldStaff_SO;
    public TM_Item_SO RubyStaff_SO;
    public TM_Item_SO CobaltStaff_SO;
    public TM_Item_SO HackberryStaff_SO;
    public TM_Item_SO CedarStaff_SO;

    public TM_Item_SO RubyWand_SO;
    public TM_Item_SO EmeraldWand_SO;
    public TM_Item_SO CobaltWand_SO;
    public TM_Item_SO HackberryWand_SO;
    public TM_Item_SO CedarWand_SO;

    public TM_Item_SO LegendaryRubySword_SO;
    public TM_Item_SO LegendaryPoisonSword_SO;
    public TM_Item_SO LegendaryFlameSword_SO;
    public TM_Item_SO LegendaryEmeraldSword_SO;




    [Header("Items - Baisc")]
    public TM_Item_SO Wood_SO;






    public void BuildDatabase()
    {

        consumableItems_List.Add(RedApple_SO);
        consumableItems_List.Add(GreenApple_SO);
        consumableItems_List.Add(Blueberry_SO);
        consumableItems_List.Add(Watermelon_SO);
        consumableItems_List.Add(Orange_SO);
        consumableItems_List.Add(Grape_SO);
        consumableItems_List.Add(Lemon_SO);
        consumableItems_List.Add(Strawberry_SO);
        consumableItems_List.Add(Healshroom_SO);
        consumableItems_List.Add(Speedshroom_SO);
        consumableItems_List.Add(Stamshroom_SO);
        consumableItems_List.Add(Potato_SO);
        consumableItems_List.Add(Corn_SO);
        consumableItems_List.Add(Carrot_SO);
        consumableItems_List.Add(HotPepper_SO);
        consumableItems_List.Add(BellPepper_SO);
        consumableItems_List.Add(Bread_SO);
        consumableItems_List.Add(Sandwich_SO);
        consumableItems_List.Add(Hamburger_SO);
    }

}

      
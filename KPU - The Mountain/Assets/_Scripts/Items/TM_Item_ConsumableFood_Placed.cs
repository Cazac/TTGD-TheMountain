using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Item_ConsumableFood_Placed 
/// 
/// </summary>
///////////////

public class TM_Item_ConsumableFood_Placed : MonoBehaviour, TM_ItemUI_Base, TM_InteractableObject_Base
{
    ////////////////////////////////

    //This is known as consumable food
    [Header("Item Descriptions")]
    public string name;
    public string desc;

    public int stackSize;

    [Header("Item Stats")]
    public string hunger;
    public string health;

    public float maxRange => throw new System.NotImplementedException();

    public Sprite ItemIcon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }





    /////////////////////////////////////////////////////// - TM_InteractableObject_Base

    public void Dropped_PickupObject()
    {
        throw new System.NotImplementedException();
    }

    public void OnEndHover()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractEndHold()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractHold()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractTap()
    {
        throw new System.NotImplementedException();
    }

    public void OnStartHover()
    {
        throw new System.NotImplementedException();
    }

    /////////////////////////////////////////////////////// - TM_ItemUI_Base

    public void Placed_PickupObject()
    {
        throw new System.NotImplementedException();
    }

    public void UI_DropObject()
    {
        throw new System.NotImplementedException();
    }

    public void UI_PickupObject()
    {
        throw new System.NotImplementedException();
    }

    public void UI_PlaceObject()
    {
        throw new System.NotImplementedException();
    }

    public void UI_SplitStackObject_Multi()
    {
        throw new System.NotImplementedException();
    }

    public void UI_SplitStackObject_Single()
    {
        throw new System.NotImplementedException();
    }

    public void UI_StackMoveObject()
    {
        throw new System.NotImplementedException();
    }

    ///////////////////////////////////////////////////////
}

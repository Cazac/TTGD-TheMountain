///////////////
/// <summary>
///     
/// TM_DatabaseController 
/// 
/// </summary>
///////////////d

public interface TM_ItemUI_Base
{
    ////////////////////////////////

    //Read only
    //float maxRange { get; }

    ///////////////////////////////////////////////////////

    //Methods
    void Placed_PickupObject();

    void UI_PickupObject();
    void UI_PlaceObject();
    void UI_DropObject();

    void UI_StackMoveObject();
    void UI_SplitStackObject_Multi();
    void UI_SplitStackObject_Single();

    void Dropped_PickupObject();


    ///////////////////////////////////////////////////////
}

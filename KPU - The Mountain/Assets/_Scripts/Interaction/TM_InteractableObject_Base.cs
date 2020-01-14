///////////////
/// <summary>
///     
/// TM_InteractableObject_Base is the base interface class for interactable objects. 
/// 
/// </summary>
///////////////

public interface TM_InteractableObject_Base 
{
    ////////////////////////////////
    
    //Read only
    float maxRange { get; }

    ///////////////////////////////////////////////////////

    //Methods
    void OnStartHover();
    void OnInteractTap();
    void OnInteractHold();
    void OnInteractEndHold();
    void OnEndHover();

    ///////////////////////////////////////////////////////
}

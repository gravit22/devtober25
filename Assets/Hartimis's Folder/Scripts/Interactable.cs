using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Message that is displayed to the player when looking at a interactable.
    public string promptMessage;
    
    public void BaseInteract()
    {
        Interact();

    }

    protected virtual void Interact()
    {
        // This is a temlate function to be overwritten by out subclasses
    }
}

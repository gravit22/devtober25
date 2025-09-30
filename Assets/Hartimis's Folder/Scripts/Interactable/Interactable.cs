using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or Remove an InteractionEvent componet to this gameobject.
    public bool useEvents;

    // Message displayed to the player when looking at an interactable.
    [SerializeField] public string promptMessage;

    public virtual string OnLool()
    { 
        return promptMessage; 
    }

    public void BaseInteraction()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    
    protected virtual void Interact()
    {

    }
}

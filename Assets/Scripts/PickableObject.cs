using UnityEngine;

public class PickableObject : InteractableObject
{
    protected override void Interact()
    {
        Debug.Log("Interacting with pickable object");
    }
}

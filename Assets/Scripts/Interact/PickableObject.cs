using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemScriptObject itemSO;
    protected override void Interact()
    {
        Debug.Log("Interacting with pickable object");
    }
}

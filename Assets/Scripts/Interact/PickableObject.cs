using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO itemSO;
    protected override void Interact()
    {
        Debug.Log("Interacting with pickable object");
    }
}

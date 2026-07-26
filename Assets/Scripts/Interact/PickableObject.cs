using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO itemSO;
    protected override void Interact()
    {
        InventoryManager.Instance.AddItem(itemSO);
        Destroy(gameObject);
    }
}

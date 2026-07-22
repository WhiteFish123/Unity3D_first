using UnityEngine;

public class NPCObject : InteractableObject
{
    protected override void Interact()
    {
        Debug.Log("Interacting with npc");
    }
}

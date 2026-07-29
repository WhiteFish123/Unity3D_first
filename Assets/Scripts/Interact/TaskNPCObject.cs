using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    protected override void Interact()
    {
        Debug.Log("你是来领取任务的吗");
    }
}

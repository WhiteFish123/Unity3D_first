using UnityEngine;
using System.Collections.Generic;
public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    private void Start()
    {
        gameTaskSO.state=GameTaskState.Waiting;
    }

    protected override void Interact()
    {
        DialogueUI.Instance.Show(npcName,new List<string>(gameTaskSO.diague),OnDialogueEnd);
    }
    private void OnDialogueEnd()
    {
        switch(gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                gameTaskSO.state=GameTaskState.Executing;
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Completed:
                break;
            case GameTaskState.End:
                break;
        }
    }
}

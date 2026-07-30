using UnityEngine;
using System.Collections.Generic;
public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    public string[] contentInTask_Executing;
    public string[] contentInTask_Completed;
    public string[] contentInTask_End;


    private void Start()
    {
        gameTaskSO.state=GameTaskState.Waiting;
    }

    protected override void Interact()
    {
        switch(gameTaskSO.state)
        {
            case GameTaskState.Waiting:
            DialogueUI.Instance.Show(npcName,new List<string>(gameTaskSO.diague),OnDialogueEnd);
                break;
            case GameTaskState.Executing:
            DialogueUI.Instance.Show(npcName,new List<string>(contentInTask_Executing));
                break;
            case GameTaskState.Completed:
            DialogueUI.Instance.Show(npcName,new List<string>(contentInTask_Completed),OnDialogueEnd);
                break;
            case GameTaskState.End:
            DialogueUI.Instance.Show(npcName,new List<string>(contentInTask_End));
                break;
            default:
                break;
        }
        
    }
    private void OnDialogueEnd()
    {
        switch(gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                gameTaskSO.Start();
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Completed:
                gameTaskSO.End();
                InventoryManager.Instance.AddItem(gameTaskSO.endReward);
                break;
            case GameTaskState.End:
                break;
        }
    }
}

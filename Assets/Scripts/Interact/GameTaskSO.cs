using UnityEngine;

public enum GameTaskState
{
    Waiting,
    Executing,
    Completed,
    End
}
[CreateAssetMenu()]
public class GameTaskSO : ScriptableObject
{
    public GameTaskState state;

    public string[] diague;

    public ItemSO startReward;
    public ItemSO endReward;
}

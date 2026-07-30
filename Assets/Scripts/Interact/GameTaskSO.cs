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

    public int EnemyCountNeed=10;
    public int currentEnemyCount=0;

    public void Start()
    {
        state=GameTaskState.Executing;
        currentEnemyCount=0;
        EventCenter.OnEnemyDied += OnEnemyDied;
    }
    public void OnEnemyDied(Enemy enemy)
    {
        if(state==GameTaskState.Completed)return;
        currentEnemyCount++;
        if(currentEnemyCount>=EnemyCountNeed)
        {
            state=GameTaskState.Completed;
            MessageUI.Instance.Show("任务已完成,请前去领赏");
        }
    }
    public void End()
    {
        state=GameTaskState.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;
    }
}



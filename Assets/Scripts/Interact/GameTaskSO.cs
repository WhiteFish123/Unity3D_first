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
    public int EnemyCount=0;

    public void Start()
    {
        state=GameTaskState.Executing;
        EnemyCount=0;
        EventCenter.OnEnemyDied += OnEnemyDied;
    }
    public void OnEnemyDied(Enemy enemy)
    {
        Debug.Log("敌人死亡");
        EnemyCount++;
        if(EnemyCount>=EnemyCountNeed)
        {
            state=GameTaskState.Completed;
        }
    }
    public void End()
    {
        state=GameTaskState.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;
    }
}



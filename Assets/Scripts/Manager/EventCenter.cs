using UnityEngine;
using System.Collections.Generic;   
using System;

public class EventCenter : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDied;

    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }
}

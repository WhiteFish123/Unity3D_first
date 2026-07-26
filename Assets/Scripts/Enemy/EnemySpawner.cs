using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    private float spawnTimer;

    private void Start()
    {
        SpawnEnemy();
    }
    private void Update()
    {
        spawnTimer+=Time.deltaTime;
        if(spawnTimer>=spawnTime)
        {
            spawnTimer=0;
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        GameObject.Instantiate(enemyPrefab,transform.position,quaternion.identity);
    }
}

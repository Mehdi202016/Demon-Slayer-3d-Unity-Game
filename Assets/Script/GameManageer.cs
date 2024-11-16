using UnityEngine;

public class GameManageer : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] SpawnPosition;
    public int FirstSpaw, NextSpawn;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", FirstSpaw, NextSpawn);
    }

    public void SpawnEnemy()
    {
        int enemyCount = Random.Range(0, 1);
        int PositionCount = Random.Range(0, SpawnPosition.Length-1);
        GameObject enemy = Instantiate(Enemy, SpawnPosition[PositionCount].position,Quaternion.identity);
    }
}

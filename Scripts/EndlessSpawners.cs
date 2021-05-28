using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawners : MonoBehaviour
{
    public int enemyCount;
    public Transform enemySpawner;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 1)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        GameObject t_enemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(t_enemy, enemySpawner.position, enemySpawner.rotation);
        enemyCount++;
    }
}

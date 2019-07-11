using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTutorial : MonoBehaviour
{
    public SpawnEnemy firstEnemySpawn;
    public GameObject scoreBoard;

    public void StartSpawningEnemies()
    {
        scoreBoard.SetActive(true);
        firstEnemySpawn.isSpawning = true;
        Destroy(gameObject);
    }
}

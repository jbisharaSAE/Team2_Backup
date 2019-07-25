using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTutorial : MonoBehaviour
{
    public SpawnEnemy firstEnemySpawn;
    public GameObject scoreBoard;

    

    private AudioSource audioStart;

    private void Start()
    {
        audioStart = gameObject.GetComponent<AudioSource>();
    }
    public void StartSpawningEnemies()
    {
        //scoreBoard.SetActive(true);
        audioStart.Play();
        firstEnemySpawn.isSpawning = true;
        Destroy(gameObject);
    }
}

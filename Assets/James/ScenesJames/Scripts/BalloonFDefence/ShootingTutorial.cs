using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTutorial : MonoBehaviour
{
    public SpawnEnemyManager firstEnemySpawn;
    public GameObject scoreBoard;

    

    private AudioSource audioStart;

    private void Start()
    {
        audioStart = gameObject.GetComponent<AudioSource>();
    }
    public void StartSpawningEnemies()
    {
        
        audioStart.Play();

        //starts spawning enemies
        firstEnemySpawn.gameOver = false;
        Destroy(gameObject);
    }
}

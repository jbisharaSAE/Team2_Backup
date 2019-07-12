using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public bool isSpawning;
    public SpawnEnemyManager myManagerScript;

    public bool runOnce;

    [Tooltip("Spawn index of this spawn enemy object (level 1 .. 4) ")]
    public int spawnIndex;


    [Tooltip("How many enemies to spawn in total (increases by 10 each wave)")]
    public int enemyCountTotal;


    [Tooltip("How fast the enemy will spawn")]
    public float spawnInterval = 3f;
    private float currentSpawnTime = 0;
    public int enemyCounter;

    [Tooltip("How often to change speed of spawn time for enemies")]
    public float countdown = 10;
    private float currentTime = 0;

    [Tooltip("Target tag: MyTarget1 .. 4")]
    public string targetTag;

    public bool goingUp = false;

    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        currentTime += Time.deltaTime;


        if (isSpawning)
        {
            if (enemyCounter < enemyCountTotal)
            {
                //how often to spawn enemies
                if (currentSpawnTime >= spawnInterval)
                {
                    Spawn();
                    currentSpawnTime = 0;
                }

                //increases difficulty (makes enemies spawn faster)
                if (currentTime >= countdown)
                {
                    spawnInterval -= 0.1f;
                    currentTime = 0;
                }
            }
            else if (!runOnce)
            {
                if(spawnIndex == 2)
                {
                    goingUp = false;
                }
                else if (spawnIndex == 0)
                {
                    goingUp = true;
                }
                
                Debug.Log("testing call function to move scoreboard");
                // changing level (which side of the castle the player is defending from)
                myManagerScript.StartCoroutine(myManagerScript.ChangeLevel(spawnIndex, goingUp));
                runOnce = true;
            }
        }
        
        

    }

    private void Spawn()
    {
        ++enemyCounter;
        GameObject myEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        myEnemy.GetComponent<EnemyScript>().enemysTarget = targetTag;
    }
 
}

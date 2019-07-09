using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public SpawnEnemy []spawnEnemyObj;
    public WaypointSystem myWaypointSystem;
    public Transform []scoreSpawnPoints;
    public GameObject myScoreBoard;
    public float speed;
    public GameObject powerUpmanager;
    public GameObject[] enemyPathAreas;
    public int difficultyCounter;

    private int index = 0;
    private bool isMoving;

    private void Update()
    {
        if (isMoving)
        {
            myScoreBoard.transform.position = Vector3.MoveTowards(myScoreBoard.transform.position, scoreSpawnPoints[index+1].transform.position, speed * Time.deltaTime);

            float dist = Vector3.Distance(myScoreBoard.transform.position, scoreSpawnPoints[index+1].transform.position);

            if (dist < 0.1f)
            {
                ++index;
                index %= scoreSpawnPoints.Length;
                isMoving = false;
            }
        }
    }

    //simple coroutine that switches between fighting areas, and begins the process of moving the player position
    public IEnumerator ChangeLevel(int i)
    {
        spawnEnemyObj[i].isSpawning = false;

        // moves the spawning area for power up ballons to the next area wave of enemies
        powerUpmanager.transform.position = enemyPathAreas[i + 1].transform.position;

        yield return new WaitForSeconds(10f);
        myWaypointSystem.SendMessage("ChangePlayerPosition");
        
        // this allows the scoreboard to move
        isMoving = true;

        // increases difficulty every wave, by increasing the total number of enemies
        difficultyCounter += 10;

        yield return new WaitForSeconds(5f);
        spawnEnemyObj[i+1].enemyCountTotal += difficultyCounter;
        spawnEnemyObj[i+1].isSpawning = true;


    }
}

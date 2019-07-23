using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public SpawnEnemy []spawnEnemyObj;
    public WaypointSystem myWaypointSystem;
    public Transform []healthBoardSpawnPoints;
    public GameObject castleHealthBoard;
    public float speed;
    public GameObject powerUpmanager;
    public GameObject[] enemyPathAreas;
    public int difficultyCounter;

    private int index = 0;
    private bool isMoving;
    

    private int moveCounter = 0;

    private void Update()
    {
        if (isMoving)
        {
            // moves the castle health UI display behind each wave, everytime the next wave comes
            castleHealthBoard.transform.position = Vector3.MoveTowards(castleHealthBoard.transform.position, healthBoardSpawnPoints[index].transform.position, speed * Time.deltaTime);

            float dist = Vector3.Distance(castleHealthBoard.transform.position, healthBoardSpawnPoints[index].transform.position);

            if (dist < 0.1f)
            {
                
                isMoving = false;
            }
        }
    }

    //simple coroutine that switches between fighting areas, and begins the process of moving the player position
    public IEnumerator ChangeLevel(int i, bool goingUp)
    {
        spawnEnemyObj[i].isSpawning = false;
        spawnEnemyObj[i].enemyCounter = 0;

        yield return new WaitForSeconds(3f);

        // this allows the health bar board to move
        isMoving = true;

        // determines which direction the scoreboard needs to go
        if (goingUp)
        {
            index = i + 1;
            spawnEnemyObj[i + 1].enemyCountTotal += difficultyCounter;
            spawnEnemyObj[i + 1].isSpawning = true;
            spawnEnemyObj[i + 1].runOnce = false;
            spawnEnemyObj[i + 1].goingUp = true;

            // moves the spawning area for power up ballons to the next area wave of enemies
            powerUpmanager.transform.position = new Vector3(enemyPathAreas[i + 1].transform.position.x, enemyPathAreas[i + 1].transform.position.y - 10f, enemyPathAreas[i + 1].transform.position.z);
        }
        else
        {
            index = i - 1;
            spawnEnemyObj[i - 1].enemyCountTotal += difficultyCounter;
            spawnEnemyObj[i - 1].isSpawning = true;
            spawnEnemyObj[i - 1].runOnce = false;
            spawnEnemyObj[i - 1].goingUp = true;

            // moves the spawning area for power up ballons to the next area wave of enemies
            powerUpmanager.transform.position = new Vector3(enemyPathAreas[i - 1].transform.position.x, enemyPathAreas[i - 1].transform.position.y - 10f, enemyPathAreas[i - 1].transform.position.z);
        }

        // this ensures when the board is in the middle that the board moves in the correct direction
        if(i == 2)
        {
            spawnEnemyObj[i - 1].goingUp = false;
        }
        else if (i == 0)
        {
            spawnEnemyObj[i + 1].goingUp = true;
        }

       


        

        yield return new WaitForSeconds(3f); // normal time is 8
        myWaypointSystem.SendMessage("ChangePlayerPosition", index);
        


        // increases difficulty every wave, by increasing the total number of enemies
        difficultyCounter += 5;
        yield return null;

        

    }
}

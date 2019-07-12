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
    //private bool goingUp;

    private int moveCounter = 0;

    private void Update()
    {
        if (isMoving)
        {
            //Debug.Log("Testing Boolean");
            myScoreBoard.transform.position = Vector3.MoveTowards(myScoreBoard.transform.position, scoreSpawnPoints[index].transform.position, speed * Time.deltaTime);

            float dist = Vector3.Distance(myScoreBoard.transform.position, scoreSpawnPoints[index].transform.position);

            if (dist < 0.1f)
            {
                //++index;
                //index %= scoreSpawnPoints.Length;
                isMoving = false;
            }
        }
    }

    //simple coroutine that switches between fighting areas, and begins the process of moving the player position
    public IEnumerator ChangeLevel(int i, bool goingUp)
    {
        spawnEnemyObj[i].isSpawning = false;
        spawnEnemyObj[i].enemyCounter = 0;

        //yield return new WaitForSeconds(0.5f);
        

        if (goingUp)
        {
            index = i + 1;
            spawnEnemyObj[i + 1].enemyCountTotal += difficultyCounter;
            spawnEnemyObj[i + 1].isSpawning = true;
            spawnEnemyObj[i + 1].runOnce = false;
            spawnEnemyObj[i + 1].goingUp = true;
            powerUpmanager.transform.position = new Vector3(enemyPathAreas[i + 1].transform.position.x, enemyPathAreas[i + 1].transform.position.y - 10f, enemyPathAreas[i + 1].transform.position.z);
        }
        else
        {
            index = i - 1;
            spawnEnemyObj[i - 1].enemyCountTotal += difficultyCounter;
            spawnEnemyObj[i - 1].isSpawning = true;
            spawnEnemyObj[i - 1].runOnce = false;
            spawnEnemyObj[i - 1].goingUp = true;
            powerUpmanager.transform.position = new Vector3(enemyPathAreas[i - 1].transform.position.x, enemyPathAreas[i - 1].transform.position.y - 10f, enemyPathAreas[i - 1].transform.position.z);
        }

        if(i == 2)
        {
            spawnEnemyObj[i - 1].goingUp = false;
        }
        else if (i == 0)
        {
            spawnEnemyObj[i + 1].goingUp = true;
        }









        //if(i >= 2 || moveCounter > 1)
        //{
        //    goingUp = false;
        //    index = i - 1;
        //    spawnEnemyObj[i-1].runOnce = false;
        //    spawnEnemyObj[i-1].enemyCounter = 0;
        //}
        //else if (moveCounter == 0)
        //{
        //    goingUp = true;
        //    index = i + 1;
        //    spawnEnemyObj[i+1].runOnce = false;
        //    spawnEnemyObj[i+1].enemyCounter = 0;
        //}

        
        //spawnEnemyObj[i].runOnce = false;
        

        // moves the spawning area for power up ballons to the next area wave of enemies
        

        yield return new WaitForSeconds(1f); // normal time is 8
        myWaypointSystem.SendMessage("ChangePlayerPosition", index);
        
        // this allows the scoreboard to move
        isMoving = true;

        // increases difficulty every wave, by increasing the total number of enemies
        difficultyCounter += 5;

        //yield return new WaitForSeconds(1f); // normal time is 2
        //if (goingUp)
        //{
            
        //}
        //else
        //{
        //    ++moveCounter;
        //    if(moveCounter <= 2)
        //    {
        //        Debug.Log("Testing Negative Route");
        //        spawnEnemyObj[i - 1].enemyCountTotal += difficultyCounter;
        //        spawnEnemyObj[i - 1].isSpawning = true;
        //        powerUpmanager.transform.position = new Vector3(enemyPathAreas[i - 1].transform.position.x, enemyPathAreas[i - 1].transform.position.y - 10f, enemyPathAreas[i - 1].transform.position.z);
        //    }
        //    else
        //    {

        //        spawnEnemyObj[i + 1].enemyCountTotal += difficultyCounter;
        //        spawnEnemyObj[i + 1].isSpawning = true;
        //        powerUpmanager.transform.position = new Vector3(enemyPathAreas[i + 1].transform.position.x, enemyPathAreas[i + 1].transform.position.y - 10f, enemyPathAreas[i + 1].transform.position.z);
        //        moveCounter = 0;
        //    }
            
        //}

        Debug.Log(goingUp);
        Debug.Log(moveCounter);

    }
}

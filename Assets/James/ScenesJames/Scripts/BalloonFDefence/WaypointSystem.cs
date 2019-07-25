using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaypointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject[] waypoints;
    public GameObject fireWorks;
    public SpawnEnemy[] spawnEnemyScripts;
    public float speed;
    public Image blackFadeImage;
    public GameObject crossBow;
    public Transform finishingPoint;

    private GameObject[] enemies;
    private Color myColour;
    private int currentIndex = 0;
    private int destIndex = 0;
    private bool isMoving = false;
    private AudioSource endGameSFX;
    
    //private bool isPositive;

    // Start is called before the first frame update
    void Start()
    {
        // finds all gameobjects with the tag Waypoint and puts them into array ordered by name
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
        myColour = blackFadeImage.color;
        endGameSFX = gameObject.GetComponent<AudioSource>();
    }
    


    public IEnumerator ChangePlayerPosition(int index)

    {
        // grabs
        destIndex = index;
        

        crossBow.SetActive(false);

        //fades screen to black
        while (myColour.a <= 1)
        {
            myColour.a += 0.05f;
            blackFadeImage.color = myColour;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        //moves player
        player.transform.position = waypoints[destIndex].transform.position;

        yield return new WaitForSeconds(0.5f);

        while(myColour.a >= 0)
        {
            myColour.a -= 0.5f;
            blackFadeImage.color = myColour;
            yield return null;
        }

        crossBow.SetActive(true);
        yield return null;
    }

    public IEnumerator EndGame()
    {
        crossBow.SetActive(false);

        endGameSFX.Play();

        while (myColour.a <= 1)
        {
            myColour.a += 0.05f;
            blackFadeImage.color = myColour;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        player.transform.position = finishingPoint.position;

        yield return new WaitForSeconds(0.5f);

        while (myColour.a >= 0)
        {
            myColour.a -= 0.5f;
            blackFadeImage.color = myColour;
            yield return null;
        }


        //stops spawning enemies
        foreach(SpawnEnemy spawnEnemies in spawnEnemyScripts)
        {
            spawnEnemies.isSpawning = false;
        }

        // destroy all enemies in scene
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // starts shooting fireworks
        fireWorks.SetActive(true);
        

        crossBow.SetActive(true);
        yield return null;
    }
}

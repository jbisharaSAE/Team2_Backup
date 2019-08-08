using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaypointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject fireWorks;
    public Image blackFadeImage;
    public GameObject crossBow;
    public Transform finishingPoint;
    public SpawnEnemyManager spawnEnemyManager;
    public PowerUpManager powerupManager;

    private GameObject[] enemies;
    private Color myColour;
    
    private int destIndex = 0;
    private AudioSource endGameSFX;
    
    //private bool isPositive;

    // Start is called before the first frame update
    void Start()
    {
        
        myColour = blackFadeImage.color;
        endGameSFX = gameObject.GetComponent<AudioSource>();
    }
    

    public IEnumerator EndGame()
    {
        powerupManager.CancelInvoke();
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
        spawnEnemyManager.gameOver = true;

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

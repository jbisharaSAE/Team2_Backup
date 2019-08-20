using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnEnemyManager : MonoBehaviour
{
    [Tooltip("How many enemies to spawn in total each wave || change difficultyCounter variable to change how much this increases per wave")]
    public int enemyCountTotal;


    [Tooltip("How fast the enemy will spawn")]
    public float spawnInterval = 3f;
    private float currentSpawnTime = 0;
    public int enemyCounter;

    [Tooltip("How often to change speed of spawn time for enemies")]
    public float countdown = 10;
    private float currentTime = 0;

    [Tooltip("Number of waves total")]
    public int totalNumberWaves;

    public SpawnEnemy []spawnEnemyObj;

    [Tooltip("Increases number of enemies each wave")]
    public int difficultyCounter;

    public GameObject finalEnemy;
    public GameObject finalSpawnPoint;

    public WaypointSystem waypointSystemScript;

    public AudioClip[] audioWaveClips;
    public AudioSource audioSource;
        
    private int lvlCounter = 1;
    public bool gameOver;
    private bool runOnce = true;

    public TextMeshProUGUI myText;
    

    private int moveCounter = 0;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        currentSpawnTime += Time.deltaTime;
        currentTime += Time.deltaTime;

        myText.text = lvlCounter.ToString();

        if (!gameOver)
        {
            
            if (enemyCounter < enemyCountTotal)
            {
                
                //how often to spawn enemies
                if (currentSpawnTime >= spawnInterval)
                {
                    
                    SpawnEnemies();
                    currentSpawnTime = 0;
                }

                //increases difficulty (makes enemies spawn faster)
                if (currentTime >= countdown)
                {
                    spawnInterval -= 0.1f;
                    currentTime = 0;
                }
            }
            else
            {
                runOnce = true;
                ++lvlCounter;
                

                //increases number of enemies that spawn
                enemyCountTotal += difficultyCounter;
                
                

                if (lvlCounter >= totalNumberWaves)
                {
                    FinalWave();
                    
                }
                else if (runOnce)
                {
                    StartCoroutine(TimeBetweenWaves());
                }
            }
        }
        
  
    }

    private void SpawnEnemies()
    {
        ++enemyCounter;

        int randomNumber = Random.Range(0, 6);

        for(int i = 0; i < spawnEnemyObj.Length; ++i)
        {
            if(i == randomNumber)
            {
                spawnEnemyObj[i].SendMessage("Spawn");
            }
        }
    }

    private void FinalWave()
    {
        Instantiate(finalEnemy, finalSpawnPoint.transform.position, Quaternion.identity);
        //waypointSystemScript.StartCoroutine("EndGame");
    }

    IEnumerator TimeBetweenWaves()
    {

        print("testing wave between");
        runOnce = false;
        yield return new WaitForSeconds(20f);
        audioSource.clip = audioWaveClips[lvlCounter];
        audioSource.Play();

        AudioManagerBB.Instance.PlayAudio(AudioManagerBB.Instance.gameStart);

        audioSource.Play();
        enemyCounter = 0;
    }
   
}

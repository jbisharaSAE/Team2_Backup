using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTutorial : MonoBehaviour
{
    public SpawnEnemyManager firstEnemySpawn;
    public GameObject scoreBoard;
    public AudioClip gameStart;

    

    private AudioSource audioStart;

    private void Start()
    {
        audioStart = gameObject.GetComponent<AudioSource>();
        //StartCoroutine(TestingStart());
        
    }
    public void StartSpawningEnemies()
    {
        firstEnemySpawn.gameOver = false;
        firstEnemySpawn.audioSource.Play();
        AudioManagerBB.Instance.PlayAudio(gameStart);
        //audioStart.Play();

        //starts spawning enemies
        
        Destroy(gameObject);
    }

    IEnumerator TestingStart()
    {
        Debug.Log("test");
        yield return new WaitForSeconds(4f);

        StartSpawningEnemies();
    }
}

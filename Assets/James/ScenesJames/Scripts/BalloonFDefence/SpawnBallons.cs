using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallons : MonoBehaviour
{
    public GameObject balloon;
    private float timer = 3f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 2.5f)
        {
            timer = 0.0f;
            SpawnBalloon();
        }
    }
    
    private void SpawnBalloon()
    {
        float ranX = Random.Range(transform.position.x - 50f, transform.position.x + 50f);
        float ranY = Random.Range(transform.position.y, transform.position.y + 10f);
        float ranZ = Random.Range(transform.position.z - 10f, transform.position.z + 55f);

        Vector3 spawnPos = new Vector3(ranX, ranY, ranZ);

        Instantiate(balloon, spawnPos, Quaternion.identity);
    }
}

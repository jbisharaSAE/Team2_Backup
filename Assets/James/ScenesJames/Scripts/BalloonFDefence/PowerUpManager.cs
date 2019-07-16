using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Nokobot.Assets.Crossbow;

public class PowerUpManager : MonoBehaviour
{
    public OVRCrossbowShoot crossBowScript;
    public PCCrossBowShoot pcCrossBowshootScript;
    public CastleManager castleHealthScript;
    public GameObject myPowerUpBalloon;

    private float rapidFireTimer;
    private float slowTimeTimer;
    private bool firstSpawn;
    private float radius;

    private void Start()
    {
        InvokeRepeating("SpawnPowerUps", 15f, 10f);
        radius = gameObject.GetComponent<Renderer>().bounds.size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (rapidFireTimer > 0f)
        {
            pcCrossBowshootScript.shootGap = 0f;
            crossBowScript.shootGap = 0f;
            rapidFireTimer -= Time.deltaTime;
        }
        else
        {
            pcCrossBowshootScript.shootGap = 0.4f;
            crossBowScript.shootGap = 0.4f;
        }

      
    }


    public void PurplePowerUpHit()
    {
        rapidFireTimer = 3f;

        print("testing purple");

    }

    public void OrangePowerUpHit()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        print("testing orange");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().StartCoroutine(enemy.GetComponent<EnemyScript>().SlowDownEnemy());
                //StartCoroutine(enemy.SlowDownEnemy());
        }
    }

    public void GreenPowerUpHit()
    {
        castleHealthScript.SendMessage("CastleHeal");
        print("testing green");
    }


    private void SpawnPowerUps()
    {
     
        if (firstSpawn)
        {
            firstSpawn = false;

            

            float x = Random.insideUnitCircle.x * radius;
            float y = transform.position.y;
            float z = Random.insideUnitCircle.y * radius;

            x += transform.position.x;
            z += transform.position.z;

            Vector3 pos = new Vector3(x, y, z);

            Instantiate(myPowerUpBalloon, pos, Quaternion.identity);


        }

        // a chance for each type of power up balloon to spawn
        for(int i = 0; i < 3; ++i)
        {
            if(Random.value <= 0.25f)
            {
                float x = Random.insideUnitCircle.x * radius;
                float y = transform.position.y;
                float z = Random.insideUnitCircle.y * radius;

                x += transform.position.x;
                z += transform.position.z;

                Vector3 pos = new Vector3(x, y, z);

                Instantiate(myPowerUpBalloon, pos, Quaternion.identity);
            }
        }
    }

}

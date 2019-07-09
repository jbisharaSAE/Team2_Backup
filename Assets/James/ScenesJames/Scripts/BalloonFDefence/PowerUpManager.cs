using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Nokobot.Assets.Crossbow;

public class PowerUpManager : MonoBehaviour
{
    public OVRCrossbowShoot crossBowScript;
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
            crossBowScript.shootGap = 0f;
            rapidFireTimer -= Time.deltaTime;
        }
        else
        {
            crossBowScript.shootGap = 0.4f;
        }

        if (slowTimeTimer > 0f)
        {
            Time.timeScale = 0.5f;
            slowTimeTimer -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }


    public void PurplePowerUpHit()
    {
        slowTimeTimer = 3f;

    }

    public void OrangePowerUpHit()
    {
        rapidFireTimer = 2.5f;
    }

    public void GreenPowerUpHit()
    {
        castleHealthScript.SendMessage("CastleHeal");
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

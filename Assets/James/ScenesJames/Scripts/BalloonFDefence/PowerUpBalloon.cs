using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Nokobot.Assets.Crossbow;

public class PowerUpBalloon : MonoBehaviour
{
    private Rigidbody rb;
    private int randomNumber;

    public Material[] myColours;
    public PowerUpManager powerUpManagerScript;
    private float speed;

    private void Awake()
    {
        powerUpManagerScript = GameObject.Find("EGO Spawning PowerUP Balloons").GetComponent<PowerUpManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = Random.Range(60f, 80f);
    }
    
    void Start()
    {

        // Random colour generator
        randomNumber = Random.Range(0, 3);

        for (int i = 0; i < myColours.Length; ++i)
        {
            if (i == randomNumber)
            {
                gameObject.GetComponent<Renderer>().material = myColours[i];
            }

        }

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = Vector3.up * speed * Time.deltaTime;
    }

    public void ExplodePowerUpBalloon()
    {
        //disables interaction so we can still use the transform of this object to spawn fireworks
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        

        // use the same random number generated to determine what happens when powerup balloon is hit by arrow
        switch (randomNumber)
        {
            //purple balloon
            case 0:
                powerUpManagerScript.SendMessage("PurplePowerUpHit");
                Destroy(gameObject);
                break;
            //orange balloon
            case 1:
                powerUpManagerScript.SendMessage("OrangePowerUpHit");
                Destroy(gameObject);
                break;
            //green ballon
            case 2:
                powerUpManagerScript.SendMessage("GreenPowerUpHit");
                Destroy(gameObject);
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Arrow")
        {
            ExplodePowerUpBalloon();

           

        }
    }
}

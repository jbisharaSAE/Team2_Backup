using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    public GameObject myPowerUpBalloon;
    public Transform spawnPoint;
    public int arrowAmount = 20;
    private float radius;
    public float power;

    private void Start()
    {
        radius = gameObject.GetComponent<Renderer>().bounds.size.x / 2f;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
          //  SpawnArrows();
    }

    public void SpawnArrows()
    {
       

        print("testing Spawn");

        

        for (int i = 0; i< arrowAmount; ++i)
        {
            float x = Random.insideUnitCircle.x * radius;
            float y = spawnPoint.position.y;
            float z = Random.insideUnitCircle.y * radius;

            x += spawnPoint.position.x;
            z += spawnPoint.position.z;

            Vector3 pos = new Vector3(x, y, z);
            
            Instantiate(myPowerUpBalloon, pos, spawnPoint.rotation).GetComponent<Rigidbody>().AddRelativeForce(myPowerUpBalloon.transform.forward* power);
        }
    }
}

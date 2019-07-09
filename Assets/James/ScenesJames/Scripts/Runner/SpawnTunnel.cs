using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTunnel : MonoBehaviour
{
    public TunnelFunctions tunnelManagerScript;

    private void Start()
    {
        //pos = 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Testing Trigger");

            tunnelManagerScript.SendMessage("RandomObstacles");
            //Vector3 pos = new Vector3(transform.position.x + 224f, transform.position.y, transform.position.z);
            //Instantiate(myTunnel, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

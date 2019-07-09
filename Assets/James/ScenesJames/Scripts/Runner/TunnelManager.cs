using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject []tunnels;
    public GameObject spawnPoint;
    public GameObject lastTunnel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(GameObject tunnel in tunnels)
        {
            if(tunnel.transform.position.x < -250.0f)
            {
                //using last tunnel position to create an endless tunnel (multiple gameobjects)
                tunnel.transform.position = lastTunnel.transform.position + new Vector3(250, 0f, 0f);
                //tunnel.GetComponent<TunnelFunctions>().RandomObstacles();
                lastTunnel = tunnel;
            }
        }
    }
}

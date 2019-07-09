using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject[] waypoints;
    public float speed;

    private int currentIndex = 0;
    private int destIndex = 0;
    private bool isMoving = false;
    //private bool isPositive;

    // Start is called before the first frame update
    void Start()
    {
        // finds all gameobjects with the tag Waypoint and puts them into array ordered by name
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
    }
    
    // Update is called once per frame
    void Update()
    {
        // does a check to see if we need to start moving the player
        if (currentIndex != destIndex)
        {
                // starts moving the player to the next waypoint position
                if(player.transform.position != waypoints[currentIndex + 1].transform.position)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[currentIndex + 1].transform.position, speed * Time.deltaTime);
                }
                else
                {
                    if(currentIndex == (waypoints.Length - 1))
                    {
                    currentIndex = 0;
                    }
                    else
                    {
                        ++currentIndex;
                    }
                    
                }
   
        }

        
    }

    public void ChangePlayerPosition()

    {
        

        // changes destination index to start moving the player to the next waypoint
        destIndex += 1;
        destIndex %= waypoints.Length;
        Debug.Log("TestingMethodCall");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaypointSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject[] waypoints;
    public float speed;
    public Image blackFadeImage;

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



        //if (currentIndex != destIndex)
        //{
        //        // starts moving the player to the next waypoint position
        //        if(player.transform.position != waypoints[currentIndex + 1].transform.position)
        //        {
        //            player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[currentIndex + 1].transform.position, speed * Time.deltaTime);
        //        }
        //        else
        //        {
        //            if(currentIndex == (waypoints.Length - 1))
        //            {
        //            currentIndex = 0;
        //            }
        //            else
        //            {
        //                ++currentIndex;
        //            }
                    
        //        }
   
        //}

        if (isMoving)
        {
            Color tempColour;
            //tempColour.a += 0.1f;

            //blackFadeImage.color.a += 0.1f;

            player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints[destIndex].transform.position, speed * Time.deltaTime);

            float getDistance = Vector3.Distance(player.transform.position, waypoints[destIndex].transform.position);

            if(getDistance < 0.1)
            {
                isMoving = false;
            }
        }

        
    }

    public IEnumerator ChangePlayerPosition(int index)

    {
        isMoving = true;
        yield return new WaitForSeconds(1);
        destIndex = index;
        
        // changes destination index to start moving the player to the next waypoint
        //destIndex += 1;
        //destIndex %= waypoints.Length;
        //Debug.Log("TestingMethodCall");
    }
}

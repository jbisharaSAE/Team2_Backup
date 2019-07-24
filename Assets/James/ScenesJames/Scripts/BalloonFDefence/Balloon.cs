using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    
    private Rigidbody rb;
    private int randomNumber;

    [Tooltip("Points for red balloon")]
    public int redBalloonPoints;
    [Tooltip("Points for white balloon")]
    public int aquaBalloonPoints;
    [Tooltip("Points for pink balloon")]
    public int pinkBalloonPoints;

    public Material[] myColours;  // orange, red, blue
    public GameObject[] fireworks;
    public ScoreManager myScoreManagerScript;

    public AudioClip balloonPop;
    public AudioClip balloonHit1;
    public AudioClip balloonHit2;
    public AudioClip fireWorkSound;

    private AudioSource myAudioSource;
    private int hitCounter;
    

    // Start is called before the first frame update
    void Start()
    {

        // Random colour generator
        randomNumber = Random.Range(0, 3);
       
        for(int i = 0; i < myColours.Length; ++i)
        {
            if (i == randomNumber)
            {
                gameObject.GetComponent<Renderer>().material = myColours[i];
                hitCounter = i;

            }
                
        }

        myScoreManagerScript = GameObject.Find("EGO Score Manager").GetComponent<ScoreManager>();

        myAudioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

 

    public void ExplodeBalloon()
    {
        //disables interaction so we can still use the transform of this object to spawn fireworks
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        GameObject myObj;
        myAudioSource.clip = balloonPop;
        myAudioSource.Play();
        myAudioSource.clip = fireWorkSound;
        myAudioSource.Play();

        // spawn the same firework for each type of balloon, then destroys them
        switch (randomNumber)
        {
            //orange balloon
            case 0:
                myObj = Instantiate(fireworks[0], transform.position, Quaternion.identity);
                myObj.transform.up = Vector3.up;
                Destroy(myObj, 3.5f);
                Destroy(gameObject, 3.5f);
                myScoreManagerScript.SendMessage("UpdateScore", redBalloonPoints);
                break;
            //red balloon
            case 1:
                myObj = Instantiate(fireworks[1], transform.position, Quaternion.identity);
                myObj.transform.up = Vector3.up;
                Destroy(myObj, 3.5f);
                Destroy(gameObject, 3.5f);
                myScoreManagerScript.SendMessage("UpdateScore", aquaBalloonPoints);
                break;
            //pink ballon
            case 2:
                myObj = Instantiate(fireworks[2], transform.position, Quaternion.identity);
                myObj.transform.up = Vector3.up;
                Destroy(myObj, 3.5f);
                Destroy(gameObject, 3.5f);
                myScoreManagerScript.SendMessage("UpdateScore", pinkBalloonPoints);

                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject parentObj;

        if(collision.gameObject.tag == "Arrow")
        {
            --hitCounter;

            // the hit counter determines how many hits a specific balloon is required before exploding, initialised in the start function
            switch (hitCounter)
            {
                case 0:
                    ExplodeBalloon();

                    //destroys parent object, keeps the child (the balloon)
                    parentObj = transform.parent.gameObject;
                    transform.parent = null;
                    Destroy(parentObj);
                    break;
                case 1:
                    myAudioSource.clip = balloonHit1;
                    myAudioSource.Play();
                    break;
                case 2:
                    myAudioSource.clip = balloonHit2;
                    myAudioSource.Play();
                    break;
            }
           
        }
    }
}

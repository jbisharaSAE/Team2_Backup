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
    public int whiteBalloonPoints;
    [Tooltip("Points for pink balloon")]
    public int pinkBalloonPoints;

    public Material[] myColours;
    public GameObject[] fireworks;
    public ScoreManager scoreManagerScript;

    public AudioClip balloonPop;
    public AudioClip fireWorkSound;

    private AudioSource myAudioSource;
    

    private void Awake()
    {
        scoreManagerScript = GameObject.Find("EGO Score Manager").GetComponent<ScoreManager>();
        

    }
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
            }
                
        }

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
            //pink balloon
            case 0:
                myObj = Instantiate(fireworks[0], transform.position, Quaternion.identity);
                Destroy(myObj, 2.5f);
                Destroy(gameObject, 2.5f);
                scoreManagerScript.UpdateScore(pinkBalloonPoints);
                break;
            //red balloon
            case 1:
                myObj = Instantiate(fireworks[1], transform.position, Quaternion.identity);
                Destroy(myObj, 2.5f);
                Destroy(gameObject, 2.5f);
                scoreManagerScript.UpdateScore(redBalloonPoints);
                break;
            //white ballon
            case 2:
                myObj = Instantiate(fireworks[2], transform.position, Quaternion.identity);
                myObj.transform.up = Vector3.up;
                Destroy(myObj, 2.5f);
                Destroy(gameObject, 2.5f);
                scoreManagerScript.UpdateScore(whiteBalloonPoints);
                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject parentObj;

        if(collision.gameObject.tag == "Arrow")
        {
            ExplodeBalloon();

            //destroys parent object, keeps the child (the balloon)
            parentObj = transform.parent.gameObject;
            transform.parent = null;
            Destroy(parentObj);
            
        }
    }
}

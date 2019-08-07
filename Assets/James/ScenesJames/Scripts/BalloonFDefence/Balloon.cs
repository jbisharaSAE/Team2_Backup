using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    
    private Rigidbody rb;
    public int numberRef;

    [Tooltip("Points for red balloon")]
    public int redBalloonPoints;
    [Tooltip("Points for white balloon")]
    public int aquaBalloonPoints;
    [Tooltip("Points for pink balloon")]
    public int pinkBalloonPoints;


    public GameObject[] myBalloons;

    public Material[] myColours;  // orange, red, blue
    public GameObject[] fireworks;
    public ScoreManager myScoreManagerScript;

    public AudioClip balloonPop;
    public AudioClip balloonHit1;
    public AudioClip balloonHit2;
    public AudioClip fireWorkSound;

    private AudioSource myAudioSource;
    private GameObject parentObj;
    public int hitCounter = 0;

   

    // variables that control vibrating balloon when hit

    private float speed;
    private float amount;
    private bool balloonHit;
   
    
    

    // Start is called before the first frame update
    void Start()
    {

        // Random colour generator
        //randomNumber = Random.Range(0, 3);

        parentObj = transform.parent.gameObject;

        for (int i = 0; i < myColours.Length; ++i)
        {
            if (i == numberRef)
            {
                gameObject.GetComponent<Renderer>().material = myColours[i];
                hitCounter = i;

                //balloons being turned on
                myBalloons[i].SetActive(true);



            }
                
        }

        myScoreManagerScript = GameObject.Find("EGO Score Manager").GetComponent<ScoreManager>();

        myAudioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // TODO - testing vibration on balloon when hit, performance issues maybe.
    //private void Update()
    //{
    //    if (balloonHit)
    //    {


    //        gameObject.transform.position.x = Mathf.Sin(Time.time * speed) * amount;
    //        gameObject.transform.position.y = Mathf.Sin(Time.deltaTime * speed) * amount;
    //    }
        
    //}


    public void ExplodeBalloon()
    {
        //disables interaction so we can still use the transform of this object to spawn fireworks
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        myBalloons[numberRef].SetActive(false);
        GameObject myObj;
        myAudioSource.clip = balloonPop;
        myAudioSource.Play();
        myAudioSource.clip = fireWorkSound;
        myAudioSource.Play();

        // spawn the same firework for each type of balloon, then destroys them
        switch (numberRef)
        {
            //Red balloon
            case 0:
                myObj = Instantiate(fireworks[0], transform.position, Quaternion.identity);
                myObj.transform.up = Vector3.up;
                Destroy(myObj, 3.5f);
                Destroy(gameObject, 3.5f);
                myScoreManagerScript.SendMessage("UpdateScore", redBalloonPoints);
                break;
            //Aqua balloon
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
        

        if(collision.gameObject.tag == "Arrow")
        {
            hitCounter--;
            Destroy(collision.gameObject);

            // the hit counter determines how many hits a specific balloon is required before exploding, initialised in the start function
            switch (hitCounter)
            {
                                   
                case 1:
                    myAudioSource.clip = balloonHit1;
                    myAudioSource.Play();
                    break;
                case 2:
                    myAudioSource.clip = balloonHit2;
                    myAudioSource.Play();
                    break;
                default:
                    ExplodeBalloon();

                    //destroys parent object, keeps the child (the balloon)

                    //transform.parent = null;

                    parentObj.SendMessage("StartRunning");

                    //Destroy(parentObj);
                    break;

            }
           
        }
    }
}

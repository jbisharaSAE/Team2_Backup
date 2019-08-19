using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBalloon : MonoBehaviour
{
    public AudioClip balloonPop;
    public AudioClip balloonHit1;
    public AudioClip balloonHit2;


    private AudioSource myAudioSource;
    private GameObject parentObj;
    public int hitCounter = <10;



    // variables that control vibrating balloon when hit

    private float speed;
    private float amount;
    private bool balloonHit;




    // Start is called before the first frame update
    void Start()
    {



        myAudioSource = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void ExplodeBalloon()
    {
        transform.parent = null;



        AudioManagerBB.Instance.PlayAudio(balloonPop);


        //myAudioSource.clip = balloonPop;
        //myAudioSource.Play();
        //myAudioSource.clip = fireWorkSound;
        //myAudioSource.Play();



        private void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.tag == "Arrow")
            {
                hitCounter--;
                Destroy(collision.gameObject);


                //destroys parent object, keeps the child (the balloon)



                parentObj.SendMessage("StartRunning");

                //Destroy(parentObj);
                break;
            }
        }
    }
}
            

            

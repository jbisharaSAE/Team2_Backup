using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlue : MonoBehaviour
{
    public Rigidbody rb;
    public AudioClip arrowShoot;
    public AudioClip arrowReload;
    public AudioClip metalImpact;
    private AudioSource myAudioSource;


    private void Start()
    {
        StartCoroutine(ArrowSounds());
        myAudioSource = gameObject.GetComponent<AudioSource>();
        myAudioSource.clip = arrowShoot;
        myAudioSource.Play();

        Destroy(gameObject, 30f);
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Powerup")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            myAudioSource.clip = metalImpact;
            myAudioSource.Play();
        }
        

    }

    private IEnumerator ArrowSounds()
    {
  
        yield return new WaitForSeconds(0.2f);

        myAudioSource.clip = arrowReload;
        myAudioSource.Play();
    }
}

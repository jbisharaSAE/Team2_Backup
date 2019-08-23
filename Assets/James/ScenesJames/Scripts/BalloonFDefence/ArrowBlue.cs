using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlue : MonoBehaviour
{
    public Rigidbody rb;
    public AudioClip arrowShoot;
    public AudioClip arrowReload;
    public AudioClip metalImpact;
    public AudioSource myAudioSource;
    //public GameObject myArrow;


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
        Destroy(gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //AudioManagerBB.Instance.PlayAudio(metalImpact);

            myAudioSource.clip = metalImpact;
            myAudioSource.Play();
        }
        //else if(collision.gameObject.tag == "Rainbow")
        //{
        //    Debug.Log("testing balloon collision");
        //}


    }

    private IEnumerator ArrowSounds()
    {
  
        yield return new WaitForSeconds(0.2f);

        myAudioSource.clip = arrowReload;
        myAudioSource.Play();
    }
}

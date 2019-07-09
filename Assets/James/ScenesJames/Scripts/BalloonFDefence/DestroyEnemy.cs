using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public CastleManager castleManagerScript;

    public AudioClip gateAttackSFX;
    private AudioSource gateAttackSource;

    private void Start()
    {
        gateAttackSource.clip = gateAttackSFX;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Balloon")
        {
            gateAttackSource.Play();
            castleManagerScript.SendMessage("CastleHit", 10f);
            print("testing Collision");
            Destroy(other.transform.parent.gameObject);
        }
    }

}

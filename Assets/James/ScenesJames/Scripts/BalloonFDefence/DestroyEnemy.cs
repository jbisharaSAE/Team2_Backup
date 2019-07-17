using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public CastleManager castleManagerScript;

    public AudioClip gateAttackSFX;
    private AudioSource gateAttackSource;
    public float damageCastleAmount = 5f;

    private void Start()
    {
        gateAttackSource = gameObject.GetComponent<AudioSource>();
        gateAttackSource.clip = gateAttackSFX;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Balloon")
        {
            gateAttackSource.Play();
            castleManagerScript.SendMessage("CastleHit", damageCastleAmount);
            print("testing Collision");
            Destroy(other.transform.parent.gameObject);
        }
    }

}

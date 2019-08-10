using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public CastleManager castleManagerScript;

    public AudioClip gateAttackSFX;
    private AudioSource gateAttackSource;
    public float damageCastleAmount = 5f;
    public GameObject explosion;

    private void Start()
    {
        gateAttackSource = gameObject.GetComponent<AudioSource>();
        gateAttackSource.clip = gateAttackSFX;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Balloon")
        {
            if (!other.transform.parent.gameObject.GetComponent<EnemyScript>().isRunning)
            {
                gateAttackSource.Play();
                castleManagerScript.SendMessage("CastleHit", damageCastleAmount);
                StartCoroutine(StartExplosion());
                
            }
            
            //Destroy(other.transform.parent.gameObject.GetComponent<EnemyScript>().);
        }
    }

    private IEnumerator StartExplosion()
    {
        explosion.SetActive(true);
        yield return new WaitForSeconds(2f);
        explosion.SetActive(false);
    }

}

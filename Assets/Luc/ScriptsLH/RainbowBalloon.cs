using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBalloon : MonoBehaviour
{
    public AudioClip balloonPop;
    public AudioClip balloonHit;

    public int maxHits;


    
    private GameObject parentObj;
    private int hitCounter = 0;

    public void ExplodeBalloon()
    {
        transform.parent = null;

        AudioManagerBB.Instance.PlayAudio(balloonPop);

        
    }

    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.tag == "Arrow")
        {
            ++hitCounter;

            if(hitCounter > maxHits)
            {
                Destroy(collision.gameObject);
                ExplodeBalloon();
            }
            else
            {
                AudioManagerBB.Instance.PlayAudio(balloonHit);
                parentObj.SendMessage("StartRunning");
            }
            

            
        }
    }
}
            

            

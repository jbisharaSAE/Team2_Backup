using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlue : MonoBehaviour
{
    public Rigidbody rb;

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
        

    }
}

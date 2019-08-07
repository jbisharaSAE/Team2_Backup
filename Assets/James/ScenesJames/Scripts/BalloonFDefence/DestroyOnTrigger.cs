using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{

    private GameObject objToDestroy;

    public GameObject effect;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            Destroy(other.gameObject);


            objToDestroy = Instantiate(effect, other.gameObject.transform.position, Quaternion.identity);

            Destroy(objToDestroy, 2f);
        }
    }

}

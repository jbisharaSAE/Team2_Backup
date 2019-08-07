using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{

    public GameObject objToDestroy;
    public GameObject effect;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "powerup")
            Instantiate(effect, objToDestroy.transform.position, objToDestroy.transform.rotation);
        Destroy(objToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

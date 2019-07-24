using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillMovee : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
        //rotation code so windmill blades can spin 
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime , 0));
    }
}


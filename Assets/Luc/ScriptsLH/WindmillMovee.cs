using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillMovee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
        //rotation code so windmill blades can spin 
    {
        transform.Rotate(new Vector3(Time.deltaTime* 0,1 , 0));
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
    private float moveHorizontal;
    public GameObject myCamera;
    private Vector3 camDirection;
    public float speed;
    public float force;
    int layerMask = 1 << 9;


    // Start is called before the first frame update
    void Start()
    {
        camDirection = myCamera.transform.forward;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");



        //gets the ray direction from camera to world mouse location
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //returns true if ray cast hits wall
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Wall")
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(hit.point);
                    

                    // Debug.Log("testing mouse");

                }

            }

        }





    }

    private void FixedUpdate()
    {
      

        rb.AddForce(0, 0, -1* (moveHorizontal*force));

    }

  
        
       
       

}

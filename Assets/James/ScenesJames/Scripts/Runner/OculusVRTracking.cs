using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusVRTracking : MonoBehaviour
{

    //public Transform controller;
    
    private Rigidbody myRigidBody;
    private RaycastHit hit;
    private Vector3 currentPos;
    private Vector3 gravityDir;
    private bool isGrapplingLeft = false;
    private bool isGrapplingRight = false;
    private bool clicked = false;
    private Vector3 end;

    public float speed;
    public float speedRot;
    public float jumpForce = 50f;
    public GameObject debugText;
    public Transform rightHandAnchor;
    public GameObject tunnels;
    public float smooth = 5.0f;

    int layerMask = 1 << 9;

    public float targetRot;
    public float angle = 0f;
    

    private static OVRInput.Controller myController = OVRInput.Controller.RTrackedRemote;


    //public static bool leftHanded { get; private set; }

    //System.IO.StreamWriter recording;

    //void Awake()
    //{
    //#if UNITY_EDITOR
    //        leftHanded = false;        // (whichever you want to test here)
    //#else
    //        leftHanded = OVRInput.GetControllerPositionTracked(OVRInput.Controller.LTouch);
    //#endif
    //}

    private void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody>();
        currentPos = transform.position;
    }

    void Update()
    {
        Vector3 rot = tunnels.transform.eulerAngles;
        rot.x = angle;
        tunnels.transform.eulerAngles = rot;
        
        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        

        //gets the ray direction from camera to world mouse location
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //returns true if ray cast hits wall
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log(hit.point);


                if (Input.GetMouseButtonDown(0))
                {

                    end = tunnels.transform.right;
                    clicked = true;

                    // gets new position for player to move towards
                    //currentPos = hit.point;

                    //myRigidBody.useGravity = false;
                    
                    //changes direction of gravity
                    //gravityDir = -10 * hit.normal;
                    //Physics.gravity = new Vector3(gravityDir.x, gravityDir.y, gravityDir.z);





                    //***************************************************************** CODE FOR ROTATING TUNNEL ****************************************************
                    //Debug.Log(hit.normal);
                    //if (hit.normal.z <= -0.9f)
                    //{
                    //    Jump();
                    //    isGrapplingLeft = true;
                    //    Debug.Log("Left");
                    //    targetRot += 90f;
                    //    //StartCoroutine(RotateTunnel(90f, true));
                    //}
                    //else if (hit.normal.z >= 0.9f)
                    //{
                    //    Jump();
                    //    isGrapplingRight = true;
                    //    targetRot -= 90f;
                    //    Debug.Log("Right");
                    //    //StartCoroutine(RotateTunnel(-90f, true));
                    //}
                    //*************************************************************************************************************************************************

                    //Debug.Log(hit.point);

                }

            

        }

        if (clicked)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, end, speed * Time.deltaTime, 0f);
            tunnels.transform.rotation = Quaternion.LookRotation(newDirection);

            if(tunnels.transform.right == end)
            {
                clicked = false;
            }
        }

        
      

        if (isGrapplingLeft)
        {
            if (targetRot > angle)
            {
                angle += Time.deltaTime * speedRot;
                if (angle >= targetRot)
                    isGrapplingLeft = false;
            }
            RotateTunnel(90f);
        }
        //else if (isGrapplingRight)
        //{
        //    if (targetRot < angle)
        //    {
        //        angle -= Time.deltaTime * speedRot;
        //        if (angle <= targetRot)
        //            isGrapplingRight = false;
        //    }
        //    RotateTunnel(-90f);
        //}


        //MoveToWall();

 

    }

    //***************************************************************** CODE FOR ROTATING TUNNEL ****************************************************
    private void RotateTunnel(float target)
    {

        float timer = 0f;

        timer += Time.deltaTime;

        if(target == -90f)
        {
            if (timer < 1f)
            {
                tunnels.transform.Rotate(Vector3.right, speed * Time.deltaTime);
            }
            else
            {
                isGrapplingLeft = false;
            }
        }



        
        //float angle = Mathf.Lerp(0f, target, 0.8f)*Time.deltaTime;
        //print(angle);

        
        //print(newRot.x);

        //tunnels.transform.rotation = Quaternion.Slerp(tunnels.transform.rotation, newRot, Time.deltaTime * smooth);




        //float targetRot = tunnels.transform.eulerAngles.x + 90
        //if(tunnels.transform.eulerAngles.x <= targetRot)
        //tunnels.transform.Rotate(Vector3.right, speedRot * Time.deltaTime);

        
            
        //    tunnels.transform.rotation = Quaternion.Lerp(tunnels.transform.rotation, Quaternion.AngleAxis(target, Vector3.right), Time.deltaTime * 5f);
            print("TESTING");
        
       

        //Quaternion newRot = new Quaternion(tunnels.transform.eulerAngles.x + 90f, tunnels.transform.eulerAngles.y, tunnels.transform.eulerAngles.z, 1f);
        
            //tunnels.transform.eulerAngles = Vector3.Lerp(tunnels.transform.eulerAngles, new Vector3(targetRot, 0, 0), Time.deltaTime * 5);

        //    if (tunnels.transform.eulerAngles.x == (tunnels.transform.eulerAngles.x + target)); 
        //    {
        //        isGrapplingLeft = false;
        //        print("asd");
        //    }
        //}



        //if (Mathf.Abs(tunnels.transform.rotation.x *10f) == Mathf.Abs(target*10f))
        //{



        //    //print(isRotating);
        //    print(isGrapplingLeft);
        //    print(isGrapplingRight);
        //    //tunnels.transform.rotation = newRot;




        //*************************************************************************************************************************************************

    }

    //private void MoveToWall()
    //{
    //    Vector3 newPos = new Vector3(transform.position.x, currentPos.y, currentPos.z);

    //    if(isGrapplingLeft || isGrapplingRight)
    //    {
            
    //        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        //Physics.gravity = gravityDir;
    //        myRigidBody.useGravity = true;
    //        isGrapplingLeft = false;
    //        isGrapplingRight = false;

    //    }
    //}

    private void FixedUpdate()
    {
        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        //returns true if ray cast hits wall
        if (Physics.Raycast(rightHandAnchor.position, rightHandAnchor.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Wall")
            {
                if (indexTrigger != 0.0f)
                {
                    currentPos = hit.point;
                    //isGrappling = true;


                    myRigidBody.useGravity = false;

                    //changes direction of gravity
                    gravityDir = -10 * hit.normal;
                    Physics.gravity = new Vector3(gravityDir.x, gravityDir.y, gravityDir.z);
                }


            }

        }
    }

    private void Jump()
    {
        myRigidBody.velocity = Vector3.up * jumpForce;


    }

    ////to stop player gameobject from trying to overlap collider
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        isGrapplingLeft = false;
    //        isGrapplingRight = false;
    //    }
    //}
}

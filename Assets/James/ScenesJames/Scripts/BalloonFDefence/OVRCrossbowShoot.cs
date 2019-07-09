using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nokobot.Assets.Crossbow
{
    public class OVRCrossbowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;
        //public GameObject myCircle;
        public ScoreManager myScoreScript;
        //public Text testingTextButton;
        public Transform[] arrowLocations;

        private float timer;
        private bool myToggle;

        public bool specialAbility = false;
        public float shootGap = 0.4f;
        
        public float shotPower = 100f;

        public AudioClip arrowShoot;
        public AudioClip arrowReload;


        private AudioSource shootAudioSource;

        public Transform rightHandAnchor;

        private static OVRInput.Controller myController = OVRInput.Controller.RTrackedRemote;

        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void FixedUpdate()
        {
            float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
            timer += Time.deltaTime;

            
            if (indexTrigger != 0.0f)
            {
                if(timer >= shootGap)
                {
                    //shootAudioSource.clip = arrowShoot;
                    //shootAudioSource.Play();
                    timer = 0f;

                    Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);

                    //shootAudioSource.clip = arrowReload;
                    //shootAudioSource.Play();
                }
                
            }

            //Ray ray;

            //RaycastHit hit;

            //returns true if ray cast hits wall
            //if (Physics.Raycast(rightHandAnchor.position, rightHandAnchor.forward, out hit, Mathf.Infinity))
            //{
            //    if (hit.collider.tag == "Ground")
            //    {
            //        if (myScoreScript.progressRatio >= 100f)
            //        {
            //            specialAbility = true;

            //            if (indexTrigger != 0.0f)
            //            {

            //                rainArrowsScript.SendMessage("SpawnArrows");


            //            }
            //        }


            //    }

            //}

            if (myScoreScript.progressScore >= 100f)
            {
                specialAbility = true;
                
            }

            if (specialAbility)
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    specialAbility = false;
                    myToggle = true;
                }

            }

            if (myToggle)
            {
                foreach(Transform arrowLoc in arrowLocations)
                {
                    Instantiate(arrowPrefab, arrowLoc.position, arrowLoc.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
                }
                myToggle = false;
                myScoreScript.progressScore = 0f;
                myScoreScript.pointsAdded = 0;
            }
            
            


            //SpecialArrows(specialAbility, hit);

            Quaternion myRotation =  OVRInput.GetLocalControllerRotation(myController);

            //myText.text = myRotation.eulerAngles.z.ToString();

            if(myRotation.eulerAngles.z > 70f && myRotation.eulerAngles.z < 180f)
            {
               // myText.text = "This .. is a test!";
            }


               
        }


        //private void SpecialArrows(bool active, RaycastHit objHit)
        //{
        //    if (active)
        //    {
        //        myCircle.SetActive(true);
        //        myCircle.transform.position = objHit.point;
        //    }
        //    else
        //    {
        //        myCircle.SetActive(false);
        //    }
        //}
    }

    
}

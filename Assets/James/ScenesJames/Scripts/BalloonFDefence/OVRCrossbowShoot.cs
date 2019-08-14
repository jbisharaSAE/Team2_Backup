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
        
        public ScoreManager myScoreScript;
        
        public Transform[] arrowLocations;
        public ShootingTutorial tutorialBoard;
        public GameObject tutorial1;
        public GameObject tutorial2;
        public Animator xBowAnimController;
        

        private float timer;
        private bool myToggle;
        private bool isTutorial = true;
        private bool runOnce = true;

        public bool specialAbility = false;
        public float shootGap = 0.4f;
        
        public float shotPower = 100f;

        public Transform rightHandAnchor;

        private static OVRInput.Controller myController = OVRInput.Controller.RTrackedRemote;

        //void Start()
        //{
        //    if (arrowLocation == null)
        //        arrowLocation = transform;
        //}

        void FixedUpdate()
        {
            float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
            timer += Time.deltaTime;


            if (indexTrigger != 0.0f)
            {
                if (timer >= shootGap)
                {
                    
                    timer = 0f;

                    GameObject arrow = Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation);
                    arrow.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);

                    if (shootGap >= 0)
                    {
                        arrow.GetComponent<AudioSource>().volume = 0f;
                    }
                    else
                    {
                        arrow.GetComponent<AudioSource>().volume = 1f;
                    }
                    xBowAnimController.SetTrigger("normalTrigger");


                }

                // to flick to the next tutorial slide, once player has  shot an arrow
                if (runOnce)
                {
                    runOnce = false;
                    tutorial1.SetActive(false);
                    tutorial2.SetActive(true);
                    StartCoroutine(StartSpawningEnemies());
                }

            }


          

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
                    //Debug.Log("testing special ability");

                }

            }

            if (myToggle)
            {
                MultishotAbility();
                
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

        private void MultishotAbility()
        {
            //Debug.Log("testing special function");
            foreach (Transform arrowLoc in arrowLocations)
            {
                Instantiate(arrowPrefab, arrowLoc.position, arrowLoc.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
            }
            myToggle = false;
            myScoreScript.progressScore = 0f;
            myScoreScript.pointsAdded = 0;
        }

        private IEnumerator StartSpawningEnemies()
        {
            yield return new WaitForSeconds(4f);
            tutorialBoard.SendMessage("StartSpawningEnemies");
            tutorial2.SetActive(true);

        }
    }

    
}

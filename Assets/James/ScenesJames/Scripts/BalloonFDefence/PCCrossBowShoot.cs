using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class PCCrossBowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;
        public GameObject myCircle;
        public ScoreManager myScoreScript;

        private float shootGap = 0.4f;
        private float timer;
        public float shotPower = 100f;
        private static OVRInput.Controller myController = OVRInput.Controller.RTrackedRemote;
        private LayerMask layerMask = 1 << 10;
        private bool specialAbility;

        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;
        }

        void Update()
        {
            
            timer += Time.deltaTime;


            if (Input.GetButtonDown("Fire1"))
            {
                if (timer >= shootGap)
                {
                    timer = 0f;
                    Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddForce(arrowLocation.transform.forward * shotPower);

                }

            }

            Ray ray;

            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    if (myScoreScript.progressRatio >= 100f)
                    {
                        if (Input.GetMouseButtonDown(1))
                        {
                            specialAbility = true;
                        }
                        if (Input.GetMouseButtonUp(1))
                        {
                            specialAbility = false;
                        }
                    }



                }

            
           

            SpecialArrows(specialAbility, hit);
            
        }
        
        private void SpecialArrows(bool active, RaycastHit objHit)
        {
         //   print("Hi There");
            if (active)
            {
                myCircle.SetActive(true);
                myCircle.transform.position = objHit.point;
                //if (Input.GetMouseButtonDown(1))
                    //myCircle
            }
            else
            {
                myCircle.SetActive(false);
            }
            
        }

    }
}

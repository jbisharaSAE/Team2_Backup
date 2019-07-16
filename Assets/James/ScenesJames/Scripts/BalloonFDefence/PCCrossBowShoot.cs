using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class PCCrossBowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;



        public float shootGap = 0.4f;
        private float timer;

        public float shotPower = 100f;

        


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


            
           

           
        }
        
        

    }
}

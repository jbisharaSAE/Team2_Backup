using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelFunctions : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody rb;
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        
        //rb = gameObject.GetComponent<Rigidbody>();
        //Destroy(gameObject, 15f);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime*speed);

        //rb.velocity = transform.forward * speed;
    }

    public void RandomObstacles()
    {
        foreach(GameObject obstacle in obstacles)
        {
            int randomNumber = Random.Range(0, 3);
            switch (randomNumber)
            {
                case 0:
                    obstacle.SetActive(true);
                    break;
                case 1:
                    obstacle.SetActive(false);
                    break;
            }
        }
    }
}

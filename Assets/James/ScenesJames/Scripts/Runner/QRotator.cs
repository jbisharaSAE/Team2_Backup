using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRotator : MonoBehaviour
{
    float speed = 1.0f;
    bool clicked = false;
    Vector3 end;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            end = transform.right;
            clicked = true;
        }

        if (clicked)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.up, end, speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            if (transform.up == end)
            {
                clicked = false;
            }
        }
    }
}

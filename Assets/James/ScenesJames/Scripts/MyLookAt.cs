using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLookAt : MonoBehaviour
{
    public Canvas myScoreBoard;

    [Tooltip("Game object for script to look at")]
    public Transform myTarget;

    // Update is called once per frame
    void Update()
    {
        myScoreBoard.transform.LookAt(myTarget.position);
    }
}

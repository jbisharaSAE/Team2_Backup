using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KnightAnim : MonoBehaviour
{
    private NavMeshAgent chaos;
    private Animator KnightAn;
    public bool KnightRunning;
            
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        chaos = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("MyTarget");

        
    }

    // Update is called once per frame
    void Update()
    {

        chaos.SetDestination(target.transform.position);
    }
}

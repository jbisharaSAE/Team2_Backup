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

        KnightAn.SetBool("KnightRunning", false);
        KnightAn.SetBool("KnightAttacking", false);
        KnightAn.SetBool("KnightDead", false);
    }

    // Update is called once per frame
    void Update()
    {

        chaos.SetDestination(target.transform.position);

        {
            if (KnightRunning)
            {
                //moves towards target on navmesh
                chaos.SetDestination(target.transform.position);

                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance < 5f)
                {
                    //enemyAnim.Play("Attack");

                    print("testing distance if statement");
                    KnightAn.SetBool("KnightRunning", false);
                   KnightAn.SetBool("KnightAttacking", true);
                }
            }
            else
            {
                KnightAn.SetBool("KnightAttacking", false);
                KnightAn.SetBool("KnightRunning", false);
                KnightAn.SetBool("KnightDead", true);
            }


        }


    }
}

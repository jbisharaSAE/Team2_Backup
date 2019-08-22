using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KnightAnim : MonoBehaviour
{
    private NavMeshAgent chaosKnight;
    private Animator knightAnim;
    public bool isRunning;
            
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        chaosKnight = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("MyTarget");

        knightAnim.SetBool("KnightRunning", false);
        knightAnim.SetBool("KnightAttacking", false);
        knightAnim.SetBool("KnightDead", false);
    }

    // Update is called once per frame
    void Update()
    {

        //chaosKnight.SetDestination(target.transform.position);


        if (isRunning)
        {
            //moves towards target on navmesh
            chaosKnight.SetDestination(target.transform.position);

            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < 5f)
            {
                //enemyAnim.Play("Attack");

                //print("testing distance if statement");
                knightAnim.SetBool("KnightRunning", false);
                knightAnim.SetBool("KnightAttacking", true);
                knightAnim.SetBool("KnightDead", false);
            }
        }
        else
        {
            knightAnim.SetBool("KnightAttacking", false);
            knightAnim.SetBool("KnightRunning", false);
            knightAnim.SetBool("KnightDead", true);
        }





    }

}

using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent enemy;
    private GameObject target;
    private float randomMySpeed;
    private int randomNumber;
    private bool isRunning;
    private Animator enemyAnim;

    public GameObject [] EnemyColours;
    public GameObject[] enemyTypes;

    public GameObject startingPoint;
    public string enemysTarget;
    public Balloon myBalloonScript;
    
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        // Random enemy type generator
        randomNumber = Random.Range(0, 3);

        for(int i = 0; i < 3; ++i)
        {
            if (randomNumber == i)
            {
                enemyTypes[i].SetActive(true);
                myBalloonScript.numberRef = i;
            }
        }

        enemy = gameObject.GetComponent<NavMeshAgent>();

        randomMySpeed = Random.Range(10f, 35f);
        
        // finds the target in scene
        target = GameObject.FindGameObjectWithTag(enemysTarget);

        enemy.speed = randomMySpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            //moves towards target on navmesh
            enemy.SetDestination(target.transform.position);
        }
        else

      if (!isRunning)
        {
            //moves towards target on navmesh
            enemy.SetDestination(target.transform.position);
        }
        else
        {
            enemy.SetDestination(startingPoint.transform.position);
            if (enemy.remainingDistance < 1f)
            {
                Destroy(gameObject);
            }
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);


        }
    }




    public IEnumerator SlowDownEnemy()
    {
        print("testing coroutine");
        enemy.speed *= 0.5f;
        yield return new WaitForSeconds(3);
        enemy.speed *= 2f;

    }

    public void StartRunning()
    {
        isRunning = true;

        enemyAnim.SetBool("isRunning", isRunning);
    }


}

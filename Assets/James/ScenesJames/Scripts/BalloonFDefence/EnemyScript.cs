using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent enemy;
    private GameObject target;
    private float randomMySpeed;

    public string enemysTarget;
    
    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();

        randomMySpeed = Random.Range(10f, 50f);
        // finds the target in scene
        target = GameObject.FindGameObjectWithTag(enemysTarget);
        enemy.speed = randomMySpeed;

    }

    // Update is called once per frame
    void Update()
    {
        //moves towards target on navmesh
        enemy.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
        }
    }
}

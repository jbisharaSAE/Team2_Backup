using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
   
    [Tooltip("Target tag: MyTarget1 .. 4 || this changes based on where this game object is")]
    public string targetTag;


    public void Spawn()
    {
    
        GameObject myEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        myEnemy.SetActive(true);
        myEnemy.GetComponent<EnemyScript>().enemysTarget = targetTag;
    }
 
}

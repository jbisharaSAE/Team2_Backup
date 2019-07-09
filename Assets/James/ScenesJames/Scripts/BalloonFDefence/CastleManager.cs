using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    public float castleTotalHealth;
    private float currentCastleHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentCastleHealth = castleTotalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastleHit(float dmgAmount)
    {
        currentCastleHealth -= dmgAmount;

        if (currentCastleHealth <= 0f)
        {
            EndGame();
        }
    }

    public void CastleHeal()
    {
        currentCastleHealth += 10f;
    }

    private void EndGame()
    {
        //TODO .. unclear what happens when game ends at the moment
        print("GameOver :)");
    }
}

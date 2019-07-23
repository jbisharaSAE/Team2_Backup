using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleManager : MonoBehaviour
{
    public float castleTotalHealth;
    private float currentCastleHealth;

    public Image healthBar;
    private float healthRatio;


    // Start is called before the first frame update
    void Start()
    {
        currentCastleHealth = castleTotalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthRatio = currentCastleHealth / castleTotalHealth;

        healthBar.fillAmount = healthRatio;

        
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
        currentCastleHealth += 20f;
    }

    private void EndGame()
    {
        //TODO .. unclear what happens when game ends at the moment
        print("GameOver :)");
    }
}

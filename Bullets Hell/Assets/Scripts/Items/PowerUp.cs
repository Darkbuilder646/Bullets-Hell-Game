using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [Space, Header("Power Up Attributs")]
    [SerializeField] private float attackIncrease = 1.5f;
    [SerializeField] private int pointValue = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            //? do effect
            Debug.Log("Power +");
            GameManager.ScoreManager.AddScore(pointValue);
            Destroy(gameObject);
        }
    }

}

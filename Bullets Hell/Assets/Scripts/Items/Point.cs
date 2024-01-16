using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : Item
{
    [Space, Header("Point Attributs")]
    [SerializeField] private int pointValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            Debug.Log("Add point");
            GameManager.ScoreManager.AddScore(pointValue);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    [Space, Header("Bomb Attributs")]
    [SerializeField] private int pointValue = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            //? Do effect
            Debug.Log("Bomb +1");
            Destroy(gameObject);
        }
    }
}

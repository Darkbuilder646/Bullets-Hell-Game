using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : Item
{
    [Space, Header("Bomb Attributs")]
    [SerializeField] private int pointValue = 200;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            //? Do effect
            Debug.Log("+ 1up");
            Destroy(gameObject);
        }
    }
}

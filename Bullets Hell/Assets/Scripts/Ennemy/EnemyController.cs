using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private int index = 0;

    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        Vector3 movement = new(0f, -speed * Time.deltaTime, 0f);

        transform.Translate(movement);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 6 && index == 1) //? Wall
        {
            GetComponentInChildren<BulletsSpawner>().CanStartSpawn = true;
        }
        if(other.gameObject.layer == 6 && index == 2)
        {
            GetComponentInChildren<BulletsSpawner>().CanStartSpawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6) //? Wall
        {
            index++;
        }
    }

}

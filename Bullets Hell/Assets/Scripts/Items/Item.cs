using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public int pointValue = 10;
    public bool isMoving = true;


    void Update()
    {
        MoveDown();

        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    public void MoveDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
    }

    bool IsOnScreen()
    {
        if (gameObject.transform.position.y <= -6) { return false; }
        return true;
    }
}

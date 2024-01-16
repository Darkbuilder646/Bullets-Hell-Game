using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Space, Header("Item Attributs")]
    [SerializeField] private float speed = 2f;

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

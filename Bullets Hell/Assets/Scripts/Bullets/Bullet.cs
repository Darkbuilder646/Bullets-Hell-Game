using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite graphic = null;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxDistance = 10f;
    private float traveledDistance = 0f;
    [SerializeField] private Vector2 direction = Vector2.down;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = graphic;
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
        traveledDistance += speed * Time.deltaTime;
        if (traveledDistance >= maxDistance)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}

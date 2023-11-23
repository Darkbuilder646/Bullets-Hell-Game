using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Sprite graphic = null;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotation = 0;
    private float currentTime = 0f;
    [SerializeField] private Vector2 spawn;

    public float Lifetime { get => lifetime; set => lifetime = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Rotation { get => rotation; set => rotation = value; }

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = graphic;
    }

    private void Start()
    {
        spawn = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (currentTime >= lifetime)
        {
            // gameObject.SetActive(false);
            currentTime = 0f;
            return;
        }
        currentTime += Time.deltaTime;
        transform.position = Movement(currentTime);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawn.x, y + spawn.y);
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

}

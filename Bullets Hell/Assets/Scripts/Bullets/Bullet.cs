using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Space]
    [Header("Graphic")]
    [SerializeField] private Sprite graphic = null;
    [SerializeField] private Color color = new(1, 1, 1, 1);
    [SerializeField] private float scale = 1f;
    [Space]
    [Header("Attributs")]
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float speed = 1f;
    private float currentTime = 0f;
    private Vector2 spawn;

    public float Lifetime { get => lifetime; set => lifetime = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        InitializeGraphics();
    }

    private void InitializeGraphics()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = graphic;
        spriteRenderer.color = color;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void Start()
    {
        spawn = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnEnable()
    {
        spawn = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        UpdateLifetime();
        MoveBullet();
    }

    private void UpdateLifetime()
    {
        if (currentTime >= lifetime)
        {
            KillBullet();
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    private Vector2 CalculateMovement(float timer)
    {
        float x = timer * speed * transform.up.x;
        float y = timer * speed * transform.up.y;
        return new Vector2(x, y);
    }
    private void MoveBullet()
    {
        Vector2 movement = CalculateMovement(currentTime);
        transform.position = new Vector2(movement.x + spawn.x, movement.y + spawn.y);
    }

    public void KillBullet()
    {
        gameObject.SetActive(false);
        currentTime = 0f;
    }

}

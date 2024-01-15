using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private BulletsSpawner bulletsSpawner;
    private bool inGameZone = false;
    private bool canDispawn = false;

    public bool InGameZone { get => inGameZone; }

    private void Start()
    {
        bulletsSpawner = GetComponentInChildren<BulletsSpawner>();
    }

    void Update()
    {
        MoveDown();
        if (canDispawn && bulletsSpawner.AllBulletsInactive())
        {
            DestroyEnemy();
        }
    }

    void MoveDown()
    {
        Vector3 movement = new(0f, -speed * Time.deltaTime, 0f);

        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // inGameZone = true;
            bulletsSpawner.CanStartSpawn = true;
        }
        if(other.gameObject.CompareTag("BulletPlayer"))
        {
            bulletsSpawner.CanStartSpawn = false;
            canDispawn = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // inGameZone = false;
            bulletsSpawner.CanStartSpawn = false;
            canDispawn = true;
        }
    }

    public void DestroyEnemy()
    {
        if (bulletsSpawner.DestroySpawner())
        {
            Destroy(gameObject);
        }
    }
}

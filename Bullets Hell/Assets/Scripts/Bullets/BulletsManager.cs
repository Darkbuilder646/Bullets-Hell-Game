using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float spawnInterval = 2f; //? 2s
    [SerializeField] private float test = 0.5f; //? 2s

    [Space]
    [SerializeField] private bool rotateSpawner = false;
    [SerializeField] private float rotationSpeed = 30f;

    private void Start()
    {
        InvokeRepeating("SpawnBulletsInAllDirections", 0f, spawnInterval);
        InvokeRepeating("RandomRotationSpeed", 0f, test);
    }

    private void Update()
    {
        if(rotateSpawner)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        }
    }

    private void RandomRotationSpeed()
    {
        rotationSpeed = Random.Range(-30, 30);
    }

    private void SpawnBulletsInAllDirections()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, new Vector2(1, 1).normalized, new Vector2(-1, 1).normalized, new Vector2(1, -1).normalized, new Vector2(-1, -1).normalized };

        foreach (Vector2 direction in directions)
        {
            SpawnBullet(direction);
        }
    }

    private void SpawnBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);

        if (bullet.TryGetComponent<Bullet>(out var bulletScript))
        {
            bulletScript.SetDirection(direction);
            bulletScript.SetSpeed(bulletSpeed);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    enum SpawnerType
    {
        Straight,
        Spin
    }

    [Space]
    [Header("Bullets Value")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletLifeTime = 5f;

    [Space]
    [Header("Spawner")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int poolSize = 20;

    private List<Bullet> bulletPool;
    private int poolIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        bulletPool = new List<Bullet>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bulletObject = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        }
        if (timer >= fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        Bullet bullet = GetPooledBullet();
        if (bullet && !bullet.gameObject.activeSelf)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bullet.Speed = bulletSpeed;
            bullet.Lifetime = bulletLifeTime;
        }
    }

    private Bullet GetPooledBullet()
    {
        Bullet bullet = bulletPool[poolIndex];
        poolIndex = (poolIndex + 1) % poolSize;
        return bullet;
    }

}

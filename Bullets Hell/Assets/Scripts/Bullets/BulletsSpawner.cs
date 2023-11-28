using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    enum SpawnerType
    {
        Straight,
        Spiral,
        DoubleSpiral
    }

    [Space]
    [Header("Bullets Value")]
    [SerializeField] private GameObject bulletPrefab;

    [Space]
    [Header("Spawner")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float doubleSpiralOffset = 180f;
    [SerializeField] private bool reverseRotation = false;
    [Space]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int poolSize = 20;

    private List<Bullet> bulletPool;
    private int poolIndex = 0;
    private float timer = 0f;
    private bool canStartSpawn = false;
    private EnemyController enemyController;

    public bool CanStartSpawn { get => canStartSpawn; set => canStartSpawn = value; }

    private void Start()
    {
        InitializePool();
        enemyController = GetComponentInParent<EnemyController>();
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
        if(canStartSpawn && enemyController.InGameZone)
        {
            StartingSpawning();
        }
    }

    private void StartingSpawning()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spiral || spawnerType == SpawnerType.DoubleSpiral)
        {
            float rotationAmount = reverseRotation ? -1f : 1f;

            if (spawnerType == SpawnerType.DoubleSpiral && timer >= fireRate)
            {
                Fire(rotationAmount * doubleSpiralOffset);
            }

            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + rotationAmount);
        }
        if (timer >= fireRate)
        {
            Fire(0f); //? Base angle
            timer = 0f;
        }
    }

    private void Fire(float angleOffset)
    {
        Bullet bullet = GetPooledBullet();
        if (bullet.gameObject.activeSelf)
        {
            bullet.KillBullet();
        }
        if (bullet && !bullet.gameObject.activeSelf)
        {
            bullet.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z + angleOffset));
            bullet.gameObject.SetActive(true);
        }
    }

    private Bullet GetPooledBullet()
    {
        Bullet bullet = bulletPool[poolIndex];
        poolIndex = (poolIndex + 1) % poolSize;
        return bullet;
    }

    public bool AllBulletsInactive()
    {
        foreach (Bullet bullet in bulletPool)
        {
            if(bullet.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
        
    }

    public bool DestroySpawner()
    {
        foreach (Bullet bullet in bulletPool)
        {
            Destroy(bullet.gameObject);
        }
        return true;
    }
}

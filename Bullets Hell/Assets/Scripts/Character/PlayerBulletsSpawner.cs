using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private int poolSize = 20;
    private float timer = 0f;
    private List<Bullet> bulletPool;
    private int poolIndex = 0;

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

    public void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        Bullet bullet = GetPooledBullet();
        if (bullet.gameObject.activeSelf)
        {
            bullet.KillBullet();
        }
        if (bullet && !bullet.gameObject.activeSelf)
        {
            bullet.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z));
            bullet.gameObject.SetActive(true);
        }
    }

    private Bullet GetPooledBullet()
    {
        Bullet bullet = bulletPool[poolIndex];
        poolIndex = (poolIndex + 1) % poolSize;
        return bullet;
    }
}

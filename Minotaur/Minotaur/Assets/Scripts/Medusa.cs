using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;
    public float cooldownDuration = 15f; 

    private bool canShoot = true; 
    private float cooldownTimer = 0f;

    void Update()
    {
        
        if (!canShoot)
        {
            cooldownTimer += Time.deltaTime;
            
            if (cooldownTimer >= cooldownDuration)
            {
                canShoot = true;
                cooldownTimer = 0f; 
            }
        }

        
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        canShoot = false;
    }
}

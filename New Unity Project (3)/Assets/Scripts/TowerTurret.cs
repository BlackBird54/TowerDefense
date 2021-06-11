using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTurret : MonoBehaviour
{
    public enum TurretType { 
        Assault,
        Grenadier,
        CrowdControl,
        Flames,
        DmgOverTime
    };

    public float fireRate;
    public float bulletForce;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform target;

    private bool canFire;
    private float fireTimer;

    private void Start()
    {
        fireTimer = fireRate;
        canFire = true;
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (!canFire)
        {
            if (fireTimer >= fireRate)
            {
                canFire = true;
            }
            fireTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (target.gameObject.CompareTag("Enemy") && canFire)
        {
            Fire();
            canFire = false;
            fireTimer = 0;
        }
    }

    void Fire() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}

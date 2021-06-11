using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunType
    {
        Pistol,
        Rifle,
        Shotgun,
    };

    public Transform firePoint;
    public float fireSpeed;
    public float reloadSpeed;
    public float recoil;
    public int maxAmmo;
    public GameObject bulletPrefab;
    public float bulletForce;
    public GunType gunType;

    private float fireTimer;
    public bool canFire;
    private float reloadTimer;
    public bool reloading;
    public int ammoCount;

    public Rigidbody2D player;
    public bool isActive;

    private void Start()
    {
        fireTimer = fireSpeed;
        reloadTimer = 0f;
        reloading = false;
        //player = gameObject.transform.parent.GetComponent<Rigidbody2D>();
        //isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            if (reloading)
            {
                if (reloadTimer >= reloadSpeed)
                {
                    ammoCount = maxAmmo;
                    reloadTimer = 0f;
                    reloading = false;
                    canFire = true;
                }
                reloadTimer += Time.deltaTime;
            }
            else if (!canFire) 
            {
                if (fireTimer >= fireSpeed)
                {
                    canFire = true;
                }
                fireTimer += Time.deltaTime;
            }

            if (ammoCount == 0)
            {
                reloading = true;
            }

        }
        
    }

    private void FixedUpdate()
    {
        if (isActive) { 
            if (Input.GetMouseButton(0) && canFire && !reloading) {
                Shoot();
                player.AddForce(-firePoint.up * recoil, ForceMode2D.Force);
                fireTimer = 0f;
                canFire = false;
            }
            
        }

    }

    public void Shoot() {
        if (gunType == GunType.Pistol)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (gunType == GunType.Rifle) 
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (gunType == GunType.Shotgun)
        {

            //GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //bullet1.transform.Rotate(0, 0, -5);
            //bullet1.GetComponent<Rigidbody2D>().AddForce(bullet1.transform.up * bulletForce, ForceMode2D.Impulse);

            //GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //bullet2.transform.Rotate(0, 0, -10);
            //bullet2.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            //GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //bullet3.transform.Rotate(0, 0, 5);
            //bullet3.GetComponent<Rigidbody2D>().AddForce(bullet3.transform.up * bulletForce, ForceMode2D.Impulse);
            int numBullets = 10;
            GameObject bullet;
            for (int i = 0; i < numBullets; i++) {
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.transform.Rotate(0, 0, Random.Range(-10, 10));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletForce * Random.Range(0.7f, 1f), ForceMode2D.Impulse);
            }
        }
        ammoCount--;
    }
}

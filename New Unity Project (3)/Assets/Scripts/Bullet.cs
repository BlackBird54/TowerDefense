using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Collider coli;
    public float bulletDmg;
    public float lifetime = 4f;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D col = collision;
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bullet") && !col.gameObject.CompareTag("Tower")) {
            Destroy(gameObject);
        }
    }
}

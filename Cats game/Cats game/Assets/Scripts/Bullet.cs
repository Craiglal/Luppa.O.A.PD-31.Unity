using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 80f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Spawner spawner = collision.GetComponent<Spawner>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        if( spawner == null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}

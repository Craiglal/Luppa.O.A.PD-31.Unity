using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public GameObject deathEffect;
    public GameObject item;
    public AIPath aiPath;
    float damageTickTime = 2.0f;
    float damageTickCooldown = 0.0f;
    bool giveDamage = false;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        System.Random random = new System.Random();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if(random.Next(1,3) == 1)
            Instantiate(item, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01)
        {
            transform.localScale = new Vector3(-3.4f, 3.4f, 1);
        }
        else if(aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(3.4f, 3.4f, 1);
        }

        if (giveDamage)
        {
            if (damageTickCooldown == 0.0f)
            {
                damageTickCooldown = damageTickTime;
            }
            else if(damageTickCooldown < 0.0f)
            {
                giveDamage = false;
                damageTickCooldown = 0.0f;
            }
            else
            {
                damageTickCooldown -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSystem player = collision.GetComponent<PlayerSystem>();
        if (player != null && !giveDamage)
        {
            giveDamage = true;
            player.TakeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerSystem player = collision.GetComponent<PlayerSystem>();
        if (player != null && !giveDamage)
        {
            giveDamage = true;
            player.TakeDamage(1);
        }
    }
}

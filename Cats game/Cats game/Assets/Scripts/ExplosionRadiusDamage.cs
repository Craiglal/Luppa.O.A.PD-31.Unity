using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadiusDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        PlayerSystem player = collision.GetComponent<PlayerSystem>();
        if (player != null)
        {
            player.TakeDamage(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    int type;
    int amount = 1;
    void Start()
    {
        System.Random random = new System.Random();
        type = random.Next(1,4);
        if(type == 2)
        {
            amount = random.Next(2, 6);
        }
        else if( type == 3)
        {
            amount = random.Next(1, 4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSystem playerSystem = collision.GetComponent<PlayerSystem>();
        Weapon weapon = collision.GetComponent<Weapon>();
        if (playerSystem != null && weapon != null)
        {
            if (type == 1)
            {
                playerSystem.GetHealth(amount);
                type = 0;
            }
            else if (type == 2)
            {
                weapon.GetBullet(amount);
                type = 0;
            }
            else if (type == 3)
            {
                weapon.GetGrenade(amount);
                type = 0;
            }

            Destroy(gameObject);
        }
    }
}

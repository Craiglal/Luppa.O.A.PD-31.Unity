using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    public Animator animator;
    bool opened = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!opened)
        {
            PlayerSystem playerSystem = collision.GetComponent<PlayerSystem>();
            Weapon weapon = collision.GetComponent<Weapon>();
            if (playerSystem != null && weapon != null)
            {
                opened = true;
                animator.SetBool("open", true);
                System.Random random = new System.Random();
                int amountB = random.Next(1, 11);
                int amouuntG = random.Next(1, 6);
                playerSystem.GetHealth(1);
                weapon.GetBullet(amountB);
                weapon.GetGrenade(amouuntG);
            }
        }
    }
}

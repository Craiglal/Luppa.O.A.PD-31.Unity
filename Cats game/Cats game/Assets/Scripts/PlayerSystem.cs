using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    public int health = 2;
    public int level = 1;
    public Animator animator;
    public GameObject deadMenu;
    public GameObject healthUI;

    private void Start()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
            if (playerData.level == int.Parse(SceneManager.GetActiveScene().name.Replace("LEVEL", "")))
            {
                level = playerData.level;
                health = playerData.health;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetBool("isHurt", true);
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
        StartCoroutine(DelayedAnimation());
    }

    public void GetHealth(int _health)
    {
        health += _health;
    }

    public void Die()
    {
        deadMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        healthUI.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(.05f);
        animator.SetBool("isHurt", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointCrouch;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;
    public Animator animator;
    public int bullets = 10;
    public int grenages = 3;
    float damageTickTimeBullet = 1.0f;
    float damageTickCooldownBullet = 0.0f;
    bool giveDamageBullet = false;
    float damageTickTimeGrenage = 2.0f;
    float damageTickCooldownGrenage = 0.0f;
    bool giveDamageGrenage = false;

    public GameObject grenadeUI;
    public GameObject bulletUI;
    // Update is called once per frame

    private void Start()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
            if (playerData.level == int.Parse(SceneManager.GetActiveScene().name.Replace("LEVEL", "")))
            {
                grenages = playerData.grenades;
                bullets = playerData.bullets;
            }
        }
    }
    void Update()
    {
        if(Time.timeScale != 1){
            if (animator.GetBool("isCrouching") && Input.GetButtonDown("Fire1"))
            {
                CrouchShoot();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }

            if (animator.GetBool("isCrouching") && Input.GetButtonDown("Fire2"))
            {
                CrouchGrenade();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Grenade();
            }

            if (giveDamageBullet)
            {
                if (damageTickCooldownBullet == 0.0f)
                {
                    damageTickCooldownBullet = damageTickTimeBullet;
                }
                else if (damageTickCooldownBullet < 0.0f)
                {
                    giveDamageBullet = false;
                    damageTickCooldownBullet = 0.0f;
                }
                else
                {
                    damageTickCooldownBullet -= Time.deltaTime;
                }
            }

            if (giveDamageGrenage)
            {
                if (damageTickCooldownGrenage == 0.0f)
                {
                    damageTickCooldownGrenage = damageTickTimeGrenage;
                }
                else if (damageTickCooldownGrenage < 0.0f)
                {
                    giveDamageGrenage = false;
                    damageTickCooldownGrenage = 0.0f;
                }
                else
                {
                    damageTickCooldownGrenage -= Time.deltaTime;
                }
            }

            grenadeUI.GetComponent<TextMeshProUGUI>().text = grenages.ToString();
            bulletUI.GetComponent<TextMeshProUGUI>().text = bullets.ToString();
        }
    }

    void Shoot()
    {
        if (!giveDamageBullet && bullets > 0)
        {
            bullets--;
            animator.SetBool("isShooting", true);
            giveDamageBullet = true;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(DelayedAnimation());
        }
    }

    void CrouchShoot()
    {
        if (!giveDamageBullet && bullets > 0)
        {
            bullets--;
            animator.SetBool("isShooting", true);
            giveDamageBullet = true;
            Instantiate(bulletPrefab, firePointCrouch.position, firePointCrouch.rotation);
            StartCoroutine(DelayedAnimation());
        }
    }

    void Grenade()
    {
        if (!giveDamageGrenage && grenages > 0)
        {
            grenages--;
            animator.SetBool("isShooting", true);
            giveDamageGrenage = true;
            Instantiate(grenadePrefab, firePoint.position, Quaternion.Euler(new Vector3(firePoint.rotation.x, firePoint.rotation.y, firePoint.rotation.y >= 0 ? firePoint.rotation.z + 45 : firePoint.rotation.z - 225)));
            StartCoroutine(DelayedAnimation());
        }
    }

    void CrouchGrenade()
    {
        if (!giveDamageGrenage && grenages > 0)
        {
            grenages--;
            animator.SetBool("isShooting", true);
            giveDamageGrenage = true;
            Instantiate(grenadePrefab, firePointCrouch.position, Quaternion.Euler(new Vector3(firePointCrouch.rotation.x, firePointCrouch.rotation.y, firePointCrouch.rotation.y >= 0 ? firePointCrouch.rotation.z + 45 : firePointCrouch.rotation.z - 225)));
            StartCoroutine(DelayedAnimation());
        }
    }

    IEnumerator DelayedAnimation()
    {
        yield return new WaitForSeconds(.4f);
        animator.SetBool("isShooting", false);
    }

    public void GetBullet(int amount)
    {
        bullets += amount;
    }
    public void GetGrenade(int amount)
    {
        grenages += amount;
    }
}

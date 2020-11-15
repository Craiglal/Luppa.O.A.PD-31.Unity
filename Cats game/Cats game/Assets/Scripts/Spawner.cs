using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    bool trigerred = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enem = collision.GetComponent<Enemy>();
        if (collision.GetComponent<PlayerSystem>() != null && !trigerred)
        {
            trigerred = true;
            InvokeRepeating("Spawn", 0f, 30f);
        }
    }

    void Spawn()
    {
        Instantiate(enemy, new Vector3(transform.position.x + 1.2f, transform.position.y - 1.2f, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerSystem>() != null)
        {
            trigerred = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerSystem>() != null)
        {
            trigerred = false;
            CancelInvoke("Spawn");
        }
    }
}

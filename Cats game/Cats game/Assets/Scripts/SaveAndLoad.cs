using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSystem player = collision.GetComponent<PlayerSystem>();
        Weapon weapon = collision.GetComponent<Weapon>();
        if(player != null && weapon != null)
        {
            player.level = int.Parse(SceneManager.GetActiveScene().name.Replace("LEVEL", ""))+1;
            SaveSystem.SavePlayer(player, weapon);
            if(player.level <= 3)
            {
                SceneManager.LoadScene("LEVEL" + player.level);
            }
            else
            {
                SceneManager.LoadScene("MENU");
            }
        }
    }
}

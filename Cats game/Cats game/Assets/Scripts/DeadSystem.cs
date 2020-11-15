using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSystem : MonoBehaviour
{
    public GameObject deadMenu;
    public GameObject player;

    public void MainMenu()
    {
        SceneManager.LoadScene("MENU");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<PlayerSystem>().health <= 0)
        {
            SceneManager.LoadScene("MENU");
        }
    }
}

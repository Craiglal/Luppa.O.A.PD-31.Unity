using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehavior : MonoBehaviour
{
    public static bool gameIsPause = false;

    public GameObject pauseMenu;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
    }
}

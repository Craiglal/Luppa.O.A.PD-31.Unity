using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    private void Start()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        if(playerData != null)
        {
            if (playerData.level == 2)
            {
                level2.interactable = true;
            }
            else if (playerData.level == 3)
            {
                level2.interactable = true;
                level3.interactable = true;
            }
        }
    }

    public void LoadLevel(string level)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

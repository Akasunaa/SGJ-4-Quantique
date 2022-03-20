using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] public GameObject cardMenu;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        print("mais");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        cardMenu.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Acquis()
    {
        pauseMenuUI.SetActive(false);
        cardMenu.SetActive(true);

    }

}

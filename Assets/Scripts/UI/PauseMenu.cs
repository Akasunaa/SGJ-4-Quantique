using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] public GameObject cardMenu;
    private ManagerUI _myUIManager;

    private bool _isCard = false;
    private LevelManager _levelManager;

    private void Awake()
    {
        _myUIManager = cardMenu.GetComponent<ManagerUI>();
        cardMenu.SetActive(false);
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (GameIsPaused && !_isCard)
            {
                Resume();
            }
            else if (GameIsPaused && _isCard && !_myUIManager.BigCardOpen)
            {
                _isCard = false;
                pauseMenuUI.SetActive(true);
                cardMenu.SetActive(false);

            }
            else if (GameIsPaused && _isCard && _myUIManager.BigCardOpen)
            {
                _myUIManager.CloseAll();
            }
            else if (!GameIsPaused)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        cardMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _levelManager.ResumeMusic();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        _levelManager.PauseMusic();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Acquis()
    {
        _isCard = true;
        pauseMenuUI.SetActive(false);
        cardMenu.SetActive(true);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public audio_manager AudioManager;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                resume();
            else
                pause();
        }
        else if(Input.GetKeyDown(KeyCode.Return) && GameIsPaused)
            resume();
        
    }
    public void resume()
    {
        AudioManager.unpauseTheme();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause()
    {
        AudioManager.pauseTheme();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void mainMenuExit()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("main_menu");

    }

    public void clickSound()
    {
        AudioManager.playClickSound();
    }

    public void gameExit()
    {
        Application.Quit();
    }
}

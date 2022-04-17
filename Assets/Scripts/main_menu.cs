using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject SelectMenuUI;
    public audio_manager AudioManager;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("This is C#");
    }
    // Update is called once per frame
    void Update()
    {

        
    }
    public void activateLevelSelect()
    {
        MainMenuUI.SetActive(false);
        SelectMenuUI.SetActive(true);
    }

    public void loadLevel(int levelNum)
    {
        SceneManager.LoadScene("level" + levelNum);
    }

    public void backToMainMenu()
    {
        SelectMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
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

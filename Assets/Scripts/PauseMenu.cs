using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gamePaused == true)
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
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gamePaused = false;
        GameObject.Find("GlobalObject").SendMessage("StopTimer");
        GameObject.Find("GlobalObject").SendMessage("HideMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StopCountPortals");
    }
}

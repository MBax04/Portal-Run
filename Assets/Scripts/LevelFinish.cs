using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameObject.Find("GlobalObject").SendMessage("StopTimer");
        GameObject.Find("GlobalObject").SendMessage("StopCountPortals");
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StopTimer");
        GameObject.Find("GlobalObject").SendMessage("StopCountPortals");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = true;
    public Image mouseHelp;

    private float t;
    private float minutes;
    private float seconds;

    public static Timer Instance;

    private bool doTimer = false;
    private bool doPortal = false;

    public Text portalText;
    private int portalCounter;

    // Update is called once per frame
    void Update()
    {
        if (doTimer == true && finished == false)
        {
            t = Time.time - startTime;

            minutes = Mathf.FloorToInt(t / 60);
            seconds = (t % 60);

            timerText.text = string.Format("{0:00}:{1:00.000}", minutes, seconds);
        }
        if (doPortal == true && finished == false)
        {
            if (Input.GetMouseButtonDown(0) && PauseMenu.gamePaused == false)
            {
                portalCounter++;
            }
            if (Input.GetMouseButtonDown(1) && PauseMenu.gamePaused == false && SceneManager.GetActiveScene().buildIndex > 6)
            {
                portalCounter++;
            }

            portalText.text = portalCounter.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 25 && (doTimer == true || doPortal == true))
        {
            finished = true;
            timerText.color = Color.red;
            portalText.color = Color.red;
            GameObject.Find("GlobalObject").SendMessage("HideMouseHelp");
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        finished = false;
        timerText.color = Color.white;
        timerText.enabled = true;
        doTimer = true;
    }
    public void StopTimer()
    {
        timerText.enabled = false;
        finished = true;
        doTimer = false;
    }

    

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowMouseHelp()
    {
        mouseHelp.enabled = true;
    }
    public void HideMouseHelp()
    {
        mouseHelp.enabled = false;
    }

    public void StartCountPortals()
    {
        finished = false;
        portalText.color = Color.white;
        portalText.enabled = true;
        doPortal = true;
        portalCounter = 0;
    }    
    public void StopCountPortals()
    {
        portalText.enabled = false;
        finished = true;
        doPortal = false;
    }

    public void RestartTimer()
    {
        startTime = Time.time;
    }
}

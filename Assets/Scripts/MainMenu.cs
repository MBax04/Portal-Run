using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool speedRunByLevel = false;

    public void playGame ()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level1 ()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level6()
    {
        SceneManager.LoadScene(6);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level7()
    {
        SceneManager.LoadScene(7);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level8()
    {
        SceneManager.LoadScene(8);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level9()
    {
        SceneManager.LoadScene(9);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level10()
    {
        SceneManager.LoadScene(10);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level11()
    {
        SceneManager.LoadScene(11);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level12()
    {
        SceneManager.LoadScene(12);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level13()
    {
        SceneManager.LoadScene(13);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level14()
    {
        SceneManager.LoadScene(14);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level15()
    {
        SceneManager.LoadScene(15);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level16()
    {
        SceneManager.LoadScene(16);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }

    public void Level17()
    {
        SceneManager.LoadScene(17);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level18()
    {
        SceneManager.LoadScene(18);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level19()
    {
        SceneManager.LoadScene(19);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level20()
    {
        SceneManager.LoadScene(20);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level21()
    {
        SceneManager.LoadScene(21);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level22()
    {
        SceneManager.LoadScene(22);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level23()
    {
        SceneManager.LoadScene(23);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void Level24()
    {
        SceneManager.LoadScene(24);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }

    public void playSpeedrun()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
    }
    public void playLeastPortals()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartCountPortals");
    }

    public void SLevel1()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel2()
    {
        SceneManager.LoadScene(2);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel3()
    {
        SceneManager.LoadScene(3);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel4()
    {
        SceneManager.LoadScene(4);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel5()
    {
        SceneManager.LoadScene(5);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel6()
    {
        SceneManager.LoadScene(6);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel7()
    {
        SceneManager.LoadScene(7);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel8()
    {
        SceneManager.LoadScene(8);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel9()
    {
        SceneManager.LoadScene(9);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel10()
    {
        SceneManager.LoadScene(10);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel11()
    {
        SceneManager.LoadScene(11);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel12()
    {
        SceneManager.LoadScene(12);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel13()
    {
        SceneManager.LoadScene(13);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel14()
    {
        SceneManager.LoadScene(14);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel15()
    {
        SceneManager.LoadScene(15);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel16()
    {
        SceneManager.LoadScene(16);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }

    public void SLevel17()
    {
        SceneManager.LoadScene(17);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel18()
    {
        SceneManager.LoadScene(18);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel19()
    {
        SceneManager.LoadScene(19);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel20()
    {
        SceneManager.LoadScene(20);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel21()
    {
        SceneManager.LoadScene(21);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel22()
    {
        SceneManager.LoadScene(22);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel23()
    {
        SceneManager.LoadScene(23);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
    public void SLevel24()
    {
        SceneManager.LoadScene(24);
        GameObject.Find("GlobalObject").SendMessage("ShowMouseHelp");
        GameObject.Find("GlobalObject").SendMessage("StartTimer");
        speedRunByLevel = true;
    }
}

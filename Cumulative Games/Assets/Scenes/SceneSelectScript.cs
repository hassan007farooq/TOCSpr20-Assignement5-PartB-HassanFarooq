using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour
{
    public void GotoPenguin()
    {
        SceneManager.LoadScene("Penguins");
    }
    public void GotoHummingbird()
    {
        SceneManager.LoadScene("FlowerIsland");
    }
    public void GotoMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void GotoRollABallGame()
    {
        SceneManager.LoadScene("RollABall");
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Game_Menu"); ;
    }
    public void VistWebsite()
    {
        Application.OpenURL("http://www.niazilab.com/");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

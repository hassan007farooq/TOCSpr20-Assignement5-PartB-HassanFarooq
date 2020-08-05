using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PenguineGame()
    {
        SceneManager.LoadScene("Penguins");
    }

    public void HummingBirdGame()
    {
        SceneManager.LoadScene("FlowerIsland");
    }

    //public void MiniGame()
    //{
    //    SceneManager.LoadScene("MiniGame");
    //}
    
    //public void RollABallGame()
    //{
    //    SceneManager.LoadScene("RollABall");
    //}

    public void BackToMenu()
    {
        SceneManager.LoadScene("Game_Menu");
    }
}

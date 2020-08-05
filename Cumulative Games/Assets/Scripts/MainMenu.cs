using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name)
        {
            case "Penguins-Tahreem Zahoor":
                SceneManager.LoadScene("Penguins");
                break;
            case "Humming Birds- FA19-RCS-076":
                SceneManager.LoadScene("FlowerIsland");
                break;

        }
    }
}

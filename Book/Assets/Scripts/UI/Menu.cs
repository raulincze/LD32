using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

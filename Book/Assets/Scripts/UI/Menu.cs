using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
    public void RestartLevel()
    {
        GameManager.Instance.ResumeGame();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void RestartGame()
    {
        GameManager.Instance.ResumeGame();
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        GameManager.Instance.ResumeGame();
        Application.Quit();
    }
}

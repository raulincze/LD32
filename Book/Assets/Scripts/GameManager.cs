using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

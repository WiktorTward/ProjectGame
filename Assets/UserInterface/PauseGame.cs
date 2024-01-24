using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; 
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;

    void Update()
    {
        //Pause with P
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }
    /// <summary>
    /// This function Pauses the game or resume it if the game was already Paused, Activates the pause panel or desactivates it
    /// </summary>
    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);

        
        Time.timeScale = isPaused ? 0f : 1f;
    }
}

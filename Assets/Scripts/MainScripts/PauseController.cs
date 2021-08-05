using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameIsPaused;
    public static PauseController current;

    void Awake()
    {
        current = this;
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
}

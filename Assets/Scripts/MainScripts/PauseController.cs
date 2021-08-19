using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameIsPaused;
    public static PauseController current;

    private GameObject startGameButton;
    void Awake()
    {
        current = this;
    }

	private void Start()
	{
        startGameButton = GameObject.FindGameObjectWithTag("StartButton");
	}

	private void Update()
	{
        if (gameIsPaused)
        {
            if (Input.GetMouseButtonDown(2))
            {
                ResumeGame();
            }
        }
	}

	public void PauseGame()
    {
        gameIsPaused = true;
        AudioListener.pause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (startGameButton != null) startGameButton.SetActive(false);
        gameIsPaused = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    public void StartGame()
    {
        MicrogameManager.current.LoadNextMicrogame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

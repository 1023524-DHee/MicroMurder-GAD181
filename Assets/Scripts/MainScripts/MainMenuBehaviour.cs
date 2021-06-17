using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    public void StartGame()
    {
        MicrogameManager.current.StartMicrogames();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
	private void Awake()
	{
        GameObject[] objs = GameObject.FindGameObjectsWithTag("FromLevelSelect");
        for (int ii = 0; ii < objs.Length; ii++)
        {
            Destroy(objs[ii].gameObject);
        }
	}

	public void StartGame()
    {
        MicrogameManager.current.LoadNextMicrogame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

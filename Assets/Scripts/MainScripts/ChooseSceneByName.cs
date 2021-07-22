using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseSceneByName : MonoBehaviour
{
    public GameObject LevelSelectInfo;

	public void LoadChosenScene(string sceneName)
    {
        Instantiate(LevelSelectInfo);
        SceneManager.LoadScene(sceneName);
    }
}

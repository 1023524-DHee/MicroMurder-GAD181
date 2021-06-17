using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMicrogameClass : MonoBehaviour
{
    [SerializeField]
    private string currentSceneName;

    [SerializeField]
    private string[] nextScenesAvailable;

    public void NextMicrogame()
    {
        MicrogameManager.RandomizeMicrogame(this);
    }

    public string GetNextAvailableRandomScene()
    {
        return nextScenesAvailable[Random.Range(0, nextScenesAvailable.Length)];
    }

    public string[] GetNextAvailableScenes()
    {
        return nextScenesAvailable;
    }

    public string GetCurrentSceneName()
    {
        return currentSceneName;
    }
}

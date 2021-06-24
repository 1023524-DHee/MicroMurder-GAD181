using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager current;

    public Animator transition;
    public float transitionTime;
    public string transitionTriggerName;

	private void Awake()
	{
        current = this;
	}

	public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.gameObject.GetComponent<Image>().raycastTarget = true;
        transition.SetTrigger("StartDimming");
        transition.SetTrigger(transitionTriggerName);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
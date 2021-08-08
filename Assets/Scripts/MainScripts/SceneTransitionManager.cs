using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager current;

    public Animator transitionAnimator;
    public float transitionTime;
    public string transitionTriggerName;

	private void Awake()
	{
        current = this;
	}

    // Called in animation component
    public void PauseAfterSceneChange()
    {
        if (MicrogameManager.current.currentState != MicrogameState.START &&
            MicrogameManager.current.currentState != MicrogameState.END)
        {
            PauseController.current.PauseGame();
        }
        
    }

    public void ReloadCurrentScene()
    {
        StartCoroutine(ReloadScene());
    }

	public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transitionAnimator.gameObject.GetComponent<Image>().raycastTarget = true;
        transitionAnimator.SetTrigger("StartDimming");
        transitionAnimator.SetTrigger(transitionTriggerName);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator ReloadScene()
    {
        transitionAnimator.gameObject.GetComponent<Image>().raycastTarget = true;
        transitionAnimator.SetTrigger("StartDimming");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

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
    public bool pauseGame = true;

	private void Awake()
	{
        current = this;
	}

    // Called in animation component
    public void PauseAfterSceneChange()
    {
        if (pauseGame)
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
        if(MicrogameManager.current.currentState != MicrogameState.START) transitionAnimator.SetTrigger("StartDimming");

        switch (MicrogameManager.current.currentState)
        {
            case MicrogameState.START:
                transitionAnimator.SetTrigger("StartMainTransition");
                break;
            case MicrogameState.DISCLAIMER:
                transitionAnimator.SetTrigger("PreMurder_Transition");
                break;
            case MicrogameState.PREMURDER:
                transitionAnimator.SetTrigger("Murder_Transition");
                break;
            case MicrogameState.MURDER:
                transitionAnimator.SetTrigger("CleanUp_Transition");
                break;
            case MicrogameState.CLEANUP:
                transitionAnimator.SetTrigger("Chase_Transition");
                break;
            case MicrogameState.CHASE:
                transitionAnimator.SetTrigger("Caught_Transition");
                break;
            case MicrogameState.CAUGHT:
                transitionAnimator.SetTrigger("Jail_Transition");
                break;
            case MicrogameState.JAIL:
                transitionAnimator.SetTrigger("End_Transition");
                break;
        }
        yield return new WaitForSeconds(transitionTime);
        AudioListener.pause = true;
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

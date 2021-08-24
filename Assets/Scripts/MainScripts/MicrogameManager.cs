using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MicrogameState
{
	START,
	DISCLAIMER,
	PREMURDER,
	MURDER,
	CLEANUP,
	CHASE,
	CAUGHT,
	JAIL,
	END
}

public class MicrogameManager : MonoBehaviour
{
	[SerializeField]
	private string[] premurderMicrogames, murderMicrogames, cleanupMicrogames, chaseMicrogames, caughtMicrogames, jailMicrogames;

	[SerializeField]
	private string mainMenuSceneName, startingMicrogame, endSceneName;

	public GameObject escapePanel;
	public static MicrogameManager current;
	public MicrogameState currentState;

	private void Awake()
	{
		current = this;
		AudioListener.pause = false;
		Cursor.visible = true;
	}

	public void LoadNextMicrogame()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("FromLevelSelect");
		if (objs.Length > 0)
		{
			SceneTransitionManager.current.LoadNextLevel(mainMenuSceneName);
			return;
		}

		string nextMicrogame = "";
		switch (currentState)
		{
			// Starts Disclaimer Microgame
			case MicrogameState.START:
				nextMicrogame = startingMicrogame;
				break;
			// Starts Pre-Murder Microgames
			case MicrogameState.DISCLAIMER:
				nextMicrogame = RandomiseMicrogame(premurderMicrogames);
				break;
			// Starts Murder Microgames
			case MicrogameState.PREMURDER:
				nextMicrogame = RandomiseMicrogame(murderMicrogames);
				break;
			// Starts Clean Up Microgames
			case MicrogameState.MURDER:
				nextMicrogame = cleanupMicrogames[0];
				break;
			// Starts Chase Microgames
			case MicrogameState.CLEANUP:
				if (SceneManager.GetActiveScene().name == cleanupMicrogames[0])
				{
					nextMicrogame = cleanupMicrogames[1];
				}
				else
				{
					nextMicrogame = RandomiseMicrogame(chaseMicrogames);
				}
				break;
			// Starts Caught Microgames
			case MicrogameState.CHASE:
				nextMicrogame = RandomiseMicrogame(caughtMicrogames);
				break;
			// Starts Jail Microgames
			case MicrogameState.CAUGHT:
				nextMicrogame = RandomiseMicrogame(jailMicrogames);
				break;
			// Starts End Microgames
			case MicrogameState.JAIL:
				nextMicrogame = endSceneName;
				break;
			// Goes back to Main Menu screen
			case MicrogameState.END:
				nextMicrogame = mainMenuSceneName;
				break;
		}
		SceneTransitionManager.current.LoadNextLevel(nextMicrogame);
	}

	// Chooses a random scene from a list of scenes
	private string RandomiseMicrogame(string[] microgameScenes)
	{
		return microgameScenes[Random.Range(0,microgameScenes.Length)];
	}
}

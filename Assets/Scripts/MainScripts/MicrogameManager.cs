using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MicrogameState
{
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
	private string[] premurderMicrogames, meleeMurderMicrogames, gunMurderMicrogames, cleanupMicrogames, chaseMicrogames, caughtMicrogames, jailMicrogames;

	[SerializeField]
	private string startingMicrogame;
	private static string currentMicrogameName;

	public static MicrogameManager current;

	private bool FirstMicrogame = true;
	private MicrogameState currentState;

	private void Awake()
	{
		current = this;
	}

	public void StartMicrogames()
	{
		if (startingMicrogame != null && FirstMicrogame)
		{
			FirstMicrogame = false;
			currentState = MicrogameState.DISCLAIMER;
			currentMicrogameName = startingMicrogame;
			SceneManager.LoadScene(currentMicrogameName);
		}
	}

	public void LoadNextMicrogame()
	{
		string nextMicrogame = "";
		switch (currentState)
		{
			case MicrogameState.DISCLAIMER:
				currentState = MicrogameState.PREMURDER;
				nextMicrogame = RandomiseMicrogame(premurderMicrogames);
				break;
			case MicrogameState.PREMURDER:
				currentState = MicrogameState.MURDER;
				nextMicrogame = RandomiseMicrogame(gunMurderMicrogames);
				break;
			case MicrogameState.MURDER:
				currentState = MicrogameState.CLEANUP;
				nextMicrogame = RandomiseMicrogame(cleanupMicrogames);
				break;
			case MicrogameState.CLEANUP:
				currentState = MicrogameState.CHASE;
				nextMicrogame = RandomiseMicrogame(chaseMicrogames);
				break;
			case MicrogameState.CHASE:
				currentState = MicrogameState.CAUGHT;
				nextMicrogame = RandomiseMicrogame(caughtMicrogames);
				break;
			case MicrogameState.CAUGHT:
				currentState = MicrogameState.JAIL;
				nextMicrogame = RandomiseMicrogame(jailMicrogames);
				break;
			case MicrogameState.JAIL:
				currentState = MicrogameState.END;
				break;
		}
		SceneManager.LoadScene(nextMicrogame);
	}

	private string RandomiseMicrogame(string[] microgameScenes)
	{
		return microgameScenes[Random.Range(0,microgameScenes.Length)];
	}

	//public MicrogameState GetCurrentMicrogameState()
	//{
	//	return currentState;
	//}

	//public void SetCurrentMicrogameState(MicrogameState state_param)
	//{
	//	currentState = state_param;
	//}
}

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

	[SerializeField]
	private List<string> triggerGunMicrogames = new List<string>();

	//private static string currentMicrogameName;

	public static MicrogameManager current;

	private bool FirstMicrogame = true;
	private bool gunMicrogame;
	private MicrogameState currentState;

	private void Awake()
	{
		current = this;
	}

	public void StartMicrogames()
	{
		// If Microgame loop hasn't started yet
		if (startingMicrogame != null && FirstMicrogame)
		{
			SceneTransitionManager.current.LoadNextLevel(startingMicrogame);
			FirstMicrogame = false;
			currentState = MicrogameState.DISCLAIMER;
			//currentMicrogameName = startingMicrogame;
			
		}
	}

	public void LoadNextMicrogame()
	{
		string nextMicrogame = "";
		switch (currentState)
		{
			// Starts Pre-Murder Microgames
			case MicrogameState.DISCLAIMER:
				currentState = MicrogameState.PREMURDER;
				nextMicrogame = RandomiseMicrogame(premurderMicrogames);
				if (triggerGunMicrogames.Contains(nextMicrogame))
				{
					gunMicrogame = true;
				}
				break;
			// Starts Murder Microgames
			case MicrogameState.PREMURDER:
				currentState = MicrogameState.MURDER;
				switch (gunMicrogame)
				{
					case true:
						nextMicrogame = RandomiseMicrogame(gunMurderMicrogames);
						break;
					case false:
						nextMicrogame = RandomiseMicrogame(meleeMurderMicrogames);
						break;
				}
				break;
			// Starts Clean Up Microgames
			case MicrogameState.MURDER:
				currentState = MicrogameState.CLEANUP;
				nextMicrogame = RandomiseMicrogame(cleanupMicrogames);
				break;
			// Starts Chase Microgames
			case MicrogameState.CLEANUP:
				currentState = MicrogameState.CHASE;
				nextMicrogame = RandomiseMicrogame(chaseMicrogames);
				break;
			// Starts Caught Microgames
			case MicrogameState.CHASE:
				currentState = MicrogameState.CAUGHT;
				nextMicrogame = RandomiseMicrogame(caughtMicrogames);
				break;
			// Starts Jail Microgames
			case MicrogameState.CAUGHT:
				currentState = MicrogameState.JAIL;
				nextMicrogame = RandomiseMicrogame(jailMicrogames);
				break;
			// Starts End Microgames
			case MicrogameState.JAIL:
				currentState = MicrogameState.END;
				break;
		}
		SceneManager.LoadScene(nextMicrogame);
	}

	// Chooses a random scene from a list of scenes
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private string startingMicrogame;

	public static MicrogameManager current;
	public MicrogameState currentState;

	private void Awake()
	{
		current = this;
	}

	//public void StartMicrogames()
	//{
	//	// If Microgame loop hasn't started yet
	//	if (startingMicrogame != null && FirstMicrogame)
	//	{
	//		SceneTransitionManager.current.LoadNextLevel(startingMicrogame);
	//		FirstMicrogame = false;
	//		currentState = MicrogameState.DISCLAIMER;
	//	}
	//}

	public void LoadNextMicrogame()
	{
		string nextMicrogame = "";
		switch (currentState)
		{
			// Starts Disclaimer Microgame
			case MicrogameState.START:
				currentState = MicrogameState.DISCLAIMER;
				nextMicrogame = startingMicrogame;
				break;
			// Starts Pre-Murder Microgames
			case MicrogameState.DISCLAIMER:
				currentState = MicrogameState.PREMURDER;
				nextMicrogame = RandomiseMicrogame(premurderMicrogames);
				break;
			// Starts Murder Microgames
			case MicrogameState.PREMURDER:
				currentState = MicrogameState.MURDER;
				nextMicrogame = RandomiseMicrogame(murderMicrogames);
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
		SceneTransitionManager.current.LoadNextLevel(nextMicrogame);
	}

	// Chooses a random scene from a list of scenes
	private string RandomiseMicrogame(string[] microgameScenes)
	{
		return microgameScenes[Random.Range(0,microgameScenes.Length)];
	}
}

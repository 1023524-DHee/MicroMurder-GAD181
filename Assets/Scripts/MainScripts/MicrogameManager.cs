using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameManager : MonoBehaviour
{
	public static MicrogameManager current;

	[SerializeField]
	private BaseMicrogameClass[] startMicrogamesArray;
	private static string currentMicrogameName;

	private bool FirstMicrogame = true;

	private void Awake()
	{
		current = this;
	}

	public void StartMicrogames()
	{
		if (startMicrogamesArray != null && FirstMicrogame)
		{
			FirstMicrogame = false;
			currentMicrogameName = startMicrogamesArray[Random.Range(0, startMicrogamesArray.Length)].GetCurrentSceneName();
			SceneManager.LoadScene(currentMicrogameName);
		}
	}

	public static void RandomizeMicrogame(BaseMicrogameClass microgameClass)
	{
		currentMicrogameName = microgameClass.GetNextAvailableRandomScene();
		SceneManager.LoadScene(currentMicrogameName);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyingGEM : MonoBehaviour
{
    public static LyingGEM current;

	private void Awake()
	{
		current = this;
	}

	private void Start()
	{
		Invoke("GameStart", 3f);
	}

	public event Action onGameStart;
	public void GameStart()
	{
		if (onGameStart != null) onGameStart();
	}

	public event Action<bool> onHealthBarUpdate;
	public void HealthBarUpdate(bool takeDamage)
	{
		if (onHealthBarUpdate != null) onHealthBarUpdate(takeDamage);
	}

	public event Action<float> onInterrogatorSlam;
	public void InterrogatorSlam(float BPMValue)
	{
		if (onInterrogatorSlam != null) onInterrogatorSlam(BPMValue);
	}

	public event Action onGameEnd;
	public void GameEnd()
	{
		if (onGameEnd != null)
		{
			onGameEnd();
			StartCoroutine(LoadNextScene());
		}
	}

	private IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds(2.5f);
		MicrogameManager.current.LoadNextMicrogame();
	}
}

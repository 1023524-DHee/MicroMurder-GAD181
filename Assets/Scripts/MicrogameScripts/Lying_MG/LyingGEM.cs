using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyingGEM : MonoBehaviour
{
    public static LyingGEM current;

	private float finalPlayerHealth;

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

	public void SetFinalPlayerHealth(float health)
	{
		finalPlayerHealth = health;
	}

	private IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds(2.5f);
		if (finalPlayerHealth <= 0.3f)
		{
			SceneTransitionManager.current.ReloadCurrentScene();
		}
		else
		{
			MicrogameManager.current.LoadNextMicrogame();
		}
	}
}

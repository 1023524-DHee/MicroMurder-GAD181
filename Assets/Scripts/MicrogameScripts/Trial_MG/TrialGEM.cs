using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialGEM : MonoBehaviour
{
	private float finalPlayerHealth;
	private bool playerWin;

	public static TrialGEM current;

	private void Awake()
	{
		current = this;
		Invoke("GameStart", 3f);
	}

	public event Action onGameStart;
	public void GameStart()
	{
		if (onGameStart != null) onGameStart();
	}

	public event Action onCorrectResponseClicked;
	public void CorrectResponseClicked()
	{
		if (onCorrectResponseClicked != null) onCorrectResponseClicked();
	}

	public event Action onWrongResponseClicked;
	public void WrongResponseClicked()
	{
		if (onWrongResponseClicked != null) onWrongResponseClicked();
	}

	public event Action onHammerSlammed;
	public void HammerSlammed()
	{
		if (onHammerSlammed != null) onHammerSlammed();
	}

	public event Action onGameEnd;
	public void GameEnd()
	{
		if (onGameEnd != null)
		{
			onGameEnd();
			GameEnd_CoroutineStart();
		}
	}

	public void SetPlayerHealth(float health)
	{
		finalPlayerHealth = health;
	}

	public void SetPlayerWin(bool winOrLose)
	{
		playerWin = winOrLose;
	}

	IEnumerator GameEnd_Coroutine()
	{
		yield return new WaitForSeconds(3f);
		if (finalPlayerHealth > 0.3f)
		{
			MicrogameManager.current.LoadNextMicrogame();
		}
		else
		{
			SceneTransitionManager.current.ReloadCurrentScene();
		}
	}

	private void GameEnd_CoroutineStart()
	{
		StartCoroutine(GameEnd_Coroutine());
	}
}

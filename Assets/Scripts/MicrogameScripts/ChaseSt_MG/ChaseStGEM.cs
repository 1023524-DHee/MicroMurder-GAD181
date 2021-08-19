using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStGEM : MonoBehaviour
{
	private bool playerWin;

    public static ChaseStGEM current;

	private void Awake()
	{
        current = this;
		StartCoroutine(Timer());
	}

	public event Action onPlayerShotSuccess;
	public void PlayerShotSuccess()
	{
		if (onPlayerShotSuccess != null) onPlayerShotSuccess();
	}

	public event Action<int> onShootBullet;
	public void ShootBullet(int id)
	{
		if (onShootBullet != null) onShootBullet(id);
	}

	public event Action onDifficultyUp;
	public void DifficultyUp()
	{
		if (onDifficultyUp != null) onDifficultyUp();
	}

	public event Action onGameEnd;
	public void GameEnd()
	{
		if (onGameEnd != null)
		{
			onGameEnd();
			StopAllCoroutines();
			StartCoroutine(GameEnd_Coroutine());
		}
	}

	public void SetPlayerWinState(bool winOrLose)
	{
		playerWin = winOrLose;
	}

	IEnumerator GameEnd_Coroutine()
	{
		yield return new WaitForSeconds(2f);
		if (playerWin) MicrogameManager.current.LoadNextMicrogame();
		else SceneTransitionManager.current.ReloadCurrentScene();
	}

	IEnumerator Timer()
	{
		DifficultyUp();
		yield return new WaitForSeconds(10f);
		StartCoroutine(Timer());
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStGEM : MonoBehaviour
{
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

	IEnumerator Timer()
	{
		DifficultyUp();
		yield return new WaitForSeconds(7.5f);
		StartCoroutine(Timer());
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLockpick_GEM : MonoBehaviour
{
	private int numberOfLocks;

	public static BoxLockpick_GEM current;

	public GameObject vaultObject;
	public List<Sprite> vaultImages;

	private void Awake()
	{
		current = this;
	}

	private void Start()
	{
		numberOfLocks = vaultImages.Count;
	}

	public event Action onCorrectLockPositionEntered;
	public void CorrectLockPositionEntered()
	{
		if (onCorrectLockPositionEntered != null)
		{
			onCorrectLockPositionEntered();
			Unlocked();
		}
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

	IEnumerator GameEnd_Coroutine()
	{
		yield return new WaitForSeconds(2f);
		MicrogameManager.current.LoadNextMicrogame();
	}

	private void GameEnd_CoroutineStart()
	{
		StartCoroutine(GameEnd_Coroutine());
	}

	private void Unlocked()
	{
		vaultObject.GetComponent<SpriteRenderer>().sprite = vaultImages[0];
		vaultImages.RemoveAt(0);
		if (vaultImages.Count <= 0)
		{
			GameEnd();
		}
	}
}

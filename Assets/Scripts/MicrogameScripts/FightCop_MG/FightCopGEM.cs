using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCopGEM : MonoBehaviour
{
	private int punchesDefended;
	[SerializeField]
	private int punchesDefendedThreshold;
	private float currentPunchTimeLimit = 0.8f;

	public bool playerWin = false;
	public static FightCopGEM current;

	// Start is called before the first frame update
	void Awake()
	{
		punchesDefended = 0;
		current = this;
		Invoke("GameStart", 3f);
	}

	public event Action onGameStart;
	public void GameStart()
	{
		if (onGameStart != null) onGameStart();
	}

	public event Action onPlayerTakeDamage;
	public void PlayerTakeDamage()
	{
		if (onPlayerTakeDamage != null) onPlayerTakeDamage();
	}

	public void PunchClickedSuccess()
	{
		punchesDefended++;
		if (punchesDefended >= punchesDefendedThreshold)
		{
			punchesDefended = 0;
			punchesDefendedThreshold = Mathf.Clamp(punchesDefendedThreshold + 2, 0, 9);
			CopVulnerable();
		}
	}

	public event Action onCopResumeCombat;
	public void CopResumeCombat()
	{
		if (onCopResumeCombat != null)
		{
			currentPunchTimeLimit = Mathf.Clamp(currentPunchTimeLimit - 0.25f, 0.3f, 0.8f);
			onCopResumeCombat();
		}
	}

	public event Action onCopVulnerable;
	public void CopVulnerable()
	{
		if (onCopVulnerable != null) onCopVulnerable();
	}

	public event Action onGameEnd;
	public void GameEnd()
	{
		if (onGameEnd != null)
		{
			onGameEnd();
			LoadNextScene_CoroutineStart();
		}
	}

	IEnumerator LoadNextScene_Coroutine()
	{
		yield return new WaitForSeconds(2f);
		if (playerWin)
		{
			MicrogameManager.current.LoadNextMicrogame();
		}
		else if (!playerWin)
		{
			SceneTransitionManager.current.ReloadCurrentScene();
		}
	}

	private void LoadNextScene_CoroutineStart()
	{
		StartCoroutine(LoadNextScene_Coroutine());
	}

	public float GetCurrentPunchTimeLimit()
	{
		return currentPunchTimeLimit;
	}
}

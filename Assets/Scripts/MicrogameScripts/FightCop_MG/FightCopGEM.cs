using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCopGEM : MonoBehaviour
{
	private int punchesDefended;
	[SerializeField]
	private int punchesDefendedThreshold;

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
		if (onCopResumeCombat != null) onCopResumeCombat();
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
			LoadNextScene();
		}
	}

	private void LoadNextScene()
	{
		MicrogameManager.current.LoadNextMicrogame();
	}
}

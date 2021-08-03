using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightVictimGEM : MonoBehaviour
{
	private int punchesDefended;
	[SerializeField]
	private int punchesDefendedThreshold, punchIncrement, maximumPunchThreshold;

	public static FightVictimGEM current;

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
			punchesDefendedThreshold = Mathf.Clamp(punchesDefendedThreshold + punchIncrement, 0, maximumPunchThreshold);
			VictimVulnerable();
		}
	}

	public event Action onVictimResumeCombat;
	public void VictimResumeCombat()
	{
		if (onVictimResumeCombat != null) onVictimResumeCombat();
	}

	public event Action onVictimVulnerable;
	public void VictimVulnerable()
	{
		if (onVictimVulnerable != null) onVictimVulnerable();
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

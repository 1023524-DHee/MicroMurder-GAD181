using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInmatesGEM : MonoBehaviour
{
    public static FightInmatesGEM current;

    // Start is called before the first frame update
    void Awake()
    {
        current = this;
		Invoke("GameStart", 3f);
    }

	public event Action onGameStart;
	public void GameStart()
	{
		if (onGameStart != null) onGameStart();
	}

	public event Action onTimerDown;
	public void TimerDown()
	{
		if (onTimerDown != null) onTimerDown();
	}

	public event Action onPlayerTakeDamage;
	public void PlayerTakeDamage()
	{
		if (onPlayerTakeDamage != null) onPlayerTakeDamage();
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneGEM : MonoBehaviour
{
	private int shotsFired, namesKilled;
	private int maxNumberOfNames = 36;

    public static EndSceneGEM current;
	public TMP_Text killsText, shotsText;
	public Animator creditsScoreAnimator;

	private void Awake()
	{
        current = this;
	}

	public event Action onTextShot;
	public void TextShot()
	{
		if (onTextShot != null)
		{
			onTextShot();
			shotsFired++;
		}
	}

	public event Action onInvulnerableTextShot;
	public void InvulnerableTextShot()
	{
		if (onInvulnerableTextShot != null) onInvulnerableTextShot();
	}

	public void GameEnd()
	{
		ReportStats();
		StartCoroutine(GameEnd_Coroutine());
	}

	public void NameKilled()
	{
		namesKilled++;
	}

	public void ReportStats()
	{
		killsText.text = "" + namesKilled;
		shotsText.text = "" + shotsFired;
		if (namesKilled == 0)
		{
			creditsScoreAnimator.SetTrigger("End1");
		}
		else if (namesKilled < maxNumberOfNames)
		{
			creditsScoreAnimator.SetTrigger("End2");
		}
		else if (namesKilled == maxNumberOfNames)
		{
			creditsScoreAnimator.SetTrigger("End3");
		}
	}

	IEnumerator GameEnd_Coroutine()
	{
		yield return new WaitForSeconds(10f);
		MicrogameManager.current.LoadNextMicrogame();
	}
}

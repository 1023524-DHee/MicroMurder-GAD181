using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialGEM : MonoBehaviour
{
	public static TrialGEM current;

	private void Awake()
	{
		current = this;	
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
}

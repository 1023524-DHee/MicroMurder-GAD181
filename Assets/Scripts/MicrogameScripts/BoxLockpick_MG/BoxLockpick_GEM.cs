using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLockpick_GEM : MonoBehaviour
{
	public static BoxLockpick_GEM current;

	private void Awake()
	{
		current = this;
	}

	public event Action onCorrectLockPositionEntered;
	public void CorrectLockPositionEntered()
	{
		if (onCorrectLockPositionEntered != null) onCorrectLockPositionEntered();
	}
}

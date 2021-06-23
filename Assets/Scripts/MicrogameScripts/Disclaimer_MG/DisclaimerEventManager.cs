using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisclaimerEventManager : MonoBehaviour
{
	public static DisclaimerEventManager current;

	private void Awake()
	{
		current = this;
	}

	public event Action onTextPlaced;
	public void TextPlaced()
	{
		if (onTextPlaced != null) { onTextPlaced(); }
	}
}

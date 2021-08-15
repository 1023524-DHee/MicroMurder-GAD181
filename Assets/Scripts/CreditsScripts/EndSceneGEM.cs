using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneGEM : MonoBehaviour
{
    public static EndSceneGEM current;

	private void Awake()
	{
        current = this;
	}

	public event Action onTextShot;
	public void TextShot()
	{
		if (onTextShot != null) onTextShot();
	}

	public event Action onInvulnerableTextShot;
	public void InvulnerableTextShot()
	{
		if (onInvulnerableTextShot != null) onInvulnerableTextShot();
	}
}

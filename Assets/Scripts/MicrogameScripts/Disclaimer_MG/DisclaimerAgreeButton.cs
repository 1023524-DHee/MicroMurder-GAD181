using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisclaimerAgreeButton : MonoBehaviour
{
	private int totalTextAmount;
	private int currentTextAmount;

	public GameObject AgreeButton;
	public AudioClip textPlacedClip, textPlacedFailClip;

	private void Start()
	{
		totalTextAmount = GameObject.FindGameObjectsWithTag("Text").Length;
		DisclaimerEventManager.current.onTextPlaced += TextPlaced;
	}

	private void TextPlaced()
	{
		AudioManager.current.PlaySound(textPlacedClip);
		currentTextAmount++;
		if (currentTextAmount == totalTextAmount)
		{
			ShowAgreeButton();
		}
	}

	public void AgreeButtonPressed()
	{
		MicrogameManager.current.LoadNextMicrogame();
	}

	private void ShowAgreeButton()
	{
		AgreeButton.SetActive(true);
	}
}

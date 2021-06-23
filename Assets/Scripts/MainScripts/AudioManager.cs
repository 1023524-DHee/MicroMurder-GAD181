using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager current;

	public AudioClip buttonHoverClip, startButtonClickClip;

	private AudioSource audioSource;

	private void Awake()
	{
		current = this;
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayHoverSound()
    {
		PlaySound(buttonHoverClip);
    }
	public void PlayStartClickSound()
	{
		PlaySound(startButtonClickClip);
	}

	public void PlaySound(AudioClip clip_param)
	{
		audioSource.clip = clip_param;
		audioSource.Play();
	}
}

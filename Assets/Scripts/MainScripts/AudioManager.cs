using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonHoverClip;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayHoverSound()
    {
		audioSource.clip = buttonHoverClip;
		audioSource.Play();
    }
}

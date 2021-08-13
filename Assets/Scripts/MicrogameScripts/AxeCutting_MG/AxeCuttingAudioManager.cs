using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCuttingAudioManager : MonoBehaviour
{
	public static AxeCuttingAudioManager current;

	private AudioSource audioSource;

	private void Awake()
	{
		current = this;
		audioSource = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip clip_param)
	{
		audioSource.clip = clip_param;
		audioSource.Play();
	}
}
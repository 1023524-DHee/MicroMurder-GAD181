using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggingCorpseAudioManager : MonoBehaviour
{
	public static BaggingCorpseAudioManager current;

	private AudioSource audioSource;

	private void Awake()
	{
		current = this;
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayBagSound(AudioClip clip_bag)
	{
		audioSource.clip = clip_bag;
		audioSource.Play(); 
	} 

	public void PlayBodyPickUpSound(AudioClip clip_BodyPart)
    {
		audioSource.clip = clip_BodyPart;
		audioSource.Play();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio_FightInmate : MonoBehaviour
{
    private AudioSource audioSource;

    public static PlayAudio_FightInmate current;
    public AudioClip spawnClip, takeDamageClip, deathClip;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(string audioClipName)
    {
        switch (audioClipName)
        {
            case "spawnSound":
                audioSource.PlayOneShot(spawnClip);
                break;
            case "takeDamageSound":
                audioSource.PlayOneShot(takeDamageClip);
                break;
            case "deathSound":
                audioSource.PlayOneShot(deathClip);
                break;
        }
    }
}

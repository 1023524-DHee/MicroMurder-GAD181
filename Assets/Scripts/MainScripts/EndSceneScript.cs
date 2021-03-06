using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneScript : MonoBehaviour
{
    public Animator sceneAnimator;
    public AudioClip laughClip, ambientClip, crunchClip, highPitchClip;
    public List<GameObject> enableObjects, disableObjects;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("StartAnimation", 2f);
    }

    private void StartAnimation()
    {
        sceneAnimator.SetTrigger("PlayAnim");
    }

    private void PlayLaughSound()
    {
        audioSource.clip = laughClip;
        audioSource.Play();
    }

    private void PlayAmbientSound()
    {
        AudioSource.PlayClipAtPoint(ambientClip, transform.position);
    }

    private void PlayCrunchSound()
    {
        AudioSource.PlayClipAtPoint(crunchClip, transform.position);
        AudioSource.PlayClipAtPoint(highPitchClip, transform.position);
    }

    private void EndAnimation()
    {
        foreach (GameObject thing in enableObjects)
        {
            thing.SetActive(true);
        }

        foreach (GameObject thing in disableObjects)
        {
            thing.SetActive(false);
        }
    }
}

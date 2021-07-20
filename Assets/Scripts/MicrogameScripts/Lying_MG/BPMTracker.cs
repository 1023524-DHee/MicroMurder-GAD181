using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// BPM Speed is divided by 60.
public class BPMTracker : MonoBehaviour
{
    private bool canPress = false;
    private bool BPMChanged = false;
    private bool pressed = false;
    private float amountToChange;

    public float currentBPM;
    public AudioClip soundClip;
    public AudioSource audioSource;
    public GameObject indicatorCircleSprite;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = soundClip;
        LyingGEM.current.onGameStart += ShrinkCircle_CoroutineStart;
        LyingGEM.current.onInterrogatorSlam += SetBPMValue;
        LyingGEM.current.onGameEnd += CleanUp;
    }

    public void ButtonPress()
    {
        pressed = true;
        if (canPress)
        {
            LyingGEM.current.HealthBarUpdate(false);
            if (currentBPM < 1f)
            {
                SetBPMValue(currentBPM + 0.1f);
            }
        }
        else
        {
            LyingGEM.current.HealthBarUpdate(true);
            if (currentBPM > 0.4f)
            {
                SetBPMValue(currentBPM - 0.1f);
            }
        }
    }

    // Handles BPM change at runtime
    private void HandleBPMChange()
    {
        if (BPMChanged)
        {
            currentBPM = amountToChange;
            BPMChanged = false;
        }
        ShrinkCircle_CoroutineStart();
    }

    // Set the new BPM value
    public void SetBPMValue(float newBPMValue)
    {
        BPMChanged = true;
        amountToChange = newBPMValue;
    }

    private void CleanUp()
    {
        indicatorCircleSprite.SetActive(false);
        StopAllCoroutines();
    }

    // Shrinks the timing circle
    IEnumerator ShrinkCircle_Coroutine()
    {
        bool audioPlayed = false;
        float startTime = Time.time;
        float endTime = startTime + currentBPM;
        Vector3 initCircleScale = indicatorCircleSprite.transform.localScale;

        while (Time.time < endTime)
        {
            indicatorCircleSprite.transform.localScale = Vector3.Lerp(initCircleScale, new Vector3(0.5f, 0.5f, 0.5f), (Time.time - startTime) / currentBPM);
            if (indicatorCircleSprite.transform.localScale.x < 1.5f)
            {
                if (!audioPlayed)
                {
                    audioPlayed = true;
                    audioSource.Play();
                }
                canPress = true;
            }
            yield return null;
        }

        canPress = false;
        indicatorCircleSprite.transform.localScale = initCircleScale;
        if (!pressed)
        {
            LyingGEM.current.HealthBarUpdate(true);
            if (currentBPM > 0.4f)
            {
                SetBPMValue(currentBPM - 0.1f);
            }
        }

        pressed = false;
        HandleBPMChange();
    }
    private void ShrinkCircle_CoroutineStart()
    {
        StartCoroutine(ShrinkCircle_Coroutine());
    }
}

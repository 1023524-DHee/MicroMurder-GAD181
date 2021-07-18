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

    public static BPMTracker current;

    public float currentBPM;
    public AudioClip soundClip;
    public AudioSource audioSource;
    public GameObject gameObjectSprite;
    public GameObject indicatorCircleSprite;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        audioSource.clip = soundClip;
        Invoke("StartInitialCoroutines", 3f);
    }

	private void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
            if (canPress)
            {
                HealthBar.current.TakeDamage(false);
                if (currentBPM < 1f)
                {
                    SetBPMValue(currentBPM + 0.1f);
                }
            }
            else
            {
                HealthBar.current.TakeDamage(true);
                if (currentBPM > 0.4f)
                {
                    SetBPMValue(currentBPM - 0.1f);
                }
            }
        }
    }

    private void StartInitialCoroutines()
    {
        StartCoroutine(ShrinkCircle());
        StartCoroutine(Interrogator.current.InterrogatorSlam());
        StartCoroutine(Timer.current.Timer_Coroutine());
    }

    // Handles BPM change at runtime
    private void HandleBPMChange()
    {
        if (BPMChanged)
        {
            currentBPM = amountToChange;
            BPMChanged = false;
        }
        StartCoroutine(ShrinkCircle());
    }

    // Set the new BPM value
    public void SetBPMValue(float newBPMValue)
    {
        BPMChanged = true;
        amountToChange = newBPMValue;
    }

    public void SetCircleActive(bool circleActive)
    {
        indicatorCircleSprite.SetActive(circleActive);
    }

    public void StopCoroutines()
    {
        StopAllCoroutines();
    }

    // Shrinks the timing circle
    IEnumerator ShrinkCircle()
    {
        float startTime = Time.time;
        float endTime = startTime + currentBPM;
        Vector3 initCircleScale = indicatorCircleSprite.transform.localScale;

        while (Time.time < endTime)
        {
            indicatorCircleSprite.transform.localScale = Vector3.Lerp(initCircleScale, new Vector3(0.5f, 0.5f, 0.5f), (Time.time - startTime) / currentBPM);
            if (indicatorCircleSprite.transform.localScale.x < 1.7f)
            {
                canPress = true;
            }
            yield return null;
        }

        canPress = false;
        indicatorCircleSprite.transform.localScale = initCircleScale;
        audioSource.Play();

        if (!pressed)
        {
            HealthBar.current.TakeDamage(true);
            if (currentBPM > 0.4f)
            {
                SetBPMValue(currentBPM - 0.1f);
            }
        }

        pressed = false;
        HandleBPMChange();
    }
}

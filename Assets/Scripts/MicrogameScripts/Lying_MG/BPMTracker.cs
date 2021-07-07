using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// BPM Speed is divided by 60.
public class BPMTracker : MonoBehaviour
{
    private bool canPress = false;
    private bool BPMChanged = false;
    private bool pressed = false;

    public AudioClip heart60Clip, heart120Clip, heart150Clip;
    public AudioSource audioSource;
    public float currentBPM;
    public float amountToChange;
    public GameObject heartSprite;
    public GameObject circleSprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShrinkCircle());
        audioSource.clip = heart60Clip;
    }

	private void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
            if (canPress)
            {
                HealthBar.current.TakeDamage(false);
            }
            else
            {
                HealthBar.current.TakeDamage(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetBPMValue(1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetBPMValue(0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetBPMValue(0.4f);
        }
    }

    // Shrinks the timing circle
    IEnumerator ShrinkCircle()
    {
        float startTime = Time.time;
        float endTime = startTime + currentBPM;
        Vector3 initCircleScale = circleSprite.transform.localScale;

        while(Time.time < endTime)
        {
            circleSprite.transform.localScale = Vector3.Lerp(initCircleScale, new Vector3(0.5f,0.5f,0.5f), (Time.time-startTime)/currentBPM);
            if (circleSprite.transform.localScale.x < 1.5f)
            {
                canPress = true;
            }
            yield return null;
        }
        canPress = false;
        circleSprite.transform.localScale = initCircleScale;
        audioSource.Play();
        if (!pressed)
        {
            HealthBar.current.TakeDamage(true);
        }
        pressed = false;
        HandleBPMChange();
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

    public void ClickDetected()
    {
        if (canPress)
        {
            HealthBar.current.TakeDamage(false);
        }
    }
}

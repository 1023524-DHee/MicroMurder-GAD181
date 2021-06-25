using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMTracker : MonoBehaviour
{
    private bool canPress = false;
    private bool BPMChanged = false;
    private bool pressed = false;

    public float currentBPM;
    public float amountToChange;
    public GameObject heartSprite;
    public GameObject circleSprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShrinkCircle());
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetBPMValue(amountToChange);
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
            if (circleSprite.transform.localScale.x < 1.3f)
            {
                canPress = true;
            }
            yield return null;
        }
        canPress = false;
        circleSprite.transform.localScale = initCircleScale;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMTracker : MonoBehaviour
{
    private bool canPress = false;
    private bool BPMChanged = false;

    public float currentBPM;
    public GameObject heartSprite;
    public GameObject circleSprite;
    public float amountToChange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShrinkCircle());
    }

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPress)
            {
                print("PRESSED");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BPMChanged = true;
        }

    }

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
        HandleBPMChange(amountToChange);
    }

    private void HandleBPMChange(float changedBPMValue)
    {
        if (BPMChanged)
        {
            currentBPM = changedBPMValue;
            BPMChanged = false;
        }
        StartCoroutine(ShrinkCircle());
    }

    public void SetBPMValue(float newBPMValue)
    {
        amountToChange = newBPMValue;
    }
}

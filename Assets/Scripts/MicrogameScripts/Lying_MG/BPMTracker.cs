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

    public AudioClip heartbeatClip;
    public AudioSource audioSource;
    public float currentBPM;
    public float amountToChange;
    public GameObject heartSprite;
    public GameObject circleSprite;
    public Image blackoutImage;
    public Animator interrogatorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShrinkCircle());
        StartCoroutine(RandomChangeBPM());
        audioSource.clip = heartbeatClip;
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

    // Shrinks the timing circle
    IEnumerator ShrinkCircle()
    {
        float startTime = Time.time;
        float endTime = startTime + currentBPM;
        Vector3 initCircleScale = circleSprite.transform.localScale;

        while(Time.time < endTime)
        {
            circleSprite.transform.localScale = Vector3.Lerp(initCircleScale, new Vector3(0.5f,0.5f,0.5f), (Time.time-startTime)/currentBPM);
            if (circleSprite.transform.localScale.x < 1.7f)
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
            if (currentBPM > 0.4f)
            {
                SetBPMValue(currentBPM - 0.1f);
            }
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

    IEnumerator RandomChangeBPM()
    {
        yield return new WaitForSeconds(Random.Range(5f,10f));
        interrogatorAnimation.SetTrigger("Trigger");
        yield return new WaitForSeconds(interrogatorAnimation.GetCurrentAnimatorStateInfo(0).length);
        SetBPMValue(0.3f);
        StartCoroutine(RandomChangeBPM());
    }
}

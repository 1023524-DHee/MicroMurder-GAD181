using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResponse : MonoBehaviour
{
    private int maxHammers, currentHammers;
    private int randomResponseIndex;
    private GameObject instantiatedObject1, instantiatedObject2;
    private AudioSource audioSource;

    public Transform response1Pos, response2Pos;
    public GameObject positiveResponse, negativeResponse;
    public AudioClip goodClip, badClip;

    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        TrialGEM.current.onHammerSlammed += Spawn;
        TrialGEM.current.onGameEnd += GameEndCleanup;

        audioSource = GetComponent<AudioSource>();
    }

    private void Spawn()
    {
        currentHammers++;
        if (currentHammers > maxHammers) return;

        print("Spawn");
        randomResponseIndex = Random.Range(0, 3);
        switch (randomResponseIndex)
        {
            // WL
            case 0:
                instantiatedObject1 = Instantiate(positiveResponse, response1Pos);
                instantiatedObject2 = Instantiate(negativeResponse, response2Pos);
                break;
            // LW
            case 1:
                instantiatedObject1 = Instantiate(negativeResponse, response1Pos);
                instantiatedObject2 = Instantiate(positiveResponse, response2Pos);
                break;
            // LL
            case 2:
                instantiatedObject1 = Instantiate(negativeResponse, response1Pos);
                instantiatedObject2 = Instantiate(negativeResponse, response2Pos);
                break;
        }
        StartCountDown_CoroutineStart();
    }

    IEnumerator StartCountdown_Coroutine()
    {
        float initialTime = Time.time;
        bool clickedCorrect = false;
        bool buttonPressed = false;

        if (randomResponseIndex == 2)
        {
            clickedCorrect = true;
        }

        while ((Time.time < initialTime + timeLimit) && !buttonPressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
				switch (randomResponseIndex)
				{
					case 0:
                        clickedCorrect = true;
						break;
					case 1:
                        clickedCorrect = false;
                        break;
					case 2:
                        clickedCorrect = false;
                        break;
				}
                Destroy(instantiatedObject1);
                Destroy(instantiatedObject2);
                buttonPressed = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                switch (randomResponseIndex)
                {
                    case 0:
                        clickedCorrect = false;
                        break;
                    case 1:
                        clickedCorrect = true;
                        break;
                    case 2:
                        clickedCorrect = false;
                        break;
                }
                Destroy(instantiatedObject1);
                Destroy(instantiatedObject2);
                buttonPressed = true;
            }
            yield return null;
        }

        if (clickedCorrect)
        {
            PlayGoodAudio();
            TrialGEM.current.CorrectResponseClicked();
        }
        else if (!clickedCorrect)
        {
            PlayBadAudio();
            TrialGEM.current.WrongResponseClicked();
        }

        if (instantiatedObject1 != null) Destroy(instantiatedObject1);
        if (instantiatedObject2 != null) Destroy(instantiatedObject2);

        yield return new WaitForSeconds(0.1f);
        Spawn();
    }

    private void PlayBadAudio()
    {
        audioSource.clip = badClip;
        audioSource.Play();
    }

    private void PlayGoodAudio()
    {
        audioSource.clip = goodClip;
        audioSource.Play();
    }

    private void StartCountDown_CoroutineStart()
    {
        StartCoroutine(StartCountdown_Coroutine());
    }

    public void SetNumberOfHammers(int numHammers)
    {
        currentHammers = 0;
        maxHammers = numHammers;
    }

    private void GameEndCleanup()
    {
        StopAllCoroutines();
        if (instantiatedObject1 != null) Destroy(instantiatedObject1);
        if (instantiatedObject2 != null) Destroy(instantiatedObject2);
    }
}

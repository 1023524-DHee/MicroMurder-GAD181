using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator judgeAnimator;
    private int currentHammers, numberOfHammers;
    private bool keepSlamming = true;
    private float hammerInterval = 5f;

    public SpawnResponse spawner;

    // Start is called before the first frame update
    void Start()
    {
        TrialGEM.current.onGameEnd += GameEndCleanup;

        judgeAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


        StartCoroutine(SlamHammerInterval());
    }

    IEnumerator SlamHammer()
    {
        spawner.SetNumberOfHammers(numberOfHammers);

        while (keepSlamming)
        {
            if (judgeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                judgeAnimator.SetTrigger("SlamTrigger");
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.15f);
        TrialGEM.current.HammerSlammed();
    }

    IEnumerator SlamHammerInterval()
    {
        float currentTime = Time.time;
        float timeSinceLastHammer = Time.time;
        while (Time.time < currentTime + 40f)
        {
            if (Time.time > timeSinceLastHammer + hammerInterval)
            {
                currentHammers = 0;
                keepSlamming = true;
                if(numberOfHammers < 4) numberOfHammers++;

                StartCoroutine(SlamHammer());
                timeSinceLastHammer = Time.time;
            }
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        TrialGEM.current.SetPlayerWin(true);
        TrialGEM.current.GameEnd();
    }

    public void IncrementHammer()
    {
        currentHammers++;
        if (currentHammers >= numberOfHammers)
        {
            keepSlamming = false;
        }
    }

    public void PlaySlamAudio()
    {
        audioSource.Play();
    }

    private void GameEndCleanup()
    {
        StopAllCoroutines();
    }
}

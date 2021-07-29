using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSpawner : MonoBehaviour
{
    private int currentPunchPosition;
    private bool copPunched;

    private float copVulnerableTimeLimit;
    private int punchesDefended;
    private int punchesDefendedThreshold;
    private int copHealth;

    public float punchInterval;
    public GameObject fistPrefab;
    public List<Transform> punchPositions;

    // Start is called before the first frame update
    void Start()
    {
        FightCopGEM.current.onPunchClickedSuccess += PunchDefended;
        FightCopGEM.current.onGameEnd += GameEndCleanup;

        copVulnerableTimeLimit = 3f;
        punchesDefended = 0;
        punchesDefendedThreshold = 5;
        currentPunchPosition = Random.Range(0, punchPositions.Count);
        copHealth = 3;

        Invoke("ChooseRandomPosition_CoroutineStart", 3f);
    }

    IEnumerator ChooseRandomPosition()
    {
        yield return new WaitForSeconds(punchInterval);
        int newRandomCopPosition = Random.Range(0, punchPositions.Count);
        while (newRandomCopPosition == currentPunchPosition)
        {
            newRandomCopPosition = Random.Range(0, punchPositions.Count);
            yield return null;
        }
        currentPunchPosition = newRandomCopPosition;
        Instantiate(fistPrefab, punchPositions[currentPunchPosition]);
        ChooseRandomPosition_CoroutineStart();
    }

    private void ChooseRandomPosition_CoroutineStart()
    {
        StartCoroutine(ChooseRandomPosition());
    }

    private void PunchDefended()
    {
        punchesDefended++;
        if (punchesDefended >= punchesDefendedThreshold)
        {
            StopAllCoroutines();
            CopVulnerable_CoroutineStart();
            punchesDefended = 0;
            punchesDefendedThreshold += 2;
        }
    }

    IEnumerator CopVulnerable_Coroutine()
    {
        float initialTime = Time.time;
        GetComponent<BoxCollider2D>().enabled = true;

        while (Time.time < initialTime + copVulnerableTimeLimit)
        {
            if (copPunched)
            {
                print("punched");
                copHealth -= 1;
                if (copHealth <= 0)
                {
                    FightCopGEM.current.GameEnd();
                }
                copPunched = false;
                GetComponent<BoxCollider2D>().enabled = false;
                ChooseRandomPosition_CoroutineStart();
                yield break;
            }
            yield return null;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        ChooseRandomPosition_CoroutineStart();
    }

    private void CopVulnerable_CoroutineStart()
    {
        StartCoroutine(CopVulnerable_Coroutine());
    }

	private void OnMouseDown()
	{
        copPunched = true;   
	}

    private void GameEndCleanup()
    {
        StopAllCoroutines();
    }
}

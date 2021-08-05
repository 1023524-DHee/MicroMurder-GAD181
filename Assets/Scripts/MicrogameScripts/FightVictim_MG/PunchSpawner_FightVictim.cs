using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSpawner_FightVictim : MonoBehaviour
{
    private int currentPunchPosition;

    public float punchInterval;
    public GameObject leftFistPrefab, rightFistPrefab;
    public List<Transform> punchPositions;

    // Start is called before the first frame update
    void Start()
    {
        FightVictimGEM.current.onGameStart += ChooseRandomPosition_CoroutineStart;
        FightVictimGEM.current.onVictimVulnerable += StopSpawning;
        FightVictimGEM.current.onVictimResumeCombat += ChooseRandomPosition_CoroutineStart;
        FightVictimGEM.current.onGameEnd += StopSpawning;

        currentPunchPosition = Random.Range(0, punchPositions.Count);
    }

    IEnumerator ChooseRandomPosition()
    {
        yield return new WaitForSeconds(punchInterval);
        int newRandomFistPosition = Random.Range(0, punchPositions.Count);

		switch (newRandomFistPosition)
		{
			case 0:
				Instantiate(leftFistPrefab, punchPositions[0]);
				break;
			case 1:
				Instantiate(rightFistPrefab, punchPositions[1]);
				break;
		}

		ChooseRandomPosition_CoroutineStart();
    }

    private void ChooseRandomPosition_CoroutineStart()
    {
        StartCoroutine(ChooseRandomPosition());
    }

    private void StopSpawning()
    {
        StopAllCoroutines();
    }
}

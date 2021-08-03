using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSpawner_FightVictim : MonoBehaviour
{
    private int currentPunchPosition;

    public float punchInterval;
    public GameObject fistPrefab;
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

    private void StopSpawning()
    {
        StopAllCoroutines();
    }
}

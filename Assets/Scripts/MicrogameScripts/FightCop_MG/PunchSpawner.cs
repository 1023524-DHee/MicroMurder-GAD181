using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSpawner : MonoBehaviour
{
    private int currentPunchPosition;

    public float punchInterval;
    public GameObject leftFistPrefab, rightFistPrefab;
    public List<Transform> punchPositions;

    // Start is called before the first frame update
    void Start()
    {
        //FightCopGEM.current.onPunchClickedSuccess += PunchDefended;
        FightCopGEM.current.onGameStart += ChooseRandomPosition_CoroutineStart;
        FightCopGEM.current.onCopVulnerable += StopSpawning;
        FightCopGEM.current.onCopResumeCombat += ChooseRandomPosition_CoroutineStart;
        FightCopGEM.current.onGameEnd += StopSpawning;

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
                Instantiate(leftFistPrefab, punchPositions[1]);
                break;
            case 2:
                Instantiate(rightFistPrefab, punchPositions[2]);
                break;
            case 3:
                Instantiate(rightFistPrefab, punchPositions[3]);
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

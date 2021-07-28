using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmateSpawner : MonoBehaviour
{
    private float currentSpawnTime = 2f;

    public List<GameObject> inmatePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInmates_CoroutineStart();
        FightInmatesGEM.current.onGameEnd += GameEndedCleanup;
        FightInmatesGEM.current.onTimerDown += ChangeSpawnTime;
    }

    IEnumerator SpawnInmates_Coroutine()
    {
        yield return new WaitForSeconds(currentSpawnTime);
        PlayAudio_FightInmate.current.PlayAudioClip("spawnSound");
        Instantiate(inmatePrefabs[Random.Range(0,inmatePrefabs.Count)]);
        SpawnInmates_CoroutineStart();
    }

    private void SpawnInmates_CoroutineStart()
    {
        StartCoroutine(SpawnInmates_Coroutine());
    }

    private void ChangeSpawnTime()
    {
        StopAllCoroutines();
        currentSpawnTime -= 0.5f;
        SpawnInmates_CoroutineStart();
    }

    private void GameEndedCleanup()
    {
        StopAllCoroutines();
    }

	private void OnDestroy()
	{
        FightInmatesGEM.current.onGameEnd -= GameEndedCleanup;
        FightInmatesGEM.current.onTimerDown -= ChangeSpawnTime;
    }
}

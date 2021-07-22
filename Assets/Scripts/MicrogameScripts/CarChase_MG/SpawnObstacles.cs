using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnableObstables;

    void Start()
    {
        SpawnObstacles_CoroutineStart();
    }

    IEnumerator SpawnObstacles_Coroutine()
    {
        int gameObjectIndex = Random.Range(0, spawnableObstables.Length);
        int locationIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(spawnableObstables[gameObjectIndex], spawnPoints[locationIndex]);
        yield return new WaitForSeconds(2f);
        SpawnObstacles_CoroutineStart();
    }

    private void SpawnObstacles_CoroutineStart()
    {
        StartCoroutine(SpawnObstacles_Coroutine());
    }
}

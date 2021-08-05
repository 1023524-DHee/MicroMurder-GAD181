using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCops : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnableObstables;

    void Start()
    {
        Invoke("SpawnCops_CoroutineStart", 2f);
    }

    IEnumerator SpawnCops_Coroutine()
    {
        int gameObjectIndex = Random.Range(0, spawnableObstables.Length);
        int locationIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(spawnableObstables[gameObjectIndex], spawnPoints[locationIndex]);
        yield return new WaitForSeconds(2f);
        SpawnCops_CoroutineStart();        
    }
    
    private void SpawnCops_CoroutineStart()
    {
        StartCoroutine(SpawnCops_Coroutine());
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 15f)
        {
            StopAllCoroutines();
            //print("No Cops" + Time.time);
        }
    }    
}

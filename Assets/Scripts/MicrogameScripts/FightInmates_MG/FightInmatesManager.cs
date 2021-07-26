using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInmatesManager : MonoBehaviour
{
    public List<GameObject> inmatePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnInmates_CoroutineStart", 1f, 0.75f);
    }

    IEnumerator SpawnInmates_Coroutine()
    {
        //yield return new WaitForSeconds(Random.Range(1f, 4f));
        Instantiate(inmatePrefabs[Random.Range(0,inmatePrefabs.Count)]);
        yield return null;
    }

    private void SpawnInmates_CoroutineStart()
    {
        StartCoroutine(SpawnInmates_Coroutine());
    }
}

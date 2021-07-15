using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject boundingBox;
    public int objectSpeed;

    public List<Transform> waypoints;

    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    void Start()
    {
        spawnObjects();
        StartCoroutine(MoveObject_Coroutine());
    }

    public void spawnObjects()
    {

        GameObject toSpawn;
        MeshCollider c = boundingBox.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < spawnPool.Count; i++)
        {
            toSpawn = spawnPool[i];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            GameObject spawnable = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            spawnable.GetComponent<SpawnedMovement>().ChangeSpeed(objectSpeed);
            spawnedObjects.Add(spawnable);

        }
    }

    IEnumerator MoveObject_Coroutine()
    {
        foreach (GameObject spawn in spawnedObjects)
        {
            Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Count)];
            spawn.GetComponent<SpawnedMovement>().ChangeWaypoint(randomWaypoint);
        }
        yield return new WaitForSeconds(Random.Range(1f,3f));
        StartCoroutine(MoveObject_Coroutine());
    }
}


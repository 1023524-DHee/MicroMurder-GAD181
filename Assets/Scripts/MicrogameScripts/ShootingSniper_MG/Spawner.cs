using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject boundingBox;
    public int objectSpeed;

    public List<Transform> waypoints;  // Liost of waypoints 

    private List<GameObject> spawnedObjects = new List<GameObject>(); // List of game objects to spawn

    void Start()
    {
        spawnObjects();
        StartCoroutine(MoveObject_Coroutine());
    }

    public void spawnObjects()
    {

        GameObject toSpawn;
        MeshCollider c = boundingBox.GetComponent<MeshCollider>(); // Boundry for spawn objects to spawn in

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < spawnPool.Count; i++)
        {
            toSpawn = spawnPool[i];  

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x); // sets the mouse bounds along x axis
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y); // sets the mouse bounds along y axis
            pos = new Vector2(screenX, screenY);

            GameObject spawnable = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            spawnable.GetComponent<SpawnedMovement>().ChangeSpeed(objectSpeed); // Speed of objects between points
            spawnedObjects.Add(spawnable);

        }
    }

    IEnumerator MoveObject_Coroutine()
    {
        foreach (GameObject spawn in spawnedObjects)
        {
            Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Count)]; // Objects to choose random points
            spawn.GetComponent<SpawnedMovement>().ChangeWaypoint(randomWaypoint); // Objects choose random point after reaching first point
        }
        yield return new WaitForSeconds(Random.Range(1f,5f)); // wait X amount of seconds before going to new point
        StartCoroutine(MoveObject_Coroutine());
    }
}


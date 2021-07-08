using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject boundingBox;

    void Start()
    {
        spawnObjects();

    }

    public void spawnObjects()
    {
        destroyObjects();
        GameObject toSpawn;
        MeshCollider c = boundingBox.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        //for(int i = 0; i < numberToSpawn; i++)
        //{
        //    randomItem = Random.Range(0, spawnPool.Count);
        //    toSpawn = spawnPool[randomItem];

        //    screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        //    screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        //    pos = new Vector2(screenX, screenY);

        //    Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        //}

        for (int i = 0; i < spawnPool.Count; i++)
        {
            toSpawn = spawnPool[i];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }

    }
    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }


}

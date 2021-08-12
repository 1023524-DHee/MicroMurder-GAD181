using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot_ChaseSt : MonoBehaviour
{
    private int numberOfShots;

    public List<Transform> gunShotPositions;
    public float shotPreviewTime;

    // Start is called before the first frame update
    void Start()
    {
        ChaseStGEM.current.onDifficultyUp += ChangeNumberOfShots;
        numberOfShots = 1;
        Invoke("SelectRandomPosition_CoroutineStart", 3f);
    }

    IEnumerator SelectRandomPosition_Coroutine()
    {
        // Generate 2 lists. 1 to store 'n' random indexes. 1 for generating 'n' random indexes.
        List<int> randomPositionIndexes = new List<int>();
        List<int> tempPositions = new List<int>();

        // Fill the temporary list with numbers from 0 to number of gunShotPositions
        for (int ii = 0; ii < gunShotPositions.Count; ii++)
        {
            tempPositions.Add(ii);
        }

        // Generate 'n' random numbers
        for (int ii = 0; ii < numberOfShots; ii++)
        {
            int randomPosition = Random.Range(0, tempPositions.Count);
            randomPositionIndexes.Add(tempPositions[randomPosition]);
            tempPositions.RemoveAt(randomPosition);
        }  

        // Flashing Portion of coroutine. Flashing for shotPreviewTime.
        float startTime = Time.time;
        while (Time.time < startTime + shotPreviewTime)
        {
            foreach (int index in randomPositionIndexes)
            {
                gunShotPositions[index].GetComponent<SpriteRenderer>().enabled = true;
                gunShotPositions[index].GetComponent<SpriteRenderer>().color = Color.white;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (int index in randomPositionIndexes)
            {
                gunShotPositions[index].GetComponent<SpriteRenderer>().color = Color.black;
            }
            yield return new WaitForSeconds(0.1f);
        }

        // Call ShootBullet for each randomly selected index
        foreach (int index in randomPositionIndexes)
        {
            gunShotPositions[index].GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.05f);
            gunShotPositions[index].GetComponent<SpriteRenderer>().enabled = false;
            ChaseStGEM.current.ShootBullet(index);
        }
        yield return new WaitForSeconds(0.5f);
        SelectRandomPosition_CoroutineStart();
    }

    private void SelectRandomPosition_CoroutineStart()
    {
        StartCoroutine(SelectRandomPosition_Coroutine());
    }

    private void ChangeNumberOfShots()
    {
        numberOfShots++;
        shotPreviewTime += 0.25f;
        if (numberOfShots > 4) numberOfShots = 4;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResponse : MonoBehaviour
{
    private int randomResponseIndex;
    private GameObject instantiatedObject1, instantiatedObject2;

    public Transform response1Pos, response2Pos;
    public GameObject positiveResponse, negativeResponse;

    public float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 1f);
    }

    private void Spawn()
    {
        randomResponseIndex = Random.Range(0, 3);

        switch (randomResponseIndex)
        {
            // WL
            case 0:
                print("WL");
                instantiatedObject1 = Instantiate(positiveResponse, response1Pos);
                instantiatedObject2 = Instantiate(negativeResponse, response2Pos);
                break;
            // LW
            case 1:
                print("LW");
                instantiatedObject1 = Instantiate(negativeResponse, response1Pos);
                instantiatedObject2 = Instantiate(positiveResponse, response2Pos);
                break;
            // LL
            case 2:
                print("LL");
                instantiatedObject1 = Instantiate(negativeResponse, response1Pos);
                instantiatedObject2 = Instantiate(negativeResponse, response2Pos);
                break;
        }
        StartCountDown_CoroutineStart();
    }

    IEnumerator StartCountdown_Coroutine()
    {
        float initialTime = Time.time;
        bool clickedCorrect = false;

        if (randomResponseIndex == 2)
        {
            clickedCorrect = true;
        }

        while (Time.time < initialTime + timeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
				switch (randomResponseIndex)
				{
					case 0:
                        clickedCorrect = true;
						break;
					case 1:
                        clickedCorrect = false;
                        break;
					case 2:
                        clickedCorrect = false;
                        break;
				}
                Destroy(instantiatedObject1);
                Destroy(instantiatedObject2);
                //responseClicked = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                switch (randomResponseIndex)
                {
                    case 0:
                        clickedCorrect = false;
                        break;
                    case 1:
                        clickedCorrect = true;
                        break;
                    case 2:
                        clickedCorrect = false;
                        break;
                }
                Destroy(instantiatedObject1);
                Destroy(instantiatedObject2);
            }
            yield return null;
        }

        if (clickedCorrect) TrialGEM.current.CorrectResponseClicked();
        else if (!clickedCorrect) TrialGEM.current.WrongResponseClicked();

        if (instantiatedObject1 != null) Destroy(instantiatedObject1);
        if (instantiatedObject2 != null) Destroy(instantiatedObject2);

        yield return new WaitForSeconds(2f);
        Spawn();
    }

    private void StartCountDown_CoroutineStart()
    {
        StartCoroutine(StartCountdown_Coroutine());
    }
}

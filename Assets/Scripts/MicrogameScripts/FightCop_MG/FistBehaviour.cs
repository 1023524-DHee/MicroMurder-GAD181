using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBehaviour : MonoBehaviour
{
    private bool playerClicked = false;

    private float timeLimit = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        DealDamage_CoroutineStart();
    }

    IEnumerator DealDamage()
    {
        bool succeedClick = false;
        float initialTime = Time.time;

        while ((Time.time < (initialTime + timeLimit)))
        {
            if (playerClicked)
            {
                playerClicked = false;
                succeedClick = true;
                FightCopGEM.current.PunchClickedSuccess();
                Destroy(gameObject);
            }
            yield return null;
        }

        if (!succeedClick)
        {
            print("Fail");
            FightCopGEM.current.PlayerTakeDamage();
            Destroy(gameObject);
        }
    }

    private void DealDamage_CoroutineStart()
    {
        StartCoroutine(DealDamage());
    }

    private void OnMouseDown()
    {
        playerClicked = true;
    }
}

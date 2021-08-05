using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBehaviour_FightVictim : MonoBehaviour
{
    private bool playerClicked = false;

    public float timeLimit = 0.8f;

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
                FightVictimGEM.current.PunchClickedSuccess();
                Destroy(gameObject);
            }
            yield return null;
        }

        if (!succeedClick)
        {
            FightVictimGEM.current.PlayerTakeDamage();
        }
    }

    public void DestroyFist()
    {
        Destroy(gameObject);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopBehaviour : MonoBehaviour
{
    private bool copPunched;

    public float copHealth;
    public float copVulnerableTimeLimit;

    // Start is called before the first frame update
    void Start()
    {
        FightCopGEM.current.onCopVulnerable += CopVulnerable_CoroutineStart;
    }

    IEnumerator CopVulnerable_Coroutine()
    {
        float initialTime = Time.time;
        GetComponent<BoxCollider2D>().enabled = true;

        while (Time.time < initialTime + copVulnerableTimeLimit)
        {
            if (copPunched)
            {
                copHealth -= 1;
                if (copHealth <= 0)
                {
                    FightCopGEM.current.playerWin = true;
                    FightCopGEM.current.GameEnd();
                    yield break;
                }
                copPunched = false;
                GetComponent<BoxCollider2D>().enabled = false;
                FightCopGEM.current.CopResumeCombat();
                yield break;
            }
            yield return null;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        FightCopGEM.current.CopResumeCombat();
    }

    private void CopVulnerable_CoroutineStart()
    {
        StartCoroutine(CopVulnerable_Coroutine());
    }

    private void OnMouseDown()
    {
        copPunched = true;
    }
}

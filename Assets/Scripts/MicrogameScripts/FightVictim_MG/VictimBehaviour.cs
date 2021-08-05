using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimBehaviour : MonoBehaviour
{
    private bool victimPunched;

    public float victimHealth;
    public float victimVulnerableTimeLimit;

    // Start is called before the first frame update
    void Start()
    {
        FightVictimGEM.current.onVictimVulnerable += VictimVulnerable_CoroutineStart;
    }

    IEnumerator VictimVulnerable_Coroutine()
    {
        float initialTime = Time.time;
        GetComponent<BoxCollider2D>().enabled = true;

        while (Time.time < initialTime + victimVulnerableTimeLimit)
        {
            if (victimPunched)
            {
                victimHealth -= 1;
                if (victimHealth <= 0)
                {
                    FightVictimGEM.current.playerWin = true;
                    FightVictimGEM.current.GameEnd();
                    yield break;
                }
                victimPunched = false;
                GetComponent<BoxCollider2D>().enabled = false;
                FightVictimGEM.current.VictimResumeCombat();
                yield break;
            }
            yield return null;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        FightVictimGEM.current.VictimResumeCombat();
    }

    private void VictimVulnerable_CoroutineStart()
    {
        StartCoroutine(VictimVulnerable_Coroutine());
    }

    private void OnMouseDown()
    {
        victimPunched = true;
    }
}

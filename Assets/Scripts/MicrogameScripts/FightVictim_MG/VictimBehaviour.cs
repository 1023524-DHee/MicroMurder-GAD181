using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimBehaviour : MonoBehaviour
{
    private bool victimPunched;
    private Animator victimAnimator;
    private SpriteRenderer victimRenderer;
    private Coroutine flashingCoroutine;
    private BoxCollider2D victimCollider;

    public float victimHealth;
    public float victimVulnerableTimeLimit;
    public AudioClip takeDamageAudio;

    // Start is called before the first frame update
    void Start()
    {
        FightVictimGEM.current.onVictimVulnerable += VictimVulnerable_CoroutineStart;

        victimCollider = GetComponent<BoxCollider2D>();
        victimRenderer = GetComponent<SpriteRenderer>();
        victimAnimator = GetComponent<Animator>();
    }

    IEnumerator VictimVulnerable_Coroutine()
    {
        float initialTime = Time.time;
        victimCollider.enabled = true;
        VictimFlash_CoroutineStart();

        while (Time.time < initialTime + victimVulnerableTimeLimit)
        {
            if (victimPunched)
            {
                UpdateVictimAnimator();
                VictimFlash_CoroutineStop();

                victimHealth -= 1;
                if (victimHealth <= 0)
                {
                    victimRenderer.color = Color.white;
                    FightVictimGEM.current.playerWin = true;
                    FightVictimGEM.current.GameEnd();
                    yield break;
                }
                victimPunched = false;
                victimCollider.enabled = false;
            }
            yield return null;
        }
        FightVictimGEM.current.VictimResumeCombat();
        VictimFlash_CoroutineStop();
    }

    private void VictimVulnerable_CoroutineStart()
    {
        StartCoroutine(VictimVulnerable_Coroutine());
    }

    IEnumerator VictimFlash_Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        victimRenderer.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        victimRenderer.color = Color.white;
        VictimFlash_CoroutineStart();
    }

    private void VictimFlash_CoroutineStart()
    {
        flashingCoroutine = StartCoroutine(VictimFlash_Coroutine());
    }

    private void VictimFlash_CoroutineStop()
    {
        victimRenderer.color = Color.gray;
        StopCoroutine(flashingCoroutine);
    }

    private void UpdateVictimAnimator()
    {
        victimAnimator.SetTrigger("DamagedTrigger");
        AudioSource.PlayClipAtPoint(takeDamageAudio, transform.position);
    }

    private void OnMouseDown()
    {
        victimPunched = true;
    }
}

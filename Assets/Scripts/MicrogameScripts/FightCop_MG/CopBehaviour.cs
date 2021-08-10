using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopBehaviour : MonoBehaviour
{
    private bool copPunched;
    private Animator copAnimator;
    private SpriteRenderer copRenderer;
    private Coroutine flashingCoroutine;
    private BoxCollider2D copCollider;

    public float copHealth;
    public float copVulnerableTimeLimit;
    public AudioClip takeDamageAudio;

    // Start is called before the first frame update
    void Start()
    {
        FightCopGEM.current.onCopVulnerable += CopVulnerable_CoroutineStart;

        copCollider = GetComponent<BoxCollider2D>();
        copRenderer = GetComponent<SpriteRenderer>();
        copAnimator = GetComponent<Animator>();
    }

    IEnumerator CopVulnerable_Coroutine()
    {
        float initialTime = Time.time;
        copCollider.enabled = true;
        CopFlash_CoroutineStart();

        while (Time.time < initialTime + copVulnerableTimeLimit)
        {
            if (copPunched)
            {
                UpdateCopAnimator();
                CopFlash_CoroutineStop();

                copHealth -= 1;
                if (copHealth <= 0)
                {
                    copRenderer.color = Color.white;
                    FightCopGEM.current.playerWin = true;
                    FightCopGEM.current.GameEnd();
                    yield break;
                }
                copPunched = false;
                copCollider.enabled = false;
            }
            yield return null;
        }

        FightCopGEM.current.CopResumeCombat();
        CopFlash_CoroutineStop();
    }

    private void CopVulnerable_CoroutineStart()
    {
        StartCoroutine(CopVulnerable_Coroutine());
    }

    IEnumerator CopFlash_Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        copRenderer.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        copRenderer.color = Color.white;
        CopFlash_CoroutineStart();
    }

    private void CopFlash_CoroutineStart()
    {
        flashingCoroutine = StartCoroutine(CopFlash_Coroutine());
    }

    private void CopFlash_CoroutineStop()
    {
        copRenderer.color = Color.gray;
        StopCoroutine(flashingCoroutine);
    }

    private void UpdateCopAnimator()
    {
        copAnimator.SetTrigger("DamagedTrigger");
        AudioSource.PlayClipAtPoint(takeDamageAudio, transform.position);
    }

    private void OnMouseDown()
    {
        copPunched = true;
    }
}

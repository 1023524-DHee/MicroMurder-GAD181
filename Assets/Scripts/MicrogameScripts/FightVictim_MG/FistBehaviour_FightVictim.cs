using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBehaviour_FightVictim : MonoBehaviour
{
    private bool playerClicked = false;

    public float timeLimit = 0.8f;
    public AudioClip startPunchClip, punchDeflectedClip, punchLandedClip;

    // Start is called before the first frame update
    void Start()
    {
        DealDamage_CoroutineStart();
    }

    IEnumerator DealDamage()
    {
        AudioSource.PlayClipAtPoint(startPunchClip, transform.position);
        bool succeedClick = false;
        float initialTime = Time.time;

        while ((Time.time < (initialTime + timeLimit)))
        {
            if (playerClicked)
            {
                playerClicked = false;
                succeedClick = true;
                FightVictimGEM.current.PunchClickedSuccess();
                AudioSource.PlayClipAtPoint(punchDeflectedClip, transform.position);
                GetComponent<Animator>().SetTrigger("Deflected");
            }
            yield return null;
        }

        if (!succeedClick)
        {
            FightVictimGEM.current.PlayerTakeDamage();
            AudioSource.PlayClipAtPoint(punchLandedClip, transform.position);
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

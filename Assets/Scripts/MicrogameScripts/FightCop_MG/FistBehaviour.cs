using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBehaviour : MonoBehaviour
{
    private bool playerClicked = false;
    private float timeLimit;

    public AudioClip startPunchClip, punchDeflectedClip, punchLandedClip;

    // Start is called before the first frame update
    void Start()
    {
        timeLimit = FightCopGEM.current.GetCurrentPunchTimeLimit();
        GetComponent<Animator>().speed = 1 / timeLimit;
        DealDamage_CoroutineStart(); 
    }

    IEnumerator DealDamage()
    {
        AudioSource.PlayClipAtPoint(startPunchClip, transform.position);

        bool succeedClick = false;
        float initialTime = Time.time;

        while (Time.time < (initialTime + timeLimit))
        {
            if (playerClicked)
            {
                playerClicked = false;
                succeedClick = true;
                FightCopGEM.current.PunchClickedSuccess();
                AudioSource.PlayClipAtPoint(punchDeflectedClip, transform.position);
                GetComponent<Animator>().SetTrigger("Deflected");
            }
            yield return null;
        }

        if (!succeedClick)
        {
            FightCopGEM.current.PlayerTakeDamage();
            AudioSource.PlayClipAtPoint(punchLandedClip, transform.position);
        }
    }
    private void DealDamage_CoroutineStart()
    {
        StartCoroutine(DealDamage());
    }

    public void DestroyFist()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        playerClicked = true;
    }
}

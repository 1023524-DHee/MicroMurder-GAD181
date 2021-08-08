using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGunGEM : MonoBehaviour
{
    public static ShootGunGEM current;
    public AudioClip gunshotAudio;

    private bool victimDead;

	private void Awake()
	{
        current = this;
        victimDead = false;
	}

    public event Action onVictimShotSuccess;
    public void VictimShotSuccess()
    {
        if (onVictimShotSuccess != null)
        {
            AudioSource.PlayClipAtPoint(gunshotAudio, transform.position);
            onVictimShotSuccess();
        }
    }

    public event Action onVictimShotFail;
    public void VictimShotFail()
    {
        if (onVictimShotFail != null)
        {
            AudioSource.PlayClipAtPoint(gunshotAudio, transform.position);
            onVictimShotFail();
        }
    }

    public event Action onGameEnd;
    public void GameEnd()
    {
        if (onGameEnd != null)
        {
            onGameEnd();
            StartCoroutine(GameEnd_Coroutine());
        }
    }

    IEnumerator GameEnd_Coroutine()
    {
        yield return new WaitForSeconds(2f);
        if (victimDead)
        {
            MicrogameManager.current.LoadNextMicrogame();
        }
        else
        {
            SceneTransitionManager.current.ReloadCurrentScene();
        }
    }

    public void VictimDead(bool deadOrAlive)
    {
        victimDead = deadOrAlive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim_ShootGunMG : MonoBehaviour
{
    private int victimHealth;
    private int currentDirection;
    private float victimSpeed;
    private bool gameEnded;
    private Animator victimAnimator;
    private AudioSource audioSource;

    public GameObject backgroundGO;
    public Transform leftBound, rightBound;
    public List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Start()
    {
        ShootGunGEM.current.onVictimShotSuccess += ChangeVictimAnimation;
        ShootGunGEM.current.onGameEnd += GameEndCleanup;

        victimAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        victimHealth = 4;
        currentDirection = 1;
        victimSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseController.gameIsPaused && !gameEnded)
        {
            RunningLeftRight();
        }       
    }

    private void RunningLeftRight()
    {
        if (transform.position.x >= rightBound.position.x)
        {
            currentDirection = -1;
            RandomDirectionChange_CoroutineStart();
        }
        else if (transform.position.x <= leftBound.position.x)
        {
            currentDirection = 1;
            RandomDirectionChange_CoroutineStart();
        }

        transform.position = new Vector3(transform.position.x + (victimSpeed * currentDirection), transform.position.y, 0);
    }

    private void ChangeVictimAnimation()
    {
        victimHealth--;
        ChangeAudio();
        victimAnimator.SetTrigger("ShotTrigger");
        backgroundGO.GetComponent<Animator>().speed -= 0.25f;
        if (victimHealth <= 0)
        {
            ShootGunGEM.current.VictimDead(true);
            ShootGunGEM.current.GameEnd();
        }
    }

    private void ChangeAudio()
    {
        if (audioClips.Count > 1)
        {
            audioClips.RemoveAt(0);
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
    
    IEnumerator RandomDirectionChange_Coroutine()
    {
        if (Random.Range(0, 10) < 3f)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.35f));
            currentDirection *= -1;
        }
    }

    void RandomDirectionChange_CoroutineStart()
    {
        StartCoroutine(RandomDirectionChange_Coroutine());
    }

    private void GameEndCleanup()
    {
        gameEnded = true;
    }
}

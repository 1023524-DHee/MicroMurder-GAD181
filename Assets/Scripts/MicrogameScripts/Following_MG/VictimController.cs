using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TEST : MonoBehaviour
{
    [SerializeField]
    public Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;
    private bool shouldMove = true;

    private bool delayed;
    public Animator animator;

    public AudioClip footsteps;
    public AudioClip huh;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Delayed", delayed);

        if (this.shouldMove)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            StartCoroutine(WaitAtPoint(3));
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 1;
        }
    }

    IEnumerator WaitAtPoint(int seconds)
    {
        this.shouldMove = false;
        delayed = true;
        //audio.Play(0);

        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        this.shouldMove = true;
        delayed = false;
        audio.Play(0);
    }
}

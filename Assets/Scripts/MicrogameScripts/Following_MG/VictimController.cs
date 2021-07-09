using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictimController : MonoBehaviour
{
    public Vector2[] points;
    public int pointNumber = 0;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed; // how fast the victim moves
    public float delayTimer; // how long the victim waits after stopping

    private float delayStart;
    private bool delayed;

    // should the platform move on its own
    public bool automatic;

    public Animator animator;

    void Start()
    {
        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePosition();
        }
        else
        {
            UpdateTarget();
        }
    }

    void Update()
    {
        animator.SetBool("Delayed", delayed);
    }

    // moves to the next position
    void MovePosition()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayed = true;
            delayStart = Time.time;
        }
    }

    // automatically moves to next platform
    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delayStart > delayTimer)
            {
                delayed = false;
                NextPosition();
            }
        }
    }

    public void NextPosition()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            print("Caught");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

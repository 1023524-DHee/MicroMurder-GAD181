using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedMovement : MonoBehaviour
{
    private Transform movePosition;
    private float moveSpeed;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (movePosition == null) return;

        Vector3 dir = (movePosition.transform.position - transform.position).normalized;
        rigidbody.MovePosition(transform.position + dir * 200f * Time.deltaTime);  // wait a certain amount of time before moving to new point

    }

    public void ChangeWaypoint(Transform newWaypoint)
    {
        movePosition = newWaypoint;  // Move to new waypoint
    }

    public void ChangeSpeed(float newSpeed)
    {
        moveSpeed = newSpeed; // change speed
    }
}

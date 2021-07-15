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

    private void FixedUpdate()
    {
        if (movePosition == null) return;

        Vector3 dir = (movePosition.transform.position - transform.position).normalized;
        rigidbody.MovePosition(transform.position + dir * 200f * Time.fixedDeltaTime);

    }

    public void ChangeWaypoint(Transform newWaypoint)
    {
        movePosition = newWaypoint;
    }

    public void ChangeSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public enum Axis { Y_AXIS }

    public Axis axis;
    public float moveDistance;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        switch (this.axis)
        {
            case Axis.Y_AXIS:
                moveDirection = this.transform.up;
                break;
        }
        this.transform.position += moveDirection * Time.deltaTime * this.moveDistance * Mathf.Sin(Time.time * this.moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}

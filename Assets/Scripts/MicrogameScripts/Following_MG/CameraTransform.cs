using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Update()
    {
        offset = new Vector3(9.08f, 0f, 0f);
        transform.position = new Vector3(target.position.x, 0, -20) + offset;
    }
}


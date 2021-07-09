using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(followTarget.position.x, -0.5f, 25f), Mathf.Clamp(followTarget.position.y, 0f, 0f), Mathf.Clamp(followTarget.position.z, -20f, -20f));
    }
}

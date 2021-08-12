using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ChaseSt : MonoBehaviour
{
    public float maxHeight, minHeight;
    public float playerSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y + (Input.GetAxis("Mouse ScrollWheel") * playerSpeed), minHeight, maxHeight), 0);
    }
}

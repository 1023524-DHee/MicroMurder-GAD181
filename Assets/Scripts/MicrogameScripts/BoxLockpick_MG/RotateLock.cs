using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLock : MonoBehaviour
{
    private Vector3 screenPos;
    private float angleOffset;

    public AudioClip clickSound;

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    // Courtesy of this video https://www.youtube.com/watch?v=0eM5molItfE
    private void Rotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 vec3 = Input.mousePosition - screenPos;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            AudioSource.PlayClipAtPoint(clickSound, transform.position);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 vec3 = Input.mousePosition - screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
        }
    }
}

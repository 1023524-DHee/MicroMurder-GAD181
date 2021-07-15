using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObjectToMouse : MonoBehaviour
{
    public Transform axeTransform;
    private Vector3 mouseScreenPosition;

    void Update()
    {
        mouseScreenPosition = Input.mousePosition;
        axeTransform.position = mouseScreenPosition;
    }
}

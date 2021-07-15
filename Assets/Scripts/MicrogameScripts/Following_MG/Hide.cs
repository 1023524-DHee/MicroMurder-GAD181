using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isOnPath = false;
    private bool inTriggerBox;

    public void MoveToHide()
    {
        transform.GetComponent<PlayerController>().Stop();
        originalPosition = transform.position;
        transform.position = new Vector3(transform.position.x, -2.3f, 0);
        isOnPath = false;
    }

    public void MoveToPath()
    {
        transform.position = new Vector3(transform.position.x, -3.8f, 0);
        isOnPath = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("HideBoxes"))
        {
            inTriggerBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HideBoxes"))
        {
            inTriggerBox = false;
        }
    }

    void OnMouseDown()
    {
        if(inTriggerBox && !isOnPath)
        {
            MoveToPath();
        }
    }

    void OnMouseUp()
    {
        if (inTriggerBox && isOnPath)
        {
            MoveToHide();
        }
    }
}

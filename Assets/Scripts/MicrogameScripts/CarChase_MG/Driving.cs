using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    public bool hasBounds;
    public float xMin, xMax, yMin, yMax;
    public float speed = 1f;

    private Vector2 cursorPos;

    void Awake()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        if (hasBounds)
        {
            MoveMouseWithBounds();
        }
        else
        {
            MoveMouseNoBounds();
        }


    }

    void MoveMouseNoBounds()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
        }
    }

    void MoveMouseWithBounds()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, new Vector2(Mathf.Clamp(cursorPos.x, xMin, xMax), Mathf.Clamp(cursorPos.y, yMin, yMax)), speed);
    }
}


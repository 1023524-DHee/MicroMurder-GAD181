using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool hasBounds;
    public float xMin, xMax, yMin, yMax;


    private Vector2 cursorPos;

    void Awake()
    {
        Cursor.visible = false;  // takes away cursor on play
    }


    void Update()
    {
        if(hasBounds)
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
            Cursor.visible = true;  // displays cursor
        }
    }

    void MoveMouseWithBounds()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // camera follows mouse position
        transform.position = new Vector2(Mathf.Clamp(cursorPos.x, xMin, xMax), Mathf.Clamp(cursorPos.y, yMin, yMax)); // sets boundries for mouse
    }
}


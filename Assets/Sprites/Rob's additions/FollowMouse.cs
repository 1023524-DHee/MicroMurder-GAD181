using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = true;
        }
    }
}


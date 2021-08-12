using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        if(Time.timeSinceLevelLoad >= 18f)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }    
    }
}

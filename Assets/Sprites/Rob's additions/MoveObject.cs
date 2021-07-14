using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform[] Position;
    public int ObjectSpeed;
    
    
    int NextPosIndex;

    Transform NextPos;
    // Start is called before the first frame update
    void Start()
    {
        NextPos = Position[0];
        StartCoroutine(MoveGameObject_Gamecoroutine());
    }
    IEnumerator MoveGameObject_Gamecoroutine()
    {
        NextPosIndex++;
        if (NextPosIndex >= Position.Length)
        {
            NextPosIndex = 0;
        }
        NextPos = Position[NextPosIndex];
        transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        StartCoroutine(MoveGameObject_Gamecoroutine());

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    Transform[] Position;
    public int ObjectSpeed;
    public List<GameObject> positionPool;

    int NextPosIndex;
    Transform NextPos;
    // Start is called before the first frame update
    void Start()
    {
        NextPos = Position[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
     
        
            NextPosIndex++;
            if (NextPosIndex >= Position.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Position[NextPosIndex];
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        


    }
    
}
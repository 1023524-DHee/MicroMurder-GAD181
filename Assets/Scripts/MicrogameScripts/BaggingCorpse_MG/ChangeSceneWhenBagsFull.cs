using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneWhenBagsFull : MonoBehaviour
{
    public int bodyPartInt;
    bool bagsFull = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        TransitionScene();
    }

    void TransitionScene()
    {
        if (bodyPartInt == 12 && bagsFull == false)
        {
            MicrogameManager.current.LoadNextMicrogame();
            bagsFull = true;
        }
    }
}

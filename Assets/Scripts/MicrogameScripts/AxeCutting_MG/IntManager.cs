using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int cutInt = 0;
    bool isCut = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TransitionScene();
    } 

    void TransitionScene()
    {
        if (cutInt == 5 && isCut == false)
        {
            MicrogameManager.current.LoadNextMicrogame();
            isCut = true;
        }
    }
}  

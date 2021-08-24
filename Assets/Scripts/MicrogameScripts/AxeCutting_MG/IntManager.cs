using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int cutInt = 0;
    bool isCut = false;

    // Update is called once per frame
    void Update()
    {
        TransitionScene();
    } 

    void TransitionScene()
    {
        if (cutInt == 5 && isCut == false)
        {
            StartCoroutine(Transition_Coroutine());
            isCut = true;
        }
    }

    IEnumerator Transition_Coroutine()
    {
        yield return new WaitForSeconds(2f);
        MicrogameManager.current.LoadNextMicrogame();
    }
}  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private bool triggered;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 0)
        {
            TriggerCreditsEnd();
        }
    }

    private void TriggerCreditsEnd()
    {
        if (!triggered)
        {
            print("EDN");
            EndSceneGEM.current.GameEnd();
            triggered = true;
        }
        
    }
}

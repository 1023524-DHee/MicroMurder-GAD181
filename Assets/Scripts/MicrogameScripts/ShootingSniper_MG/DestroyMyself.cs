using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
 
    public static DestroyMyself current;
    public void DestroyFunction(GameObject objectToDestroy)

    {
        Cursor.visible = true;
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.SetActive(false);
        MicrogameManager.current.LoadNextMicrogame();
    }

    void Start()
    {
        
        current = this;
        
    }
}
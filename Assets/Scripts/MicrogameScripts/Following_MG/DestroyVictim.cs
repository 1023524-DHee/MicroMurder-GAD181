using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVictim : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Victim")
        {
            Destroy(col.gameObject);
        }
    }
}

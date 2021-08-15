using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShot : MonoBehaviour
{
    [SerializeField]
    private Gun_ShootGunMG gunScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Victim"))
        {
            gunScript.SetShotStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Victim"))
        {
            gunScript.SetShotStatus(false);
        }
    }

}

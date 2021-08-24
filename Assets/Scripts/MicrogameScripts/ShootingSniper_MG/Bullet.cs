using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private GameObject PlayerGO;
    private bool canFire = false;
    private bool alreadyFired = false;

    void Update()
    {
        if (!alreadyFired)
        {
            if (Input.GetMouseButtonDown(0) && canFire && PlayerGO != null)
            {
                GetComponent<AudioSource>().Play();
                // Call DestroyMyself function
                DestroyMyself.current.DestroyFunction(PlayerGO);
                alreadyFired = true;
            }
            else if (Input.GetMouseButtonDown(0) && !canFire)
            {
                GetComponent<AudioSource>().Play();
                SceneTransitionManager.current.ReloadCurrentScene();
                alreadyFired = true;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canFire = true;
            PlayerGO = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canFire = false;
            PlayerGO = null;
        }
    }
}
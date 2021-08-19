using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private GameObject PlayerGO;
    private bool canFire = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire && PlayerGO != null)
        {

            // Call DestroyMyself function
            DestroyMyself.current.DestroyFunction(PlayerGO);
        }
        else if (Input.GetMouseButtonDown(0) && !canFire)
        {
            GetComponent<AudioSource>().Play();
            SceneTransitionManager.current.ReloadCurrentScene();
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
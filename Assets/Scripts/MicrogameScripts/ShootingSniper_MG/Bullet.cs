using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private GameObject PlayerGO;
    private Vector2 direction;
    private Vector3 mousePosition;

    private bool canFire = false;

    void Start()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = direction.normalized;
    }

    void Update()
    {
        transform.position = direction * speed * Time.deltaTime;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && canFire && PlayerGO != null)
        {
           
            // Call DestroyMyself function
            DestroyMyself.current.DestroyFunction(PlayerGO);
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
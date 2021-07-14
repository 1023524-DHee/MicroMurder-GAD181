using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private Vector2 direction;

    void Start()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = direction.normalized;
    }

    void Update()
    {
        transform.position = direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
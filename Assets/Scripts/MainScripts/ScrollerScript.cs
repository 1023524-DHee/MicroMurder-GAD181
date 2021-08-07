using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private float height;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -height)
        {
            Vector2 vector = new Vector2(height * 2f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
    }
}

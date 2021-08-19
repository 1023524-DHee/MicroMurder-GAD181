using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollDirection
{
    X_AXIS,
    Y_AXIS
}

public class ScrollerScript : MonoBehaviour
{
    private BoxCollider2D collider;
    private Rigidbody2D rb;
    private float width, height;

    public bool loop;
    public float speed;
    public ScrollDirection scrollDirection;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        switch (scrollDirection)
        {
            case ScrollDirection.X_AXIS:
                width = collider.size.x;
                rb.velocity = new Vector2(speed, 0);
                break;
            case ScrollDirection.Y_AXIS:
                height = collider.size.y;
                rb.velocity = new Vector2(0, speed);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (scrollDirection)
        {
            case ScrollDirection.X_AXIS:
                if (transform.position.x < -width && loop)
                {
                    Vector2 vector = new Vector2(width * 2f, 0);
                    transform.position = (Vector2)transform.position + vector;
                }
                break;
            case ScrollDirection.Y_AXIS:
                if (transform.position.y < -height && loop)
                {
                    Vector2 vector = new Vector2(0, height * 2f);
                    transform.position = (Vector2)transform.position + vector;
                }
                break;
        }
        
    }
}

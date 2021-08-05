using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
        StartCoroutine(DestroyCop_Coroutine());
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
    }

    IEnumerator DestroyCop_Coroutine()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}

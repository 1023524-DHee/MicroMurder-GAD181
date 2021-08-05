using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cops : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
        StartCoroutine(DestroyCop_Coroutine());
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
    }

    IEnumerator DestroyCop_Coroutine()
    {
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}

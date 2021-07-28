using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cops : MonoBehaviour
{
    public float speed = 1f;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(DestroyCop_Coroutine());
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
    }

    IEnumerator DestroyCop_Coroutine()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject, 1f);
    }

    IEnumerator TriggerActions(Collider2D col)
    {
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        Destroy(col.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit!"); 
            StartCoroutine(TriggerActions(col));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

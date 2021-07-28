using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public float speed = 1f;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(DestroyObject_Coroutine());
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        transform.Translate (Vector2.down * speed * Time.deltaTime, Space.World);
    }
    
    IEnumerator DestroyObject_Coroutine()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject, 1);
    }

    IEnumerator TriggerActions(Collider2D col)
    {
        audioSource.Play();
        //Destroy(col.gameObject);
        yield return new WaitForSeconds(2f);

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(TriggerActions(col));
    }
}

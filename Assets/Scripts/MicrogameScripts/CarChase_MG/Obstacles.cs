using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public float speed = 1f;
    
    void Start()
    {
        StartCoroutine(DestroyObject_Coroutine());
    }
    
    void Update()
    {
        transform.Translate (Vector2.down * speed * Time.deltaTime, Space.World);
    }
    
    IEnumerator DestroyObject_Coroutine()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

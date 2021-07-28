using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class RoadBlock : MonoBehaviour
{
    public float speed = 1f;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad >= 18f)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }    
    }

    IEnumerator TriggerActions(Collider2D col)
    {
        audioSource.Play();
        //Destroy(col.gameObject);
        yield return new WaitForSeconds(2f);

        if (col.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            MicrogameManager.current.LoadNextMicrogame();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(TriggerActions(col));
    }
}

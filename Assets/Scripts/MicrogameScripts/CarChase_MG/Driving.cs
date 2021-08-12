using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driving : MonoBehaviour
{
    public bool hasBounds;
    public float xMin, xMax, yMin, yMax;
    public float speed = 1f;

    public AudioClip crashSound;

    private Vector2 cursorPos;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, new Vector2(Mathf.Clamp(cursorPos.x, xMin, xMax), Mathf.Clamp(cursorPos.y, yMin, yMax)), speed);
    }

    IEnumerator Crash()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().enabled = false;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Finish()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().enabled = false;

        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        MicrogameManager.current.LoadNextMicrogame();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacles"))
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position, 0.4f);

            Debug.Log("Oops!");
            StartCoroutine(Crash());
        }
        else if (col.CompareTag("Finish"))
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position, 0.4f);

            Debug.Log("Damn!");
            StartCoroutine(Finish());
        }
    }
}


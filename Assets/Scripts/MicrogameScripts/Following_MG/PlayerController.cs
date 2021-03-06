using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool moving;
    private int currentDirection;

    public static PlayerController current;

    public Animator animator;

    public new AudioSource audio;


    void Start()
    {
        current = this;
        moving = false;
        currentDirection = 1;
        Invoke("EnableBoxCollider", 4f);
    }

    void Update()
    {
        if (moving)
        {
            transform.position += new Vector3(Time.deltaTime* 3, 0, 0);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MicrogameManager.current.LoadNextMicrogame();
        //}
        
        animator.SetBool("Moving", moving);
    }
    
    void EnableBoxCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Move(int direction)
    {
        moving = true;
        audio.Play(0);

        if(currentDirection < 0 && direction > 0)
        {
            currentDirection = 1;
        }
    }

    public void Stop()
    {
        moving = false;
        audio.Stop();
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.CompareTag("Victim"))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}
}

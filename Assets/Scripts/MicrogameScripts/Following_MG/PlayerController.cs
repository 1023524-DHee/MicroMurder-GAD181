using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

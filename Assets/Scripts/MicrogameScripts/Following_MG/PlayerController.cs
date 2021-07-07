using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool moving;
    private int currentDirection;

    public Animator animator;

    void Start()
    {
        moving = false;
        currentDirection = 1;
    }

    void Update()
    {
        if (moving)
        {
            this.transform.Translate(new Vector2(Time.deltaTime * 2, 0));
        }

        animator.SetBool("Moving", moving);

    }
    
    public void Move(int direction)
    {
        moving = true;

        if(currentDirection < 0 && direction > 0)
        {
            currentDirection = 1;
        }
    }

    public void Stop()
    {
        moving = false;
    }
}

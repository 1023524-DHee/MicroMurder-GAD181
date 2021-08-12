using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropBodyParts : MonoBehaviour
{
    public GameObject correctPosition;
    //public AudioClip textPickupClip, textPlacedClip, textPlacedFailClip;
    public Animator bagAnimator;

    private bool moving;
    private bool inPosition;

    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPosition)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startPosX = mousePos.x - transform.position.x;
        startPosY = mousePos.y - transform.position.y;

        moving = true;
       

        StartFlash();
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(transform.position.x - correctPosition.transform.position.x) <= 2f &&
           Mathf.Abs(transform.position.y - correctPosition.transform.position.y) <= 1f)
        {
            transform.position = new Vector3(correctPosition.transform.position.x, correctPosition.transform.position.y, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            inPosition = true;

            
            

            StopFlash();
        }
        else
        {
            transform.position = resetPosition;
            

            StopFlash();
        }
    }

    void StartFlash()
    {
        bagAnimator.enabled = true;
    }

    void StopFlash()
    {
        bagAnimator.enabled = false;
        correctPosition.GetComponent<SpriteRenderer>().color = Color.white;
    }
} 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
    public GameObject correctPosition;
    public AudioClip textPickupClip, textPlacedClip, textPlacedFailClip;
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
        AudioManager.current.PlaySound(textPickupClip);

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

            DisclaimerEventManager.current.TextPlaced();
            AudioManager.current.PlaySound(textPlacedClip);

            StopFlash();
        }
        else
        {
            transform.position = resetPosition;
            AudioManager.current.PlaySound(textPlacedFailClip);

            StopFlash();
        }
    }
    
    void StartFlash()
    {
        if (bagAnimator == null) return;
        bagAnimator.enabled = true;
        //bagAnimator.SetBool("Flash", true);
        Debug.Log("flashing");
    } 

    void StopFlash()
    {
        if (bagAnimator == null) return;
        bagAnimator.enabled = false;
        //bagAnimator.SetBool("Flash", false);
        Debug.Log("not flashing");
    }
} 

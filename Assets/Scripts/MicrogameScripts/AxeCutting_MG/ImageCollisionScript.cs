using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCollisionScript : MonoBehaviour
{
    bool inBodyPart = false;
    public Sprite BodyPartCut;
    public GameObject managerObject;
    public GameObject chargeBar;
    public AudioClip cutClip;

    void Update()
    {
        if (inBodyPart == true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if(chargeBar.GetComponent<ChargeBar>().chargeBarAmount == 11f)
                {
                    if(gameObject.GetComponent<SpriteRenderer>().sprite == BodyPartCut)
                    {
                        Debug.Log("You've alredy cut this body part.");
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = BodyPartCut;
                        managerObject.GetComponent<IntManager>().cutInt++;
                        AxeCuttingAudioManager.current.PlaySound(cutClip);
                    }

                }
                 
            }
            
        }
    }

    void OnMouseEnter()
    {
        inBodyPart = true;
    }

    void OnMouseExit()
    {
        inBodyPart = false;
    }
}

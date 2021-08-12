using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCollisionScript : MonoBehaviour
{
    bool inBodyPart = false;
    public Sprite BodyPartCut;
    public GameObject managerObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (inBodyPart == true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                    
                gameObject.GetComponent<SpriteRenderer>().sprite = BodyPartCut;
                managerObject.GetComponent<IntManager>().cutInt++;
                
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

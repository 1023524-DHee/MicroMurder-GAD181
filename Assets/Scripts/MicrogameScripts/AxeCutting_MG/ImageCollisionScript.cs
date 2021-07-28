using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCollisionScript : MonoBehaviour
{
    bool inBodyPart = false;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) print("ASD");

        if (inBodyPart == true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //slash and change body part sprite
                print("chop chop");
            }



        }



    }

  
    void OnMouseEnter()
    {
        inBodyPart = true;
        print("You've collided with the image");
    }

    void OnMouseExit()
    {
        inBodyPart = false;


    }




}

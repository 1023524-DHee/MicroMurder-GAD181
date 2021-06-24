using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    private float chargeBarAmount;
    public List<Sprite> chargeBarSprites = new List<Sprite>();
    
    void Start()
    {
        chargeBarAmount = 0f;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            chargeBarAmount++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            chargeBarAmount--;
        }
        ChargeBarImageChange();
    }

    
    

    void ChargeBarImageChange()
    {
        switch(chargeBarAmount)
        {
            case 0:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[0];
                break;

            case 1:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[1];
                break;

            case 2:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[2];
                break;

            case 3:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[3];
                break;

            case 4:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[4];
                break;

            case 5:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[5];
                break;

            case 6:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[6];
                break;

            case 7:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[7];
                break;

            case 8:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[8];
                break;

            case 9:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[9];
                break;

            case 10:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[10];
                break;

            case 11:
                gameObject.GetComponent<Image>().sprite = chargeBarSprites[11];
                break;
        }
         
       
    }
    
    void ChargeBarFlash()
    {
        while (gameObject.GetComponent<Image>().sprite = chargeBarSprites[11])
        {


        }


    }






}



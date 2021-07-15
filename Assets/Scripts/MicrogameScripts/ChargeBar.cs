using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public float chargeBarAmount;
    public List<Sprite> chargeBarSprites = new List<Sprite>();
    public Animator chargeBarAnimator;

    void Start()
    {
        chargeBarAmount = 0f;

    }

    void Update()
    {
        if (chargeBarAmount != 0f)
        {
            StartCoroutine("DecreaseChargeCoroutine");
        }

        ChargeBarImageChange();

        if (chargeBarAmount < 11f)
        {
            StopFlash();
        }
        if (chargeBarAmount == 0f)
        {
            StopCoroutine("DecreaseChargeCoroutine");
        }


    }
    
    public void IncreaseCharge()
    {
        chargeBarAmount++;
    }
    public void DecreaseCharge()
    {
        chargeBarAmount--;
    }

    void ChargeBarImageChange()
    {
        switch (chargeBarAmount)
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
                StartFlash();
                break;
        }

         
    }
    
    IEnumerator DecreaseChargeCoroutine()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            while (chargeBarAmount > 0) 
            {
                DecreaseCharge();
                yield return null;
            }
           
        }
        
        //DecreaseCharge();
        yield return null;
    }
    
    void StartFlash()
    {
        chargeBarAnimator.enabled = true;
        chargeBarAnimator.SetBool("Flash", true);
    }

    void StopFlash()
    {
        chargeBarAnimator.enabled = false;
        chargeBarAnimator.SetBool("Flash", false);
    }
}


    
    

    










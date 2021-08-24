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
        if (Input.GetMouseButton(0))
        {
            IncreaseCharge();
        }
        else
        {
            DecreaseCharge();
        }

        ChargeBarImageChange();
    }

    private void IncreaseCharge()
    {
        chargeBarAmount = Mathf.Clamp(chargeBarAmount+= 1, 0f, 110f);
    }

    private void DecreaseCharge()
    {
        chargeBarAmount = Mathf.Clamp(chargeBarAmount-= 1, 0f, 110f);
    }

    void ChargeBarImageChange()
    {
        if(chargeBarAmount == 0f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[0];
        if(chargeBarAmount > 0f && chargeBarAmount < 9f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[1];
        if(chargeBarAmount > 9f && chargeBarAmount < 19f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[2];
        if(chargeBarAmount > 19f && chargeBarAmount < 29f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[3];
        if(chargeBarAmount > 29f && chargeBarAmount < 39f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[4];
        if(chargeBarAmount > 39f && chargeBarAmount < 49f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[5];
        if(chargeBarAmount > 49f && chargeBarAmount < 59f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[6];
        if(chargeBarAmount > 59f && chargeBarAmount < 69f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[7];
        if(chargeBarAmount > 69f && chargeBarAmount < 79f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[8];
        if(chargeBarAmount > 79f && chargeBarAmount < 89f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[9];
        if(chargeBarAmount > 89f && chargeBarAmount < 99f) gameObject.GetComponent<Image>().sprite = chargeBarSprites[10];
        if (chargeBarAmount >= 100f) StartFlash();
        else StopFlash();


        //switch (chargeBarAmount)
        //{
        //    case 0:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[0];
        //        break;

        //    case 10:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[1];
        //        break;

        //    case 20:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[2];
        //        break;

        //    case 30:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[3];
        //        break;

        //    case 40:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[4];
        //        break;

        //    case 50:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[5];
        //        break;

        //    case 60:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[6];
        //        break;

        //    case 70:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[7];
        //        break;

        //    case 80:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[8];
        //        break;

        //    case 90:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[9];
        //        break;

        //    case 100:
        //        gameObject.GetComponent<Image>().sprite = chargeBarSprites[10];
        //        break;

        //    case 11:
        //        StartFlash();
        //        break;
        //}

         
    }
    
    //UNUSED
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


    
    

    










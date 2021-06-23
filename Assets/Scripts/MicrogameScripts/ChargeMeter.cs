using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : MonoBehaviour
{

    public Slider slider;
    
    public void SetMaxCharge(int charge)
    {
        slider.maxValue = charge;
        slider.value = charge;
    }

    public void SetCharge (int charge)
    {
        slider.value = charge;
    }


}



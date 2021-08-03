using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth_Trial : MonoBehaviour
{
    public Image healthBarImage;
    public float damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        TrialGEM.current.onCorrectResponseClicked += GainHealth;
        TrialGEM.current.onWrongResponseClicked += TakeDamage;
    }


    private void TakeDamage()
    {
        healthBarImage.fillAmount -= damageAmount;
        Camera.main.GetComponent<ScreenShake>().TriggerShake();
    }

    private void GainHealth()
    {
        healthBarImage.fillAmount += damageAmount;
    }
}

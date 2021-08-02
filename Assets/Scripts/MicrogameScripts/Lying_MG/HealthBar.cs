using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        LyingGEM.current.onHealthBarUpdate += TakeDamage;
        LyingGEM.current.onGameEnd += GameEndCleanup;
    }

    //public void TakeDamage(bool damageTaken)
    //{
    //    float currentPointerYPosition = healthBarPointer.position.y;
    //    float damageAmount = 10f;

    //    if (damageTaken)
    //    {
    //        damageAmount *= -1;
    //        Camera.main.GetComponent<ScreenShake>().TriggerShake();
    //    }

    //    healthBarPointer.position = new Vector3(healthBarPointer.position.x, Mathf.Clamp(currentPointerYPosition + damageAmount, bottomLimitPosition, topLimitPosition));
    //}

    public void TakeDamage(bool damageTaken)
    {
        if (damageTaken)
        {
            healthBarImage.fillAmount -= damageAmount;
            Camera.main.GetComponent<ScreenShake>().TriggerShake();
        }
        else
        {
            healthBarImage.fillAmount += damageAmount;
        }
    }

    private void GameEndCleanup()
    {
        LyingGEM.current.SetFinalPlayerHealth(healthBarImage.fillAmount);
    }
}

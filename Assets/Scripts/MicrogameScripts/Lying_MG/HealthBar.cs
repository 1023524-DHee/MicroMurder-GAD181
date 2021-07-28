using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float topLimitPosition, bottomLimitPosition;

    public Transform topLimit, bottomLimit;
    public Transform healthBarPointer;

    // Start is called before the first frame update
    void Start()
    {
        topLimitPosition = topLimit.position.y;
        bottomLimitPosition = bottomLimit.position.y;
        healthBarPointer.position = new Vector3(healthBarPointer.position.x, ((topLimitPosition - bottomLimitPosition) / 2) + bottomLimitPosition);

        LyingGEM.current.onHealthBarUpdate += TakeDamage;
    }

    public void TakeDamage(bool damageTaken)
    {
        float currentPointerYPosition = healthBarPointer.position.y;
        float damageAmount = 10f;

        if (damageTaken)
        {
            damageAmount *= -1;
            Camera.main.GetComponent<ScreenShake>().TriggerShake();
        }

        healthBarPointer.position = new Vector3(healthBarPointer.position.x, Mathf.Clamp(currentPointerYPosition + damageAmount, bottomLimitPosition, topLimitPosition));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar current;

    private float topLimitPosition, bottomLimitPosition;

    public Transform topLimit, bottomLimit;
    public Transform healthBarPointer;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        topLimitPosition = topLimit.position.y;
        bottomLimitPosition = bottomLimit.position.y;
        healthBarPointer.position = new Vector3(healthBarPointer.position.x, ((topLimitPosition - bottomLimitPosition) / 2) + bottomLimitPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow)) TakeDamage(false);

        //if (Input.GetKey(KeyCode.DownArrow)) TakeDamage(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ShootGunMG : MonoBehaviour
{
    public float maxSpeed;
    public float maxShakeAmount;

    private float currentSpeed;
    private float currentShakeAmount;
    private bool canShoot;
    private bool gameEnded;

	private void Start()
	{
        ShootGunGEM.current.onGameEnd += GameEndedCleanup;

        Cursor.visible = false;
        currentShakeAmount = maxShakeAmount;
        currentSpeed = maxSpeed;
	}

	// Update is called once per frame
	void Update()
    {
        if (!PauseController.gameIsPaused && !gameEnded)
        {
            MouseAim();
        }
    }

    void MouseAim()
    {
        if (Input.GetMouseButton(0))
        {
            currentSpeed = Mathf.Clamp(currentSpeed - 0.01f, 1f, maxSpeed);
            currentShakeAmount = Mathf.Clamp(currentShakeAmount - 0.01f, 1f, maxShakeAmount);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (canShoot)
            {
                ShootGunGEM.current.VictimShotSuccess();
            }
            else
            {
                ShootGunGEM.current.VictimShotFail();
            }
            currentSpeed = maxSpeed;
            currentShakeAmount = maxShakeAmount;
        }
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x + Mathf.Sin(Time.time * currentSpeed) * currentShakeAmount, cursorPos.y + Mathf.Sin(Time.time * currentSpeed) * currentShakeAmount);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Victim"))
        {
            canShoot = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.CompareTag("Victim"))
        {
            canShoot = false;
        }
    }

    private void GameEndedCleanup()
    {
        gameEnded = true;
    }
}

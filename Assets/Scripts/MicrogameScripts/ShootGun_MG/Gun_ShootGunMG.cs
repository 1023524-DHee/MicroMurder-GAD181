using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ShootGunMG : MonoBehaviour
{
    public float maxSpeed;
    public float maxShakeAmount;

    private float currentSpeed;
    private float percentageSlowdown;
    private bool canShoot;
    private bool gameEnded;

	private void Start()
	{
        ShootGunGEM.current.onGameEnd += GameEndedCleanup;

        Cursor.visible = false;
        currentSpeed = maxSpeed;
        percentageSlowdown = 100;
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
			percentageSlowdown = Mathf.Clamp(percentageSlowdown - 0.1f, 0, 100);
			currentSpeed = Mathf.Clamp(maxSpeed * percentageSlowdown / 100f, 1f, maxSpeed);
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
			percentageSlowdown = 100f;
		}

		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.Rotate(0, 0, 1 * currentSpeed);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }

    public void SetShotStatus(bool shotBool)
    {
        canShoot = shotBool;
    }

    private void GameEndedCleanup()
    {
        gameEnded = true;
    }
}

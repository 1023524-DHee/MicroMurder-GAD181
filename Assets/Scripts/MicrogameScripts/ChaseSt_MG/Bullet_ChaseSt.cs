using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ChaseSt : MonoBehaviour
{
    private bool playerCanBeShot;

    public int bulletID;

    // Start is called before the first frame update
    void Start()
    {
        ChaseStGEM.current.onShootBullet += ShootBullet;
    }

    private void ShootBullet(int thisID)
    {
        if (bulletID == thisID)
        {
            if (playerCanBeShot)
            {
                ChaseStGEM.current.PlayerShotSuccess();
                print("SHOT");
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            playerCanBeShot = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            playerCanBeShot = false;
        }
	}
}

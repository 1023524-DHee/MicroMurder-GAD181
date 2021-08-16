using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ChaseSt : MonoBehaviour
{
    private bool gameEnd;

    public float maxHeight, minHeight;
    public float playerSpeed;

	private void Start()
	{
        ChaseStGEM.current.onGameEnd += GameEndCleanup;
	}

	// Update is called once per frame
	void Update()
    {
        if (!gameEnd)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + (Input.GetAxis("Mouse ScrollWheel") * playerSpeed), minHeight, maxHeight), 0);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + playerSpeed * Time.deltaTime, Mathf.Clamp(transform.position.y + (Input.GetAxis("Mouse ScrollWheel") * playerSpeed), minHeight, maxHeight), 0);
        }
    }

    void GameEndCleanup()
    {
        gameEnd = true;
    }
}

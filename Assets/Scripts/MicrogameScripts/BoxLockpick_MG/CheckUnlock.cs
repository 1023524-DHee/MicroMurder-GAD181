using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUnlock : MonoBehaviour
{
	private bool canUnlock = false;

	public AudioClip triggerSound, unlockedSound;

	private void Update()
	{
		if (Input.GetMouseButtonUp(0) && canUnlock)
		{
			AudioSource.PlayClipAtPoint(unlockedSound, transform.position);
			BoxLockpick_GEM.current.CorrectLockPositionEntered();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("LockCheck"))
		{
			canUnlock = true;
			AudioSource.PlayClipAtPoint(triggerSound, transform.position);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("LockCheck" +
			""))
		{
			canUnlock = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAudio : MonoBehaviour
{
	public AudioClip clickSound;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("LockCheck"))
		{
			AudioSource.PlayClipAtPoint(clickSound, transform.position);
		}
	}
}

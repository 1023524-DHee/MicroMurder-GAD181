using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopShutter : MonoBehaviour
{
	private Animator shopAnimator;

	public static ShopShutter current;

	private void Start()
	{
		current = this;
		shopAnimator = GetComponent<Animator>();
	}

	public void PlayAnimation()
	{
		shopAnimator.SetTrigger("OpenDoor");
	}
}

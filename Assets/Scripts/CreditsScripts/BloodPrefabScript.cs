using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPrefabScript : MonoBehaviour
{
	public string effectName;

	private void Start()
	{
		GetComponent<Animator>().SetTrigger(effectName);

	}
}

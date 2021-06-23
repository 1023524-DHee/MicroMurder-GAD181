using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
	private void Start()
	{
	}

	public void ChangeObjectColour(Color colourToChange)
    {
		GetComponent<SpriteRenderer>().color = colourToChange;
    }
}

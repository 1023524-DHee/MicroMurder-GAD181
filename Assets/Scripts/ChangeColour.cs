using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
	private void Start()
	{
		EventManager.current.onObjectMouseBehaviour += ChangeObjectColour;
	}

	public void ChangeObjectColour(Color colourToChange)
    {
		GetComponent<SpriteRenderer>().color = colourToChange;
    }
}

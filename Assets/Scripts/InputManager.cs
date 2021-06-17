using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
	private static float timeSinceClick;

	private void Update()
	{
		if (Input.GetMouseButtonUp(0)) // Left Up
		{
			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.green);
		}
		else if (Input.GetMouseButtonUp(1)) // Right Up
		{
			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.yellow);
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0)) // Left Down
		{
			timeSinceClick = Time.time;

			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.red);
		}
		else if (Input.GetMouseButtonDown(1)) // Right Down
		{
			timeSinceClick = Time.time;

			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.blue);
		}
		else if (Input.GetMouseButton(0) && Time.time - timeSinceClick > 0.1f) // Left Drag
		{
			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.black);
		}
		else if (Input.GetMouseButton(1) && Time.time - timeSinceClick > 0.1f) // Right Drag
		{
			//EDIT FROM HERE ON
			EventManager.current.ObjectMouseBehaviour(Color.grey);
		}
	}
}

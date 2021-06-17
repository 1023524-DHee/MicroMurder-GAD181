using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicrogameInputManager : MonoBehaviour
{
    public UnityEvent leftClickDown;
    public UnityEvent leftClickUp;
    public UnityEvent leftClickDrag;
    public UnityEvent rightClickDown;
    public UnityEvent rightClickUp;
    public UnityEvent rightClickDrag;

	private static float timeSinceClick;

	private void Update()
	{
		if (Input.GetMouseButtonUp(0)) // Left Up
		{
			leftClickUp.Invoke();

			//EDIT FROM HERE ON
		}
		else if (Input.GetMouseButtonUp(1)) // Right Up
		{
			rightClickUp.Invoke();

			//EDIT FROM HERE ON
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0)) // Left Down
		{
			timeSinceClick = Time.time;
			leftClickDown.Invoke();

			//EDIT FROM HERE ON
		}
		else if (Input.GetMouseButtonDown(1)) // Right Down
		{
			timeSinceClick = Time.time;
			rightClickDown.Invoke();

			//EDIT FROM HERE ON
		}
		else if (Input.GetMouseButton(0) && Time.time - timeSinceClick > 0.1f) // Left Drag
		{
			leftClickDrag.Invoke();

			//EDIT FROM HERE ON
		}
		else if (Input.GetMouseButton(1) && Time.time - timeSinceClick > 0.1f) // Right Drag
		{
			rightClickDrag.Invoke();

			//EDIT FROM HERE ON
		}
	}
}

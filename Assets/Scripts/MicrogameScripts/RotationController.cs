using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public GameObject coreObject, outer1Object, outer2Object, outer3Object, outer4Object;

    private float initialRotationAmount = 120f;
    private int currentDepth;

    // Start is called before the first frame update
    void Start()
    {
        currentDepth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentDepth < 4)
        {
            currentDepth += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentDepth > 0)
        {
            currentDepth -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateDisc(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateDisc(0);
        }
    }

    // 0 clockwise
    // 1 anti clockwise
    void RotateDisc(int rotationDirection)
    {
        GameObject rotationObject = null;
        float rotationAmount = initialRotationAmount / (Mathf.Pow(2, currentDepth));

        switch (currentDepth)
        {
            case 0:
                rotationObject = coreObject;
                break;
            case 1:
                rotationObject = outer1Object;
                break;
            case 2:
                rotationObject = outer2Object;
                break;
            case 3:
                rotationObject = outer3Object;
                break;
            case 4:
                rotationObject = outer4Object;
                break;
        }
        rotationAmount = rotationDirection == 1 ? rotationAmount : -rotationAmount;

        rotationObject.transform.Rotate(new Vector3(0, 0, rotationAmount));
    }
}

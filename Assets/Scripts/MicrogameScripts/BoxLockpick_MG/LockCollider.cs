using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxLockpick_GEM.current.onCorrectLockPositionEntered += AssignNewLockPosition;
    }

    private void AssignNewLockPosition()
    {
        transform.Rotate(0, 0, Random.Range(90f, 270f));
    }
}

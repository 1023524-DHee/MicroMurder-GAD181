using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockParts : MonoBehaviour
{
    private List<(int, int)> entryExitPairs = new List<(int, int)>();

    public Animator lockAnimation;
    public List<int> entryList;
    public List<int> exitList;

	private void Start()
	{
        lockAnimation = GetComponent<Animator>();
        for (int ii = 0; ii < entryList.Count; ii++)
        {
            entryExitPairs.Add((entryList[ii], exitList[ii]));
        }
	}

	public List<(int, int)> GetEntryExitPairs()
    {
        return entryExitPairs;
    }

    public void UpdateRotatedPoints()
    {
        for (int ii = 0; ii < entryExitPairs.Count; ii++)
        {
            var tempTuple = entryExitPairs[ii];
            tempTuple.Item1 = (tempTuple.Item1 + 1) % 4;
            tempTuple.Item2 = (tempTuple.Item2 + 1) % 4;
            entryExitPairs[ii] = tempTuple;
        }
    }

    public void PlayDisappearAnimation()
    {
        GetComponent<AudioSource>().Play();
        lockAnimation.SetTrigger("Fade");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}

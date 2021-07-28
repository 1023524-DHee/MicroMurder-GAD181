using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private AudioSource audioSource;

    public List<GameObject> lockObjects;

	private void Start()
	{
        audioSource = GetComponent<AudioSource>();
	}

	public void RotateDisc(int lockDepth)
    {
        GameObject rotationObject = lockObjects[lockDepth];
        rotationObject.transform.Rotate(new Vector3(0, 0, -90f));
        audioSource.Play();
        CheckUnlock();
    }

    private void CheckUnlock()
    {
        List<int> tempList = new List<int>(); 
        for (int ii = 0; ii < lockObjects.Count; ii++)
        {
            List<(int, int)> pairs = lockObjects[ii].GetComponent<LockParts>().GetEntryExitPairs();
            if (ii == 0)
            {
                tempList.Add(pairs[0].Item2);
            }
            else
            {
                bool addedToList = false;
                foreach ((int, int) pair in pairs)
                {
                    if (tempList[tempList.Count - 1] == pair.Item1 && !addedToList)
                    {
                        addedToList = true;
                        tempList.Add(pair.Item1);
                        tempList.Add(pair.Item2);
                    }
                }
                if (addedToList == false) return;
            }
        }

        if (tempList[tempList.Count - 1] == 0) UnlockPart();
    }

    private void UnlockPart()
    {
        GameObject outermostLock = lockObjects[lockObjects.Count - 1];
        outermostLock.GetComponent<LockParts>().PlayDisappearAnimation();
        lockObjects.Remove(outermostLock);
        if (lockObjects.Count == 0)
        {
            ShopShutter.current.PlayAnimation();
            StartCoroutine(MicrogameEnd());
        }
    }

    private IEnumerator MicrogameEnd()
    {
        yield return new WaitForSeconds(3f);
        MicrogameManager.current.LoadNextMicrogame();
    }
}

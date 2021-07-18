using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrogator : MonoBehaviour
{
    public static Interrogator current;

    public Animator interrogatorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    public IEnumerator InterrogatorSlam()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        interrogatorAnimator.SetTrigger("Trigger");
        yield return new WaitForSeconds(interrogatorAnimator.GetCurrentAnimatorStateInfo(0).length);
        BPMTracker.current.SetBPMValue(0.3f);
        StartCoroutine(InterrogatorSlam());
    }
}

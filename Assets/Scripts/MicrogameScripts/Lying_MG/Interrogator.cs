using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrogator : MonoBehaviour
{
    public Animator interrogatorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        LyingGEM.current.onGameStart += InterrogatorSlam_CoroutineStart;
    }

    private void InterrogatorSlam_CoroutineStart()
    {
        StartCoroutine(InterrogatorSlam_Coroutine());
    }

    public IEnumerator InterrogatorSlam_Coroutine()
    {
        yield return new WaitForSeconds(Random.Range(4f, 7f));
        interrogatorAnimator.SetTrigger("Trigger");
        yield return new WaitForSeconds(interrogatorAnimator.GetCurrentAnimatorStateInfo(0).length);
        LyingGEM.current.InterrogatorSlam(0.4f);
        StartCoroutine(InterrogatorSlam_Coroutine());
    }
}

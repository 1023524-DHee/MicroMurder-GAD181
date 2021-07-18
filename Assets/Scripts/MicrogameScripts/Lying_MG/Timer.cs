using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer current;

    public Animator timerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    public IEnumerator Timer_Coroutine()
    {
        yield return new WaitForSeconds(7.5f);
        timerAnimator.SetTrigger("NextTimer");
        AnimatorClipInfo[] currentClipInfo = timerAnimator.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo[0].clip.name == "Timer4_Anim")
        {
            StartCoroutine(EndTimer_Coroutine());
        }
        else
        {
            StartCoroutine(Timer_Coroutine());
        }
    }

    IEnumerator EndTimer_Coroutine()
    {
        yield return new WaitForSeconds(2.5f);
        BPMTracker.current.SetCircleActive(false);
        BPMTracker.current.StopCoroutines();
        MicrogameManager.current.LoadNextMicrogame();
    }
}

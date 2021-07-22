using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator timerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        LyingGEM.current.onGameStart += Timer_CoroutineStart;
    }

    private void Timer_CoroutineStart()
    {
        StartCoroutine(Timer_Coroutine());
    }

    public IEnumerator Timer_Coroutine()
    {
        yield return new WaitForSeconds(7.5f);
        timerAnimator.SetTrigger("NextTimer");
        AnimatorClipInfo[] currentClipInfo = timerAnimator.GetCurrentAnimatorClipInfo(0);
        if (currentClipInfo[0].clip.name == "Timer4_Anim")
        {
            LyingGEM.current.GameEnd();
        }
        else
        {
            Timer_CoroutineStart();
        }
    }
}

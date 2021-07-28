using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    LYING,
    FIGHTINMATE
}

public class Timer : MonoBehaviour
{
    public Animator timerAnimator;
    public SceneName currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        switch (currentSceneName)
        {
            case SceneName.LYING:
                LyingGEM.current.onGameStart += Timer_CoroutineStart;
                break;
            case SceneName.FIGHTINMATE:
                FightInmatesGEM.current.onGameStart += Timer_CoroutineStart;
                break;

        }
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
            switch (currentSceneName)
            {
                case SceneName.LYING:
                    LyingGEM.current.GameEnd();
                    break;
            }
        }
        else
        {
            if(currentSceneName == SceneName.FIGHTINMATE) FightInmatesGEM.current.TimerDown();
            Timer_CoroutineStart();
        }
    }
}

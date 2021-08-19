using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline_ChaseSt : MonoBehaviour
{
    private Image timelineImage;
    private float maxTime, timeLeft;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        timelineImage = GetComponent<Image>();
        maxTime = 40f;
        timeLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < maxTime)
        {
            timeLeft += Time.deltaTime;
            timelineImage.fillAmount = timeLeft / maxTime;
        }
        else
        {
            if (!gameEnded)
            {
                ChaseStGEM.current.SetPlayerWinState(true);
                ChaseStGEM.current.GameEnd();
                gameEnded = true;
            }
        }
    }
}

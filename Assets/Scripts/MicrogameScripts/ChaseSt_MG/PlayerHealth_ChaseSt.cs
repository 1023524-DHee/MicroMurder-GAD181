using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth_ChaseSt : MonoBehaviour
{
    private Image playerHealthImage;

    // Start is called before the first frame update
    void Start()
    {
        ChaseStGEM.current.onPlayerShotSuccess += TakeDamage;

        playerHealthImage = GetComponent<Image>();
    }

    void TakeDamage()
    {
        Color currentColor = playerHealthImage.color;
        currentColor.a += 0.1f;
        playerHealthImage.color = currentColor;
        if (currentColor.a >= 1f)
        {
            ChaseStGEM.current.SetPlayerWinState(false);
            ChaseStGEM.current.GameEnd();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth_FightVictim : MonoBehaviour
{
    private float healthValue = 0;
    private Image imageRenderer;

    public GameObject healthPanel;

    // Start is called before the first frame update
    void Start()
    {
        imageRenderer = healthPanel.GetComponent<Image>();
        FightVictimGEM.current.onPlayerTakeDamage += TakeDamage;
    }

    private void TakeDamage()
    {
        //PlayAudio_FightInmate.current.PlayAudioClip("takeDamageSound");
        healthValue += 5;
        imageRenderer.color += new Color(0, 0, 0, healthValue / 255);
        if (healthValue >= 150)
        {
            //PlayAudio_FightInmate.current.PlayAudioClip("deathSound");
            FightVictimGEM.current.GameEnd();
        }
    }
}

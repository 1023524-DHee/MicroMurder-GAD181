using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmateBehaviour : MonoBehaviour
{
    private int currentInmateDepth;
    private FightInmates_HealthBar healthBar;
    private SpriteRenderer spriteRenderer;

    public Sprite inmateSprite1, inmateSprite2, inmateSprite3;
    public float scale1, scale2;
    public float xPos1, yPos1, xPos2, yPos2;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<FightInmates_HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentInmateDepth = 0;
        FightInmatesGEM.current.onGameEnd += GameEndedCleanup;
        ChangeInmate_CoroutineStart();
    }

	private void Update()
	{
        ChangeColour();
	}

	IEnumerator ChangeInmate_Coroutine()
    {
        yield return new WaitForSeconds(1f);

        switch (currentInmateDepth)
        {
            case 0:
                currentInmateDepth++;
                transform.position = new Vector2(xPos1, yPos1);
                transform.localScale = new Vector2(scale1, scale1);
                break;
            case 1:
                currentInmateDepth++;
                transform.position = new Vector2(xPos2, yPos2);
                transform.localScale = new Vector2(scale2, scale2);
                break;
            case 2:
                FightInmatesGEM.current.PlayerTakeDamage();
                break;
        }

        ChangeInmate_CoroutineStart();
    }
    private void ChangeInmate_CoroutineStart()
    {
        StartCoroutine(ChangeInmate_Coroutine());
    }

    private void ChangeColour()
    {
        switch (healthBar.GetCurrentHealth())
        {
            case 2:
                spriteRenderer.sprite = inmateSprite1;
                break;
            case 1:
                spriteRenderer.sprite = inmateSprite2;
                break;
            case 0:
                spriteRenderer.sprite = inmateSprite3;
                break;
        }
    }

    private void GameEndedCleanup()
    {
        StopAllCoroutines();
    }

	private void OnDestroy()
	{
        FightInmatesGEM.current.onGameEnd -= GameEndedCleanup;
    }
}

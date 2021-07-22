using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmateBehaviour : MonoBehaviour
{
    private int currentInmateDepth;
    private FightInmates_HealthBar healthBar;
    private SpriteRenderer spriteRenderer;

    public float inmateTimeMin, inmateTimeMax;
    public float scale1, scale2;
    public float xPos1, yPos1, xPos2, yPos2;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<FightInmates_HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentInmateDepth = 0;
        ChangeInmate_CoroutineStart();
    }

	private void Update()
	{
        ChangeColour();
	}

	IEnumerator ChangeInmate_Coroutine()
    {
        yield return new WaitForSeconds(Random.Range(inmateTimeMin, inmateTimeMax));

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
            case 3:
                spriteRenderer.color = Color.blue;
                break;
            case 2:
                spriteRenderer.color = Color.red;
                break;
            case 1:
                spriteRenderer.color = Color.black;
                break;
        }
    }

}

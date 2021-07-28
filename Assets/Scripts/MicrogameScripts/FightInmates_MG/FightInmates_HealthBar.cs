using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInmates_HealthBar : MonoBehaviour
{
    private int currentHealth;

    public int maxHealth;

	private void Start()
	{
        currentHealth = maxHealth;
        FightInmatesGEM.current.onGameEnd += GameEndedCleanup;
	}

	public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            Dead_CoroutineStart();
        }
    }

    public void RestoreHealth(int healthRestored)
    {
        currentHealth += healthRestored;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator Dead_Coroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private void Dead_CoroutineStart()
    {
        StartCoroutine(Dead_Coroutine());
    }

    private void GameEndedCleanup()
    {
        currentHealth = 99;
    }

	private void OnDestroy()
	{
        FightInmatesGEM.current.onGameEnd -= GameEndedCleanup;
    }
}

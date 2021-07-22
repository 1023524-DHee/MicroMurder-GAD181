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
            Dead();
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

    private void Dead()
    {
        Destroy(gameObject);
    }
}

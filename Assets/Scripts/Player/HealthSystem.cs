using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float currentHealth;

    private const float maxHealth = 100;

    private void Awake() {
        currentHealth = maxHealth;
    }

    public void AddHealth(float toaddHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth + toaddHealth,0,maxHealth);
    }

    public void DecreaseHealth(float toDecreaseHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth - toDecreaseHealth,0,maxHealth);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public float GetHealthMax()
    {
        return maxHealth;
    }
}

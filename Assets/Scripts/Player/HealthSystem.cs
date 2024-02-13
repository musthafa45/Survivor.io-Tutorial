using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event Action OnPlayerHealthFinished;
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

        if(currentHealth <= 0)
        {
            // Die Event
            OnPlayerHealthFinished?.Invoke();

        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.SetState(Enemy.EnemyState.Idle);
        }
        
        }
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

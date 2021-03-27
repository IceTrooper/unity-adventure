using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 1;
    
    public int CurrentHealth { get; private set; }

    public UnityEvent OnDeath, OnReceiveDamage;

    private void Start()
    {
        ResetHealth();
    }

    public void ApplyDamage(int amount)
    {
        if(CurrentHealth <= 0)
        {
            // We can make something on receiving damage when dead.
            return;
        }

        CurrentHealth -= amount;

        if(CurrentHealth <= 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnReceiveDamage.Invoke();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealthControl : MonoBehaviour
{
    public int MaxHealth = 3;

    private int CurrentHealth;

    public TextMesh HealthCounter;

    protected void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthCounterText();
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath();
            }
            UpdateHealthCounterText();
        }
    }

    private void UpdateHealthCounterText()
    {
        HealthCounter.text = CurrentHealth + "/" + MaxHealth;
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}

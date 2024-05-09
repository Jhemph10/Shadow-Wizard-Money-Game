using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    
    public float maxHealth = 50f;

    public float currentHealth;
    public Healthbar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage (float amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        maxHealth -= amount;
        if (maxHealth <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }

}

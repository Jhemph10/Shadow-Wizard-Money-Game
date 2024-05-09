using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool onHeal = false;
    public float maxHealth;
    public float maxMana;
    [Range(0, 100)]
    public float currentHealth;
    [Range(0, 100)]
    public float currentMana;

    public Healthbar healthBar;
    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (manaBar.slider.value > 0)
        {
            if (Input.GetButtonDown("Heal") && onHeal == false)
            {
                CastSpell(25);
                currentHealth += 20;
                Debug.Log(currentHealth);
                healthBar.SetHealth(currentHealth);
                StartCoroutine(HealCoolDown());

            }
        }
        

         if (currentHealth <= 0)
         {
             Die();
             SceneManager.LoadScene("Lose Screen");
         }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void CastSpell(float spellCost)
    {
        currentMana -= spellCost;

        manaBar.SetMana(currentMana);
    }

     void Die ()
     {
         
     }

    IEnumerator HealCoolDown()
    {
        onHeal = true;
        yield return new WaitForSeconds(3);
        onHeal = false;
        Debug.Log("Spells is back");
    }

}

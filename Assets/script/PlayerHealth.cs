using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvisible = false;
    public SpriteRenderer graphics;
    public float invincibilityTimeFlash = 0.15f;
    public float invincibilityTimeAfterHit = 3f;
    public deathCondition deathCondition;  

    void Start()
    {
        Time.timeScale = 1f;
        if (healthBar == null)
        {
            healthBar = FindObjectOfType<HealthBar>();
        }

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

     
        if (deathCondition == null)
        {
            deathCondition = FindObjectOfType<deathCondition>();
        }
    }

    void Update()
    {

        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            deathCondition.ShowDeathMenu();
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void takeDamage(int damage)
    {
        if (!isInvisible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvisible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvisible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityTimeFlash);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityTimeFlash);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvisible = false;
    }
    public void heal()
    { 

        int heal = maxHealth - currentHealth;
        currentHealth = currentHealth + heal;
        healthBar.SetHealth(currentHealth);
    }
}

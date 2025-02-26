
using System.Reflection;
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



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        if (!isInvisible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvisible = true;
            StartCoroutine(InvincibilyFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public IEnumerator InvincibilyFlash()
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
}

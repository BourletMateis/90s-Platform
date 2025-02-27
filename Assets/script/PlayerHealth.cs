using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar; // Lien avec la health bar de l'UI
    public bool isInvisible = false;
    public SpriteRenderer graphics;
    public float invincibilityTimeFlash = 0.15f;
    public float invincibilityTimeAfterHit = 3f;

    void Start()
    {
        if (healthBar == null)
        {
            healthBar = FindObjectOfType<HealthBar>();
        }

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
            healthBar.SetHealth(currentHealth); // Met à jour la health bar
            isInvisible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvisible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // Rendre invisible
            yield return new WaitForSeconds(invincibilityTimeFlash);
            graphics.color = new Color(1f, 1f, 1f, 1f); // Restaurer la visibilité
            yield return new WaitForSeconds(invincibilityTimeFlash);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvisible = false; // Réactive le joueur
    }
}

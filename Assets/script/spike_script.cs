using UnityEngine;
using UnityEngine.SceneManagement; // Pour recharger la scène

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.takeDamage(playerHealth.maxHealth);

            }
        }
    }
}



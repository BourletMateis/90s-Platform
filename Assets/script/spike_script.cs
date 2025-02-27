using UnityEngine;
using UnityEngine.SceneManagement; // Pour recharger la scène

public class PikeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet qui a touché le piquant a le tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Détruit le joueur
            Destroy(collision.gameObject);

            // Redémarre la scène après un court délai
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Récupère le nom de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Recharge la scène actuelle pour redémarrer le jeu
        SceneManager.LoadScene(currentSceneName);
    }
}
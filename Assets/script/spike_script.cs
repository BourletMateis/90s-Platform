using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float minY = -1.5f;  
    public float maxY = 1.0f;   
    public float speed = 2.0f;  // Vitesse du mouvement
    public float waitTime = 1.5f; // Temps d'attente en haut et en bas

    private bool isMovingUp = true; // Indique si le pique monte

    void Start()
    {
        // Démarre le cycle en boucle
        StartCoroutine(SpikeCycle());
    }

    IEnumerator SpikeCycle()
    {
        while (true) // Boucle infinie
        {
            // Monte le pique
            yield return StartCoroutine(MoveSpike(maxY));
            yield return new WaitForSeconds(waitTime); // Pause en haut

            // Descend le pique
            yield return StartCoroutine(MoveSpike(minY));
            yield return new WaitForSeconds(waitTime); // Pause en bas
        }
    }

    IEnumerator MoveSpike(float targetY)
    {
        // Tant que le pique n'est pas à la position voulue
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            // Déplace le pique progressivement
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, targetY, transform.position.z),
                speed * Time.deltaTime
            );

            yield return null; // Attendre la prochaine frame
        }
    }
}
using controlleur;
using System.Collections;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject knightPrefab; 
    public float delayBeforeDestroy = 0.1f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Coin"))
        {
            Inventory.instance.AddCoins(1); 
            Destroy(gameObject); 
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Armor"))
        {
            StartCoroutine(DestroyPlayerAndSpawnKnight(collision.gameObject));
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Heal"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.heal();
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyPlayerAndSpawnKnight(GameObject player)
    {
        yield return new WaitForSeconds(delayBeforeDestroy);

        Vector3 playerPosition = player.transform.position;

        Destroy(player);
        Destroy(gameObject);

        GameObject knight = Instantiate(knightPrefab, playerPosition, Quaternion.identity);

        Controlleur knightController = knight.GetComponent<Controlleur>();

        if (knightController != null)
        {
            knightController.doubleJump = true;

        }
    }
}

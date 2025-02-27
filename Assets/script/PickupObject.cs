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
    }

    private IEnumerator DestroyPlayerAndSpawnKnight(GameObject player)
    {
        yield return new WaitForSeconds(delayBeforeDestroy);

        Destroy(player);
        Destroy(gameObject);
        Instantiate(knightPrefab, player.transform.position, Quaternion.identity);
    }
}

using controlleur;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectDestroy;
    public Animator animator;
    public bool isPlayerAbove = false; 

    void Start()
    {
        animator.SetFloat("Health", 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            isPlayerAbove = true;
            animator.SetFloat("Health", 0);

            if (GetComponent<Controlleur>() != null)
                GetComponent<Controlleur>().enabled = false;

            if (GetComponent<Rigidbody2D>() != null)
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerAbove = false;
        }
    }

    public void Kill()
    {
        Destroy(objectDestroy);
    }
}

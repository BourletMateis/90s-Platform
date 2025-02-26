using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections;
using controlleur; 

public class WeakSpot : MonoBehaviour
{
    public GameObject objectDestroy;
    public Animator animator;

    void Start()
    {
        animator.SetFloat("Health", 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetFloat("Health", 0);

            if (GetComponent<Controlleur>() != null)
                GetComponent<Controlleur>().enabled = false;

            if (GetComponent<Rigidbody2D>() != null)
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }

    public void Kill()
    {
        Destroy(objectDestroy);
    }
}

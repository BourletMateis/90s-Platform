using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public SpriteRenderer graphics;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint = 0;
    public int damageOnCollision = 20;
    public WeakSpot weakSpot; 

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();

            if (weakSpot.isPlayerAbove)
            {
                return; 
            }

            playerHealth.takeDamage(damageOnCollision);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallController : MonoBehaviour
{
    // Global Variables
    public Rigidbody2D spikeBody; // Body of the player
    public float lifespan = 5; // Lifetime of the projectile
    private float timer; // Timer for the projectile

    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan; // Set the timer to the lifespan
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) // Cooldown timer is positive
        {
            timer -= Time.deltaTime; // Decrease timer
        } else { // Timer is up
            Destroy(gameObject); // Destroy the spike ball
        }
    }

    // Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // Collide with the player
        {
            Destroy(gameObject); // Destroy itself
        }
    }
}

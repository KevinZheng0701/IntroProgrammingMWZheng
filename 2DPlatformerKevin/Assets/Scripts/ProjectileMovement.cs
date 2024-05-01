using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // Global Variables
    public Rigidbody2D projectileRb; // Rigidbody of the projectile
    public float speed = 8; // Speed of projectile
    public float projectileLife = 1; // Lifetime of the projectile
    private float projectileCount; // Timer for the projectile
    public PlayerController playerControllerScript; // Get the script of the player controller
    public float facingLeft; // Direction of the projectile

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife; // Set the count to the projectile life
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Finds the player controller script
        facingLeft = playerControllerScript.facingLeft; // Set the direction of the projectile to that of the player
        if (facingLeft) // Character is facing right
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotate the projectile
            speed = -speed; // Make the projectile move in the opposite direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileCount > 0) { // Projectile is still alive
            projectileCount -= Time.deltaTime; // Reduce the lifetime of the projectile
        } else { // Timer is up
            Destroy(gameObject); // Projectile is gone
        }
    }

    // FixedUpdate is called 50 times per second
    private void FixedUpdate() 
    {
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); // Make the projectile move
    }
    // Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage") // Collide with objects that does damage
        {
            Destroy(collision.gameObject); // Destroy the damage object
        }
        Destroy(gameObject); // Destroy the projectile
    }
}

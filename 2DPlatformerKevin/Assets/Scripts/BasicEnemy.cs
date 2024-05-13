using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Global Variables
    public int damage; // Damage the enemy do
    public PlayerController playerControllerScript; // Player control script
    public Vector3[] patrolPoints; // List of patrol points
    public float moveSpeed = 3; // Move speed of enemy
    public int patrolDestination; // The destination for the enemy to move

    // Start is called before the first frame update
    void Start()
    {
        damage = 3; // Set the damage of the enemy
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); // Allows the enemy to move
    }

    // Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" ) // Collide with player
        {
            playerControllerScript.TakeDamage(damage); // Deals damage to player
        }
    }
    // Movement logic for enemy
    private void EnemyMovement()
    {
        if (patrolDestination >= patrolPoints.Length) // The destination is greater than the amount of patrol points
        {
            patrolDestination = 0; // Reset to first patrol point
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[patrolDestination], moveSpeed * Time.deltaTime); // Move the enemy towards patrol point
        if (Vector3.Distance(transform.position, patrolPoints[patrolDestination]) < 0.05f) // Enemy got close to destination
        {
            patrolDestination += 1; // Update destination to the next patrol point
        }
    }
}

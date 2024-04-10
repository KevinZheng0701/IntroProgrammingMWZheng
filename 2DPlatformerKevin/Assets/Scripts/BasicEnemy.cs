using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    // Global Variables
    public int damage; // Damage the enemy do
    public PlayerController playerControllerScript; // Player control script
    public Transform[] patrolPoints; // List of patrol points
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
        if (patrolDestination == 0) // Move towards patrol point 0
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].transform.position, moveSpeed * Time.deltaTime); // Move the enemy towards patrol point 0
            if (Vector3.Distance(transform.position, patrolPoints[0].transform.position) < 0.05f) // Enemy got close to destination
            {
                patrolDestination = 1; // Update destination to patrol point 1
            }
        } else if (patrolDestination == 1) { // Move towards patrol point 1
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].transform.position, moveSpeed * Time.deltaTime); // Move the enemy towards patrol point 1
            if (Vector3.Distance(transform.position, patrolPoints[1].transform.position) < 0.05f) // Enemy got close to destination
            {
                patrolDestination = 0; // Update destination to patrol point 0
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Global Variables
    public Rigidbody2D playerBody; // Body of the player
    public float playerSpeed; // Speed of the player
    public float jumpForce; // Jump force of the player
    public bool isJumping = false; // Check if a player is jumping or not
    public int maxHealth = 10; // Max health of player
    public int currentHealth; // Current health of player
    public bool flippedLeft = false; // Direction the player sprite is facing
    public bool facingLeft = false; // Direction the player is facing
    public HealthBarController healthBarScript; // Health bar script
    public SceneChanger sceneManagmentScript; // Scene management script

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0.015f; // Set the speed of the player
        jumpForce = 300; // Set the jump force of the player
        currentHealth = maxHealth; // Set the health to max
        healthBarScript.SetMaxHealth(maxHealth); // Set the health bar to the max health
    }

    // Update is called once per framess
    void Update()
    {
        MovePlayer(); // Move the player around
        Jump(); // Allows the player to jump
        Fall(); // Allows the player to fall faster
    }

    // Move the player left and right
    private void MovePlayer()
    {
        Vector3 newPosition = transform.position; // The current position of the player
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Left keys are pressed
        {
            newPosition.x -= playerSpeed; // Mov eto the left by player speed
            facingLeft = true; // Player should be facing left
            Flip(facingLeft); // Flip the direction
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Right keys are pressed
        {
            newPosition.x += playerSpeed; // Move to the right by player speed
            facingLeft = false; // Player should be facing right
            Flip(facingLeft); //  Flip the direction
        }
        transform.position = newPosition; // Make body move to the new position
    }
    // Accelerate falling 
    private void Fall()
    {
        Vector3 newPosition = transform.position; // The current position of the player
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && isJumping) // Down keys are pressed
        {
            if (playerBody.velocity.y > 0) // Stop moving up
            {
                playerBody.velocity = new Vector3(0, 0, 0); // Reset the moving momentum
            }
            newPosition.y -= playerSpeed; // Make player fall faster
        }
    }
    // Allows player to jump
    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping) // Keys to Jump
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0)); // Move the player up
            isJumping = true; // Player is jumping
        }
    }
    // Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface") // Collide with the ground
        {
            isJumping = false; // Set to false since player is on the ground
            playerBody.velocity = new Vector3(0, 0, 0); // Reset the moving momentum
        }
        if (collision.gameObject.tag == "Damage") // Collide with the ground
        {
            TakeDamage(1); // Decrement health by 1
        }
    }
    // Player takes a certain damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease health by damage
        healthBarScript.SetHealth(currentHealth); // Update the health bar
        if (currentHealth < 0) // Player health is below 0
        {
            sceneManagmentScript.MoveToScene(2); // Change the scene to the end scene
        }
    }
    // Rotate the player
    public void Flip(bool facingLeft) 
    {
        if (facingLeft && !flippedLeft) // Player is facing left but sprite hasn't been flipped
        {
            transform.Rotate(0, -180, 0); // Flip the sprite
            flippedLeft = true; // Set flipped to true
        } else if (!facingLeft && flippedLeft) // Player is facing right but sprite hasn't been flipped
        {
            transform.Rotate(0, 180, 0); // Flip the sprite
            flippedLeft = false; // Set flipped to false
        }
    }
}

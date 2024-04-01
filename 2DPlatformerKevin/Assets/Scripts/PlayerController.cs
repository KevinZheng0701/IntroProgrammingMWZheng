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
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 300;
        playerSpeed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    // Move the player left and right
    private void MovePlayer()
    {
        Vector3 newPosition = transform.position; // The current position of the player
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Left keys are pressed
        {
            newPosition.x -= playerSpeed; // Move to the left by player spped
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Right keys are pressed
        {
            newPosition.x += playerSpeed; // Move to the right by player speed
        }
        /*else if ((Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isJumping) // Down keys are pressed
        {
            newPosition.y -= playerSpeed; // Make player fall faster
        }*/
        transform.position = newPosition; // Make body move to the new position
    }
    // Allows player to jump
    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !isJumping) // Keys to Jump
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0)); // Move the player up
            isJumping = true; // Player is jumping
        }
    }
    // Detect collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface") // Collide with the ground
        {
            isJumping = false; // Set to false since player is on the ground
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Library to use list

public class SnakeMovement : MonoBehaviour
{
    // Global variables
    public Vector3 direction = Vector3.right; // Direction of the snake
    List<Transform> tail = new List<Transform>(); // List of snake body
    bool ateFood = false; // Flag for whether the snake recently ate food
    private bool atePoison = false; // Boolean for whether the snake ate a poison food
    private float poisonTimer = 0; // Timer to keep track of time left after eating poison food
    public GameObject bodyPrefab; // Grab snake body to spawn after eating
    public SceneChanger mySceneChanger; // Grab the scene changer script
    public GameManager myManager; // Game manager script to update score

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.5f, 0.1f); // Move the snake every 0.1 second
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection(); // Check for movement changes
        if (atePoison) // Ate poison, so any food that snake eats will decrease point
        {
            if (poisonTimer > 0) // There is still time left with poison effect
            {
                poisonTimer -= Time.deltaTime; // Lower time
            }
            else // The timer ends
            {
                atePoison = false; // Snake is healthy so set atePoison to false
            }
        }
    }

    // Move snake around
    void MoveSnake()
    {
        Vector3 gap = transform.position; // Get current position
        transform.Translate(direction); // Move the snake head
        if (ateFood) // Ate food and need to increase snake length
        {
            GameObject tailSec = Instantiate(bodyPrefab, gap, Quaternion.identity); // Spawn snake body at the current position
            tail.Insert(0, tailSec.transform); // Add the newly created body into the list
            ateFood = false; // Set the boolean to false
        }
        if (tail.Count > 0) // If the list is nonempty
        {
            tail.Last().position = gap; // Get the last transform of the snake body and set it to the current position
            tail.Insert(0, tail.Last()); // Add the last snake body to the front of the list
            tail.RemoveAt(tail.Count - 1); // Remove the extra snake body
        }
    }
    // Change the direction
    void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // W or Uparrow is pressed
        {
            direction = Vector3.up; // Move up
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // S or Downarrow is pressed
        {
            direction = Vector3.down; // Move down
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // A or Leftarrow is pressed
        {
            direction = Vector3.left; // Move left
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // D or Rightarrow is pressed
        {
            direction = Vector3.right; // Move right
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food") // Collide with food
        {
            ateFood = true; // Set bool to true
            if (collision.gameObject.name.Contains("Poison")) {
                myManager.Decrease(3); // Decrease score after eating poison food
                atePoison = true;
                poisonTimer = 10f;
            } else if (atePoison) // Snake is poisoned
            {
                myManager.Decrease(1); // Eating food will decrease score
            } else 
            {
                myManager.Increase(1); // Increase the score after eating
            }
            Destroy(collision.gameObject); // Ate the food
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Body") // Hit the wall or the snake
        {
            mySceneChanger.ChangeScene(2); // Go to game over screen
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Global variables
    public Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.3f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    // Move snake around
    void MoveSnake()
    {
        transform.Translate(direction);
    }
    // Change the direction
    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("A");
            Destroy(collision.gameObject);
        }
    }
}

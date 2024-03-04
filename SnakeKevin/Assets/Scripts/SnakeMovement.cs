using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeMovement : MonoBehaviour
{
    // Global variables
    public Vector3 direction = Vector3.right;
    List<Transform> tail = new List<Transform>();
    bool ateFood = false;
    public GameObject bodyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.5f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    // Move snake around
    void MoveSnake()
    {
        Vector3 gap = transform.position;
        transform.Translate(direction);
        if (ateFood)
        {
            GameObject tailSec = Instantiate(bodyPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);
            ateFood = false;
        }
        if (tail.Count > 0)
        {
            tail.Last().position = gap;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    // Change the direction
    void ChangeDirection()
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
            ateFood = true; 
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            while(tail.Count != 0)
            {
                tail.RemoveAt(0);
            }
            transform.position = new Vector3(0, 0, 0);
        }
    }

}

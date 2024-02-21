using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Global variables
    public Rigidbody2D rbPaddle;
    public bool isPlayer1;
    public float paddleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        paddleSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            Player1Control();
        }
        else
        {
            Player2Control();
        }
    }
    // Controls up and down movements for both paddles
    void Player1Control()
    {
        Vector3 newPos = transform.position;
        if (newPos.y <= 3.5f && newPos.y >= -3.5f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                newPos.y -= paddleSpeed;
            }
            transform.position = newPos;
        }
        if (newPos.y > 3.5f)
        {
            newPos.y = 3.495f;
            transform.position = newPos;
        }
        if (newPos.y < -3.5f)
        {
            newPos.y = -3.495f;
            transform.position = newPos;
        }
    }
    void Player2Control()
    {
        Vector3 newPos = transform.position;
        if (newPos.y <= 3.5f && newPos.y >= -3.5f)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                newPos.y -= paddleSpeed;
            }
            transform.position = newPos;
        }
        if (newPos.y > 3.5f)
        {
            newPos.y = 3.495f;
            transform.position = newPos;
        }
        if (newPos.y < -3.5f)
        {
            newPos.y = -3.495f;
            transform.position = newPos;
        }
    }
}

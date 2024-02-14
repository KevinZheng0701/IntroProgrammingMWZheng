using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Global varibles
    public Rigidbody2D rbBall;
    public float force = 200f;
    private float xDirection;
    private float yDirection;
    public bool inPlay;
    public Vector3 ballStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlay == false)
        {
            transform.position = ballStartPosition;
            Launch();
        }
    }
    // Start the game and push the ball around randomly
    void Launch()
    {
        xDirection = Random.Range(0, 2);
        yDirection = Random.Range(0, 2);
        Vector3 direction = new Vector3(0, 0, 0);
        direction.x = (xDirection == 0) ? -1 : 1;
        direction.y = (yDirection == 0) ? -1 : 1;
        // add force to start movement
        rbBall.AddForce(direction * force);
        inPlay = true;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
        {
            rbBall.velocity = Vector3.zero;
            inPlay = false;
        } 

    }

}
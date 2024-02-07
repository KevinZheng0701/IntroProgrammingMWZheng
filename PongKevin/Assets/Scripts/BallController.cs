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

    // Start is called before the first frame update
    void Start()
    {
        xDirection = Random.Range(0, 2);
        yDirection = Random.Range(0, 2);
        Vector3 direction = new Vector3(0, 0, 0);
        if (xDirection == 0)
        {
            direction.x = -1;
        } else if (xDirection == 1) {
            direction.x = 1;
        }
        if (yDirection == 0)
        {
            direction.y = -1;
        }
        else if (yDirection == 1)
        {
            direction.y = 1;
        }
        // add force to start movement
        rbBall.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

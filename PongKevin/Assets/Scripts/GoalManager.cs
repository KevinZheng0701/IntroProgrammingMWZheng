using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    // Global variables
    public bool isPlayer1Goal;
    public GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Handle scoring
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (isPlayer1Goal)
            {
                myManager.Player2Score();
            }
            else
            {
                myManager.Player1Score();
            }
        }
    }
}

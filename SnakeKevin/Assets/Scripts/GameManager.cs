using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // library for the text mesh pro

public class GameManager : MonoBehaviour
{
    // Global variables
    public TextMeshProUGUI scoreText; // Get the UI text
    private int score = 0; // Current score of the game

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score; // Update the score every frame
    }

    // Increment score
    public void Increase(int number)
    {
        score += number; // Add score by a certain number
    }
    // Decrement score
    public void Decrease(int number)
    {
        if (score - number > 0) // Subtracting the score is higher than zero
        {
            score -= number; // Subtract score by the number
        } else // Score should not be negative
        {
            score = 0; // Score becomes 0
        }
    }
}

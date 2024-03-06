using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public void Increase()
    {
        score++; // Add one to score
    }
}

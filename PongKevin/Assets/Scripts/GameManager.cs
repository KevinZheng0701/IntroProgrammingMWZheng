using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Global variables
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    private int player1Score = 0;
    private int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreText.text = "P1: " + player1Score;
        player2ScoreText.text = "P2: " + player2Score;
    }

    // Increment the score
    public void Player1Score()
    {
        player1Score++;
    }
    public void Player2Score()
    {
        player2Score++;
    }
}

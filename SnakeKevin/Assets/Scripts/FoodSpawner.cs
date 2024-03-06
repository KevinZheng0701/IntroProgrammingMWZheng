using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Global variables
    public GameObject foodPrefab; // Grab the food we're spawning
    public Transform wallTop; // The transform of the top wall
    public Transform wallBottom; // The transform of the bottom wall
    public Transform wallLeft; // The transform of the left wall
    public Transform wallRight; // The transform of the right wall

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 3, 0.5f); // Spawn food in the map every second
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn food randomly
    void SpawnFood()
    {
        int xPos = (int)Random.Range(wallLeft.position.x + 1, wallRight.position.x - 1); // Get a random x-position inside the walls
        int yPos = (int)Random.Range(wallBottom.position.y + 1, wallTop.position.y - 1); // Get a random y-position inside the walls
        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); // Spawn the food into the game
    }
}

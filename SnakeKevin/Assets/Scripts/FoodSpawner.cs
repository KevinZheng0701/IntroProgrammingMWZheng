using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Global variables
    public GameObject foodPrefab;
    public Transform wallTop;
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 3, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn food randomly
    void SpawnFood()
    {
        int xPos = (int)Random.Range(wallLeft.position.x + 1, wallRight.position.x - 1);
        int yPos = (int)Random.Range(wallBottom.position.y + 1, wallTop.position.y - 1);
        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}

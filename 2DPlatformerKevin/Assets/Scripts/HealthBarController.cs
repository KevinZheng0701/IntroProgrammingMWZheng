using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Library for UI

public class HealthBarController : MonoBehaviour
{
    // Global Variable
    public Slider slider; // Get slider of the health bar
    public int Health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the max health to a certain value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; // Set the max health 
        slider.value = health; // Set the health to the max
    }
    // Set the health bar to a certain value
    public void SetHealth(int health)
    {
        slider.value = health; // Set the health
    }
}

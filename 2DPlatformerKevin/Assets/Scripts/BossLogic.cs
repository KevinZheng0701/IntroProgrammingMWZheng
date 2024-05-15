using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public int maxHealth; // Max health of boss
    public int currentHealth; // Current health of boss
    public HealthBarController healthBarScript; // Health bar script
    public SceneChanger sceneManagementScript; // Scene management script

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Set the health to max
        healthBarScript.SetMaxHealth(maxHealth); // Set the health bar to the max health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the health of the boss
        healthBarScript.SetHealth(currentHealth); // Update the health bar
        if (currentHealth < 0) // Boss health is negative
        {
            sceneManagementScript.MoveToScene(2); // Change the sc
        }
    }
}

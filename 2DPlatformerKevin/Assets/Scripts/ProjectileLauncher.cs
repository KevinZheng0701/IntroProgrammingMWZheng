using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // Global Variables
    public GameObject projectilePrefab; // Get projectile gameobject
    public Transform launchPoint; // Position of the launch point
    public float cooldown = 1; // Time of the cooldown
    private float cooldownCount; // Timer between next fire

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownCount > 0) // Cooldown timer is positive so player cannot shoot
        {
            cooldownCount -= Time.deltaTime; // Decrease cooldown time
        } else {
            shootProjectile(); // Allow player to shoot
        }
    }

    // Allows player to shoot projectiles
    private void shootProjectile()
    {
        if (Input.GetMouseButtonDown(0)) // Detects left mouse button click
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); // Spawn the projectile
            cooldownCount = cooldown; // Set the cooldown timer
        }
    }
}

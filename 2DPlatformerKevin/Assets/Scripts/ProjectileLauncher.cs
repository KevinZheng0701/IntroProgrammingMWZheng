using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // Global Variables
    public GameObject projectilePrefab; // Get projectile gameobject
    public Transform launchPoint; // Position of the launch point
    public float cooldown; // Time of the cooldown
    private float cooldownCount; // Timer between next fire
    public AudioSource fireAudio; // Sound effect for taking damage

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>(); // Get all the audio sources
        fireAudio = audioSources[1]; // Get the second audio source which is the fire sound effect
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownCount > 0) // Cooldown timer is positive so cannot shoot
        {
            cooldownCount -= Time.deltaTime; // Decrease cooldown time
        } else { // Cooldown ended
            shootProjectile(); // Allows shooting
        }
    }

    // Allows the player to shoot projectiles
    private void shootProjectile()
    {
        if (Input.GetMouseButtonDown(0)) // Detects left mouse button click
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); // Spawn the projectile
            cooldownCount = cooldown; // Set the cooldown timer
            fireAudio.Play(); // Play the fire sound effect
        }
    }
}

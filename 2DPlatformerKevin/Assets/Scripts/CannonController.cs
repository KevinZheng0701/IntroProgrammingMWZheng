using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Global Variables
    public GameObject projectilePrefab; // Get projectile gameobject
    public Transform launchPoint; // Position of the launch point
    public float launchForce; // Launch force of the projectile
    public float cooldown; // Time of the cooldown
    private float cooldownCount; // Timer between next fire
    public bool isLeft; // Left right direction of the game object
    public bool isUp; // Up down direction of the game object
    public bool isUpDown; // Determine if the game object is going to shoow in the y-direction

    // Start is called before the first frame update
    void Start()
    {
        isLeft = transform.rotation.eulerAngles.y == 180; // Determine the direction of cannon based on y rotation
        isUp = transform.rotation.eulerAngles.z == 90; // Determine the direction of cannon based on z rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownCount > 0) // Cooldown timer is positive so cannot shoot
        {
            cooldownCount -= Time.deltaTime; // Decrease cooldown time
        } else { // Cooldown ended so shoot again
            shootProjectile(); // Allows shooting
        }
    }

    // Allows cannons and other game objects to shoot projectiles
    private void shootProjectile()
    {
        GameObject spikeBall = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); // Spawn the projectile
        Rigidbody2D spikeBody = spikeBall.GetComponent<Rigidbody2D>(); // Get the spikeball rigid body
        Vector3 direction = isLeft ? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0); // Direction the cannon is shooting in the x-axis
        if (isUpDown) // Game object is shooting in the y-axis direction
        {
            direction = isUp ? new Vector3(0, 1, 0) : new Vector3(0, -1, 0); // Direction the cannon is shooting in the y-axis
        }
        spikeBody.AddForce(launchForce * direction); // Push the spike ball with momentum
        cooldownCount = cooldown; // Set the cooldown timer
    }
}

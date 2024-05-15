using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    // Global varaibles
    public static GameObject instance; // Instance of an game object

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when the scripts are loading
    private void Awake()
    {
        if(instance == null) // Instance hasn't been set
        {
            instance = gameObject; // Set the instance to the game object it is attached to
            DontDestroyOnLoad(gameObject); // Prevent the game object from being destroyed when loading
        } else // Instance is already set
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }
}

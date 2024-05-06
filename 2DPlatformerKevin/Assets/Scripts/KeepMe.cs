using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    // Global varaibles
    public static GameObject instance;

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
        // Instance hasn't been set
        if(instance == null) 
        {
            instance = gameObject; // Set the instance to the gameobject it is attached to
            DontDestroyOnLoad(gameObject); // Prevent the gameobject from being destroyed when loadingkoi99
        } else // Instance is already set
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

}

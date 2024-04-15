using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Library for scene management

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to move to new scene
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID); // Load the new scene
    }
}

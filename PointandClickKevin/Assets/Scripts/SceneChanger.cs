using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Library for scene management

public class SceneChanger : MonoBehaviour
{
    // Global variables
    public int sceneNumber;
    /* 0 will be the startScene
       1 will be the mainScene
       2 will be the endScene */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 0) // In start scene
        {
            StartSceneControls();
        } else if (sceneNumber == 1) // In main scene
        {
            MainSceneControls();
        } else if (sceneNumber == 2) // In end scene
        {
            EndSceneControls();
        }
    }

    // Change the start scene to the main scene
    public void StartSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter is pressed
        {
            SceneManager.LoadScene("MainScene"); // Change to main scene
        }
    }
    // Change the main scene to the end scene
    public void MainSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space is pressed
        {
            SceneManager.LoadScene("EndScene"); // Change to end scene
        }
    }
    // Change the end scene to the start scene
    public void EndSceneControls()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R is pressed
        {
            SceneManager.LoadScene("StartScene"); // Change to start scene
        }
    }
    // Function to move to new scene
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID); // Load the new scene
    }
}

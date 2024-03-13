using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Library to change scene

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

    // Change current scene to another
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID); // Change the scene to the specific scene ID
    }
}

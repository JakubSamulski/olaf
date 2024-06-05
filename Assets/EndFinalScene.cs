using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFinalScene : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
        Invoke("LoadNextScene", 15f);
    }

    void LoadNextScene()
    {
        print("Loading next scene");
        SceneManager.LoadScene("Levels/End");
    }
}

  
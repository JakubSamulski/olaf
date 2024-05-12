using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int sceneBuildIndex;
    public int coinCount;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        print("Trigger entered");

        if(other.tag == "player"){
            print("Switching scene to: " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }


    private void Update()
    {
       
    }
}
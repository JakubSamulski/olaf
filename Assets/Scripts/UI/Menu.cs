using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void onPlayButton(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void onMenuButton(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void OnQuitButton(){
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
}


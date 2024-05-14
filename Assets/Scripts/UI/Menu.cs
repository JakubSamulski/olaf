using UnityEngine;
using UnityEngine.SceneManagement;
using Dan.Main;

public class Menu : MonoBehaviour
{

    public void onPlayButton(){
        SceneManager.LoadScene("Levels/level1", LoadSceneMode.Single);
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

    public void onLeaderboardButton()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }
}


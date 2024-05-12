using UnityEngine;
using UnityEngine.SceneManagement;
using Dan.Main;

public class Menu : MonoBehaviour
{

    private string leaderboardPublicKey = "6b6834f35c4a162af15cd15d62a9af8e701039bbe4e1e3a34a3524955b078e5d";
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

    public void onLeaderboardGetButton()
    {
        CoinManager coinManager = new CoinManager();
        int coins = coinManager.getCoins();
        LeaderboardCreator.GetLeaderboard(leaderboardPublicKey, ((msg) =>
        {
            for (int i = 0; i < msg.Length; i++)
            {
                print(msg[i].Username + " " + msg[i].Score);
            }
        }));
    }

    public void onLeaderboardAddButton()
    {
        LeaderboardCreator.UploadNewEntry(leaderboardPublicKey, "Player", 100);
    }
}


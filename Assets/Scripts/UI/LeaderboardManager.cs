using Dan.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    GameObject table;
    private CoinManager coinManager;
    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("Table");
        coinManager = new CoinManager();
        clearLeaderboard();
        getLeaderboard();
        getScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clearLeaderboard()
    {
        foreach (Transform row in table.transform)
        {
            Transform nickname = row.GetChild(0);
            Transform score = row.GetChild(1);
            nickname.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            score.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }
    public void getLeaderboard()
    {
        CoinManager coinManager = new CoinManager();
        int coins = coinManager.getCoins();
        Leaderboards.Olaf.GetEntries((msg =>
        {
            int i = 0;
            print(msg.Length);
            foreach (Transform row in table.transform)
            {
                Transform nickname = row.GetChild(0);
                Transform score = row.GetChild(1);
                try
                {
                    nickname.GetComponent<TMPro.TextMeshProUGUI>().text = msg[i].Username.ToString();
                    score.GetComponent<TMPro.TextMeshProUGUI>().text = msg[i].Score.ToString();
                }
                catch (System.Exception e)
                {
                    nickname.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    score.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                }
                i++;
            }
        }));
    }

    void getScore()
    {
        int coins = coinManager.getCoins();
        GameObject score = GameObject.Find("PlayerScore");
        score.GetComponent<TMPro.TextMeshProUGUI>().text = coins.ToString();

    }

    public void OnScoreSubmit()
    {
        print("Submitting score");
        int coins = coinManager.getCoins();
        string nickname = GameObject.Find("NickNameInput").GetComponent<TMPro.TMP_InputField>().text;
        print("Nickname: " + nickname);
        print("Coins: " + coins);
       
        Leaderboards.Olaf.UploadNewEntry(nickname,coins, ( (msg) =>
        {
            getLeaderboard();
        } ));
    }
    void test()
    {
      getLeaderboard();
        
    }
}

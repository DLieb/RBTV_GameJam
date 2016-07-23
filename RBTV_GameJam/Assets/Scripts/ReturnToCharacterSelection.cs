using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ReturnToCharacterSelection : MonoBehaviour
{
    public Text column1;
    public Text column2;
    public Text column3;
    public Text column4;
    private Dictionary<string, PlayerScore> scoreBoard;
    private bool sceneLoaded = false;
   


    private List<PlayerScore> playerScores = new List<PlayerScore>();
    private List<string> playerNames = new List<string>();

    void Start()
    {
        scoreBoard = GameControl.instance.getScoreBoard();
        foreach (KeyValuePair<string, PlayerScore> entry in scoreBoard)
        {
            if (entry.Key != null && entry.Value != null)
            {
                playerNames.Add(entry.Key);
                playerScores.Add(entry.Value);
            }
        }
        sortLists();
        for (int i = 0; i < playerNames.Count; i++)
        {
            if (playerNames[i] != null && playerScores[i]!=null)
            {
            column1.text = column1.text + playerNames[i] + Environment.NewLine;
            column2.text = column2.text + "Hits: " + playerScores[i].hits + Environment.NewLine;
            column3.text = column3.text + "Kills: " + playerScores[i].kills + Environment.NewLine;
            column4.text = column4.text + "Matches won: " + playerScores[i].score + Environment.NewLine;
            }
        }
        /*foreach (KeyValuePair<string, PlayerScore> entry in scoreBoard)
        {
            if (entry.Key != null && entry.Value!= null)
            {
                column1.text = column1.text + entry.Key + Environment.NewLine;
                column2.text = column2.text + "Hits: " + entry.Value.hits + Environment.NewLine;
                column3.text = column3.text + "Kills: " + entry.Value.kills + Environment.NewLine;
                column4.text = column4.text + "Matches won: " + entry.Value.score + Environment.NewLine;
            }
        }*/
    }

    void Update ()
    {
        if (Input.anyKey && !sceneLoaded)
        {
            if (Input.GetButtonDown("Joy1StartButton"))
            {
                Continue();
            }
            if (Input.GetButtonDown("Key1StartButton"))
            {
                Continue();
            }
            if (Input.GetButtonDown("Joy2StartButton"))
            {
                Continue();
            }
            if (Input.GetButtonDown("Key2StartButton"))
            {
                Continue();
            }
            if (Input.GetButtonDown("Joy3StartButton"))
            {
                Continue();
            }
            if (Input.GetButtonDown("Joy4StartButton"))
            {
                Continue();
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                ReturnToSelection();
            }
        }
    }

    void Continue()
    {
        sceneLoaded = true;
        SceneManager.LoadScene(1);
        GameControl.instance.resetPlayersLeftInGame();
    }

    void ReturnToSelection()
    {
        sceneLoaded = true;
        GameControl.instance.SetPlayerList(new List<Player>());
        GameControl.instance.resetScoreBoard();
        GameControl.instance.resetPlayersLeftInGame();
        GameControl.instance.currentPlayers = 0;
        SceneManager.LoadScene(0);
    }

    void sortLists()
    {
        string tempName;
        PlayerScore tempScore;
        for (int write = 0; write < playerScores.Count; write++)
        {
            for (int sort = 0; sort < playerScores.Count - 1; sort++)
            {
                if (playerScores[sort].score < playerScores[sort + 1].score)
                {
                    tempScore = playerScores[sort + 1];
                    tempName = playerNames[sort + 1];

                    playerScores[sort + 1] = playerScores[sort];
                    playerNames[sort + 1] = playerNames[sort];

                    playerScores[sort] = tempScore;
                    playerNames[sort] = tempName;
                }
            }
        }
    }
}

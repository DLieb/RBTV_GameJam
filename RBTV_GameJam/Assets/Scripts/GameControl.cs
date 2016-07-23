using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    private List<Player> playerList = new List<Player>();
    public int currentPlayers=0;
    public Dictionary<string,PlayerScore> scoreBoard = new Dictionary<string, PlayerScore>();

    private List<string> playerLeftInGame = new List<string>();
    
    //Singelton
    public static GameControl instance;
    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void AddPlayer(Player player)
    {
        this.playerList.Add(player);
    }

    public void SetPlayerList(List<Player> x)
    {
        this.playerList = x;
        this.instantiateScoreBoard(x);
    }
    public List<Player> getPlayer()
    {
        return this.playerList;
    }
    //***********NEW SCORE SYSTEM


    public Dictionary<string,PlayerScore> getScoreBoard()
    {
        return this.scoreBoard;
    }

    public void addScore(string name, ScoreEnum scoreAdd)
    {
        PlayerScore x = this.scoreBoard[name];
        switch (scoreAdd)
        {
            case (ScoreEnum.hits):
                x.hits++;
                break;
            case (ScoreEnum.kills):
                x.kills++;
                break;
            case (ScoreEnum.wins):
                x.score++;
                break;
        }
        this.scoreBoard[name] = x;
    }

    public void resetScoreBoard()
    {
        this.scoreBoard = new Dictionary<string, PlayerScore>();
    }

    public void resetPlayersLeftInGame()
    {
        this.playerLeftInGame = new List<string>();
        for (int i = 0; i < this.playerList.Count; i++)
        {
            if (this.playerList[i] != null)
            {
                this.playerLeftInGame.Add(playerList[i].getPlayerName());
            }
        }
    }

    public void reducePlayersLeftInGame(string name)
    {
                playerLeftInGame.Remove(name);
    }

    public void instantiateScoreBoard(List<Player> players)
    {
        this.resetScoreBoard();
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] != null)
            {
                this.scoreBoard.Add(players[i].getPlayerName(), new PlayerScore(0, 0, 0));
                Debug.Log(players[i].getPlayerName() +" kills: "+ 0);
            }
        }
    }

    public void setPlayerWon()
    {
        for (int i = 0; i < this.playerLeftInGame.Count; i++)
        {
            if (this.playerLeftInGame[i] != null)
            {
                this.addScore(this.playerLeftInGame[i],ScoreEnum.wins);
            }
        }
    }
    //***********************+
    public void reducePlayerCount()
    {
        currentPlayers -= 1;
       // Debug.Log("Current Players " + currentPlayers);
    }
    void OnLevelWasLoaded(int level)
    {
        if(level==1)
        {
            currentPlayers = 0;
            //Debug.Log("Loaded Level1");
            int i = -2;
            foreach (Player x in playerList)
            {
                if (x.getGameCharacter() != null)
                {
                    i += 2;
                    GameObject Player = Instantiate(x.getGameCharacter(), new Vector2(i,0), Quaternion.identity) as GameObject;
                    PlayerController pController = Player.GetComponent<PlayerController>();
                    pController.currentPlayerPrefix = x.getJoyPad().ToString();
                    pController.playerName = x.getPlayerName();
                   currentPlayers ++;
                    Debug.Log("Current Players " + currentPlayers);
                }
            }
        }
    }
}

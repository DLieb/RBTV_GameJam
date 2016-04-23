using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    private List<Player> playerList = new List<Player>();

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
    }
    public List<Player> getPlayer()
    {
        return this.playerList;
    }
    void OnLevelWasLoaded(int level)
    {
        if(level==1)
        {
            Debug.Log("Loaded Level1");
            foreach (Player x in playerList)
            {
                if (x.getGameCharacter() != null)
                {
                    GameObject Player = Instantiate(x.getGameCharacter(), Vector2.zero, Quaternion.identity) as GameObject;
                    Player.GetComponent<PlayerController>().currentPlayerPrefix = x.getJoyPad().ToString();
                }
            }
        }

    }
}

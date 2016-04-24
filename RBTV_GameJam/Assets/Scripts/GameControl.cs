using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    private List<Player> playerList = new List<Player>();
    public int currentPlayers=0;
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

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
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
            int i = -2;
            foreach (Player x in playerList)
            {
                if (x.getGameCharacter() != null)
                {
                    i += 2;
                    GameObject Player = Instantiate(x.getGameCharacter(), new Vector2(i,0), Quaternion.identity) as GameObject;
                    Player.GetComponent<PlayerController>().currentPlayerPrefix = x.getJoyPad().ToString();
                    currentPlayers ++;
                }
            }
        }
    }
}

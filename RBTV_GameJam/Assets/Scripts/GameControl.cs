using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public List<Player> getPlayer()
    {
        return this.playerList;
    }
}

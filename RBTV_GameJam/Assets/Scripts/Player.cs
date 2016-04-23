using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private PlayerEnum playerNumber;
    private GameObject chosenCharacter;
    private InputEnum controller;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPlayer(PlayerEnum player)
    {
        this.playerNumber = player;
    }
    public PlayerEnum getPlayer()
    {
        return this.playerNumber;
    }

    public void setGameCharacter(GameObject character)
    {
        this.chosenCharacter = character;
    }

    public GameObject getGameCharacter()
    {
        return this.chosenCharacter;
    }
    public void setController(InputEnum input)
    {
        this.controller = input;
    }

    public InputEnum getJoyPad()
    {
        return this.controller;
    }
}

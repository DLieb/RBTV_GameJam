using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Player
{

    private PlayerEnum playerNumber;
    private GameObject chosenCharacter;
    private InputEnum controller;
    private CharacterAvatar lockedAvatar;
    private GameObject selectFrame;
    private bool locked=false;
    private string playerName;
    public int Iterator = 0;

    public Player()
    {

    }
    public Player(PlayerEnum player, InputEnum ctrl)
    {
        playerNumber = player;
        controller = ctrl;
        chosenCharacter = null;
    }

    public void setPlayer(PlayerEnum player)
    {
        this.playerNumber = player;
    }

    public CharacterAvatar GetLockedAvatar()
    {
        return this.lockedAvatar;
    }

    public void SetLockedAvatar(CharacterAvatar x)
    {
        this.lockedAvatar = x;
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

    public GameObject GetFrame()
    {
        return this.selectFrame;
    }

    public void SetSelectFrame(GameObject x)
    {
        selectFrame = x;
    }

    public bool getLockedStatus()
    {
        return this.locked;
    }

    public void setLockedStatus(bool x)
    {
        this.locked = x;
    }

    public void setPlayerName(string name)
    {
        this.playerName = name;
    }

    public string getPlayerName()
    {
        return this.playerName;
    }

}

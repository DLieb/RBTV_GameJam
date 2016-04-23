﻿using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Player
{

    private PlayerEnum playerNumber;
    private GameObject chosenCharacter;
    private InputEnum controller;
    private CharacterAvatar lockedAvatar;

    public Player()
    {
        playerNumber = PlayerEnum.Player1;
        controller = InputEnum.Joy1;
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
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CharacterSelection : MonoBehaviour
{

    private bool player1Set;
    private bool player2Set;
    private bool player3Set;
    private bool player4Set;

    private bool player1Locked;
    private bool player2Locked;
    private bool player3Locked;
    private bool player4Locked;

    private bool readyToStart = true;

    private int p1Iterator;
    private int p2Iterator;
    private int p3Iterator;
    private int p4Iterator;

    public GameObject P1Select;
    public GameObject P2Select;
    public GameObject P3Select;
    public GameObject P4Select;

    public List<CharacterAvatar> characterAvatars;
    private readonly List<Player> CurrentPlayers = new List<Player>();

    void Start()
    {
        List<CharacterAvatar> SortedList = characterAvatars.OrderByDescending(o => o.avatarName).ToList();
        characterAvatars = SortedList;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Joy1StartButton") && !player1Set)
        {
            SetPlayer(InputEnum.Joy1);
            player1Set = true;
        }
        if (Input.GetButtonDown("Joy2StartButton") && !player2Set)
        {
            SetPlayer(InputEnum.Joy2);
            player2Set = true;
        }
        if (Input.GetButtonDown("Joy3StartButton") && !player3Set)
        {
            SetPlayer(InputEnum.Joy3);
            player3Set = true;
        }
        if (Input.GetButtonDown("Joy4StartButton") && !player4Set)
        {
            SetPlayer(InputEnum.Joy4);
            player4Set = true;
        }
    }

    private void SetPlayer(InputEnum input)
    {
        var temp = new Player();
        temp.setController(input);
        //temp.setGameCharacter(CharacterPrefab);
        var listener = gameObject.AddComponent<InputListener>();
        GameObject tempFrame;
        switch (CurrentPlayers.Count)
        {
            case 0:
                temp.setPlayer(PlayerEnum.Player1);
                tempFrame = Instantiate(P1Select, characterAvatars[p1Iterator].transform.position,
                    Quaternion.identity)as GameObject;
                temp.SetSelectFrame(tempFrame);
                break;
            case 1:
                temp.setPlayer(PlayerEnum.Player2);
                tempFrame = Instantiate(P2Select, characterAvatars[p2Iterator].transform.position,
                    Quaternion.identity) as GameObject;
                temp.SetSelectFrame(tempFrame);
                break;
            case 2:
                temp.setPlayer(PlayerEnum.Player3);
                tempFrame = Instantiate(P3Select, characterAvatars[p3Iterator].transform.position,
                    Quaternion.identity) as GameObject;
                temp.SetSelectFrame(tempFrame);
                break;
            case 3:
                temp.setPlayer(PlayerEnum.Player4);
                tempFrame = Instantiate(P4Select, characterAvatars[p4Iterator].transform.position,
                    Quaternion.identity) as GameObject;
                temp.SetSelectFrame(tempFrame);
                break;
        }
        listener.setPlayer(temp);
        CurrentPlayers.Add(temp);
        Debug.Log("Added Player " + temp.getPlayer());
        //GameControl.instance.AddPlayer(temp);
    }

    public void changeAvatarSelection(Player player, int iteration)
    {
        Vector2 temp;
        switch (player.getPlayer())
        {
            case PlayerEnum.Player1:
                if (!player1Locked)
                {
                    p1Iterator = iterate(p1Iterator, iteration);
                    temp = characterAvatars[p1Iterator].transform.position;
                    player.GetFrame().transform.position = temp;
                    //textMeshes[0].text = player + "Has " + characterAvatars[p1Iterator].name + "selected";
                }
                break;
            case PlayerEnum.Player2:
                if (!player2Locked)
                {
                    p2Iterator = iterate(p2Iterator, iteration);
                    temp = characterAvatars[p2Iterator].transform.position;
                    player.GetFrame().transform.position = temp;
                    //textMeshes[1].text = player + "Has " + characterAvatars[p2Iterator].name +"selected";
                }
                break;
            case PlayerEnum.Player3:
                if (!player3Locked)
                {
                    p3Iterator = iterate(p3Iterator, iteration);
                    temp = characterAvatars[p3Iterator].transform.position;
                    player.GetFrame().transform.position = temp;
                    //textMeshes[2].text = player + "Has " + characterAvatars[p3Iterator].name +"selected";
                }
                break;
            case PlayerEnum.Player4:
                if (!player4Locked)
                {
                    p4Iterator = iterate(p4Iterator, iteration);
                    temp = characterAvatars[p4Iterator].transform.position;
                    player.GetFrame().transform.position = temp;
                    //textMeshes[3].text = player + "Has " + characterAvatars[p4Iterator].name +"selected";
                }
                break;
        }
    }

    public void LockAvatar(PlayerEnum player)
    {
        for (var i = 0; i < CurrentPlayers.Count; i++)
        {
            if (CurrentPlayers[i].getPlayer() == player)
            {
                Vector2 temp;
                switch (CurrentPlayers[i].getPlayer())
                {
                    case PlayerEnum.Player1:
                        if (!player1Locked)
                        {
                            temp = new Vector2(-8, 5);
                            characterAvatars[p1Iterator].transform.position = temp;
                            CurrentPlayers[i].GetFrame().transform.position = temp;
                            CurrentPlayers[i].setGameCharacter(characterAvatars[p1Iterator].getCharacterPrefab());
                            CurrentPlayers[i].SetLockedAvatar(characterAvatars[p1Iterator]);
                            removeAvatar(characterAvatars[p1Iterator]);
                            player1Locked = true;
                        }
                        break;
                    case PlayerEnum.Player2:
                        if (!player2Locked)
                        {
                            temp = new Vector2(8, 5);
                            characterAvatars[p2Iterator].transform.position = temp;
                            CurrentPlayers[i].GetFrame().transform.position = temp;
                            CurrentPlayers[i].setGameCharacter(characterAvatars[p2Iterator].getCharacterPrefab());
                            CurrentPlayers[i].SetLockedAvatar(characterAvatars[p2Iterator]);
                            removeAvatar(characterAvatars[p2Iterator]);
                            player2Locked = true;
                        }
                        break;
                    case PlayerEnum.Player3:
                        if (!player3Locked)
                        {
                            temp = new Vector2(-8, -5);
                            characterAvatars[p3Iterator].transform.position = temp;
                            CurrentPlayers[i].GetFrame().transform.position = temp;
                            CurrentPlayers[i].setGameCharacter(characterAvatars[p3Iterator].getCharacterPrefab());
                            CurrentPlayers[i].SetLockedAvatar(characterAvatars[p3Iterator]);
                            removeAvatar(characterAvatars[p3Iterator]);
                            player3Locked = true;
                        }
                        break;

                    case PlayerEnum.Player4:
                        if (!player4Locked)
                        {
                            temp = new Vector2(8, -5);
                            characterAvatars[p4Iterator].transform.position = temp;
                            CurrentPlayers[i].GetFrame().transform.position = temp;
                            CurrentPlayers[i].setGameCharacter(characterAvatars[p4Iterator].getCharacterPrefab());
                            CurrentPlayers[i].SetLockedAvatar(characterAvatars[p4Iterator]);
                            removeAvatar(characterAvatars[p4Iterator]);
                            player4Locked = true;
                        }
                        break;
                }
                //Debug.Log(player.ToString() + "locked" + characterAvatars[p1Iterator].name);
            }
        }
    }

    private int iterate(int iterator, int iteration)
    {
        int temp;
        if (iterator == characterAvatars.Count - 1 && iteration == 1)
        {
            temp = 0;
        }
        else if (iterator == 0 && iteration == -1)
        {
            temp = characterAvatars.Count - 1;
        }
        else
        {
            temp = iterator + iteration;
        }
        return temp;
    }

    public void StartGame()
    {
        readyToStart = true;
        for (var i = 0; i < CurrentPlayers.Count - 1; i++)
        {
            if (CurrentPlayers[i].getGameCharacter() == null)
            {
                Debug.Log(CurrentPlayers[i].getPlayer() + " hasn't chosen an Avatar yet");
                readyToStart = false;
            }
        }
        if (CurrentPlayers.Count >= 2 && readyToStart)
        {
            GameControl.instance.SetPlayerList(CurrentPlayers);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("You need at least 2 Players");
        }
    }

    private void removeAvatar(CharacterAvatar avatar)
    {
        for (var i = 0; i < characterAvatars.Count ; i++) //CharacterAvatar x in characterAvatars)
        {
            if (avatar == characterAvatars[i])
            {
                characterAvatars.Remove(characterAvatars[i]);
                List<CharacterAvatar> SortedList = characterAvatars.OrderByDescending(o => o.avatarName).ToList();
                characterAvatars = SortedList;
            }
        }
    }

    private void reAddAvatar(CharacterAvatar avatar)
    {
        characterAvatars.Add(avatar);
        List<CharacterAvatar> SortedList = characterAvatars.OrderByDescending(o => o.avatarName).ToList();
        characterAvatars = SortedList;
    }
    public void UnLockAvatar(PlayerEnum player)
    {
        for (int i = 0; i < CurrentPlayers.Count; i++)
        {
            if (CurrentPlayers[i].getPlayer() == player)
            {
                switch (CurrentPlayers[i].getPlayer())
                {
                        case PlayerEnum.Player1:
                        if (player1Locked)
                        {
                            CharacterAvatar x = CurrentPlayers[i].GetLockedAvatar();
                            x.transform.position = x.GetInitialPosition();
                            CurrentPlayers[i].GetFrame().transform.position = x.GetInitialPosition();
                            reAddAvatar(x);
                            player1Locked = false;
                        }
                        break;
                        case PlayerEnum.Player2:
                        if (player2Locked)
                        {
                            CharacterAvatar x = CurrentPlayers[i].GetLockedAvatar();
                            x.transform.position = x.GetInitialPosition();
                            CurrentPlayers[i].GetFrame().transform.position = x.GetInitialPosition();
                            reAddAvatar(x);
                            player2Locked = false;
                        }
                        break;
                        case PlayerEnum.Player3:
                        if (player3Locked)
                        {
                            CharacterAvatar x = CurrentPlayers[i].GetLockedAvatar();
                            x.transform.position = x.GetInitialPosition();
                            CurrentPlayers[i].GetFrame().transform.position = x.GetInitialPosition();
                            reAddAvatar(x);
                            player3Locked = false;
                        }
                        break;
                        case PlayerEnum.Player4:
                        if (player4Locked)
                        {
                            CharacterAvatar x = CurrentPlayers[i].GetLockedAvatar();
                            x.transform.position = x.GetInitialPosition();
                            CurrentPlayers[i].GetFrame().transform.position = x.GetInitialPosition();
                            reAddAvatar(x);
                            player4Locked = false;
                        }
                        break;
                }
            }
        }
    }

    /*void InstantiatePlayerBeacon(PlayerEnum player)
    {
        GameObject BeaconP1 = Instantiate(textMeshPrefab, Vector2.zero,Quaternion.identity)as GameObject;
        BeaconP1.GetComponent<TextMesh>().text = player.ToString();
    }*/
}

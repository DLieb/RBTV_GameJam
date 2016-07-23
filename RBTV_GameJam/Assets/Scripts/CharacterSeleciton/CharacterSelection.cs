using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private bool joy1Set;
    private bool key1Set;
    private bool key2Set;
    private bool joy2Set;
    private bool joy3Set;
    private bool joy4Set;

    private bool readyToStart = true;

    public GameObject P1Select;
    public GameObject P2Select;
    public GameObject P3Select;
    public GameObject P4Select;

    public List<CharacterAvatar> characterAvatars;
    private readonly List<Player> CurrentPlayers = new List<Player>();

    private void Start()
    {
        var SortedList = characterAvatars.OrderByDescending(o => o.avatarName).ToList();
        characterAvatars = SortedList;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Joy1StartButton") && !joy1Set)
        {
            SetPlayer(InputEnum.Joy1);
            joy1Set = true;
        }
        if (Input.GetButtonDown("Key1StartButton") && !key1Set)
        {
            SetPlayer(InputEnum.Key1);
            key1Set = true;
        }

        if (Input.GetButtonDown("Joy2StartButton") && !joy2Set)
        {
            SetPlayer(InputEnum.Joy2);
            joy2Set = true;
        }
        if (Input.GetButtonDown("Key2StartButton") && !key2Set)
        {
            SetPlayer(InputEnum.Key2);
            key2Set = true;
        }

        if (Input.GetButtonDown("Joy3StartButton") && !joy3Set)
        {
            SetPlayer(InputEnum.Joy3);
            joy3Set = true;
        }
        if (Input.GetButtonDown("Joy4StartButton") && !joy4Set)
        {
            SetPlayer(InputEnum.Joy4);
            joy4Set = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SetPlayer(InputEnum input)
    {
        if (CurrentPlayers.Count != 4)
        {
            var temp = new Player();
            temp.setController(input);
            var listener = gameObject.AddComponent<InputListener>();
            GameObject tempFrame;
            switch (CurrentPlayers.Count)
            {
                case 0:
                    temp.setPlayer(PlayerEnum.Player1);
                    temp.Iterator = getNextFreeAvatarID(0, 0);
                    tempFrame = Instantiate(P1Select, characterAvatars[temp.Iterator].transform.position,
                        Quaternion.identity) as GameObject;
                    tempFrame.transform.localScale = characterAvatars[temp.Iterator].transform.localScale;
                    temp.SetSelectFrame(tempFrame);
                    break;
                case 1:
                    temp.setPlayer(PlayerEnum.Player2);
                    temp.Iterator = getNextFreeAvatarID(0, 0);
                    tempFrame = Instantiate(P2Select, characterAvatars[temp.Iterator].transform.position,
                        Quaternion.identity) as GameObject;
                    tempFrame.transform.localScale = characterAvatars[temp.Iterator].transform.localScale;
                    temp.SetSelectFrame(tempFrame);
                    break;
                case 2:
                    temp.setPlayer(PlayerEnum.Player3);
                    temp.Iterator = getNextFreeAvatarID(0, 0);
                    tempFrame = Instantiate(P3Select, characterAvatars[temp.Iterator].transform.position,
                        Quaternion.identity) as GameObject;
                    tempFrame.transform.localScale = characterAvatars[temp.Iterator].transform.localScale;
                    temp.SetSelectFrame(tempFrame);
                    break;
                case 3:
                    temp.setPlayer(PlayerEnum.Player4);
                    temp.Iterator = getNextFreeAvatarID(0, 0);
                    tempFrame = Instantiate(P4Select, characterAvatars[temp.Iterator].transform.position,
                        Quaternion.identity) as GameObject;
                    tempFrame.transform.localScale = characterAvatars[temp.Iterator].transform.localScale;
                    temp.SetSelectFrame(tempFrame);
                    break;
            }
            listener.setPlayer(temp);
            CurrentPlayers.Add(temp);
            //Debug.Log("Added Player " + temp.getPlayer());
        }
        
    }

    //Needs Start Iteration Index and +/- 1 to define direction
    public int getNextFreeAvatarID(int startIterate, int direction)
    {
        var found = false;
        var temp = 0;
        var x = startIterate + direction;
        if (x >= characterAvatars.Count)
        {
            x = 0;
        }
        if (direction >= 0)
        {
            for (var i = x; i < characterAvatars.Count; i++)
            {
                if (characterAvatars[i].lockStatus == false)
                {
                    temp = characterAvatars[i].AvatarIndex;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                for (var i = 0; i < characterAvatars.Count; i++)
                {
                    if (characterAvatars[i].lockStatus == false)
                    {
                        temp = characterAvatars[i].AvatarIndex;
                        break;
                    }
                }
            }
        }
        else if (direction < 0)
        {
            for (var i = x; i >= 0; i--)
            {
                if (characterAvatars[i].lockStatus == false)
                {
                    temp = characterAvatars[i].AvatarIndex;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                for (var i = characterAvatars.Count - 1; i < characterAvatars.Count; i--)
                {
                    if (characterAvatars[i].lockStatus == false)
                    {
                        temp = characterAvatars[i].AvatarIndex;
                        break;
                    }
                }
            }
        }
        //Debug.Log("Next free Avatar Id Is" + temp);
        return temp;
    }

    public void changeAvatarSelection(Player player, int iteration)
    {
        Vector2 temp;
        if (!player.getLockedStatus())
        {
            player.Iterator = getNextFreeAvatarID(player.Iterator, iteration);
            temp = characterAvatars[player.Iterator].transform.position;
            player.GetFrame().transform.position = temp;
        }
    }

    public void LockAvatar(Player player)
    {
        for (var i = 0; i < CurrentPlayers.Count; i++)
        {
            if (CurrentPlayers[i] == player)
            {
                CurrentPlayers[i].setGameCharacter(characterAvatars[player.Iterator].getCharacterPrefab());
                CurrentPlayers[i].setPlayerName(characterAvatars[player.Iterator].getAvatarName());
                player.setLockedStatus(true);
                characterAvatars[player.Iterator].lockStatus = true;
                var b = characterAvatars[player.Iterator].GetComponent<SpriteRenderer>().color;
                b.a = 0.4f;
                characterAvatars[player.Iterator].GetComponent<SpriteRenderer>().color = b;
                ResetIteratorsForOthers(player);
            }
        }
    }

    private void ResetIteratorsForOthers(Player LockedPlayer)
    {
        Vector2 temp;
        for (var i = 0; i < CurrentPlayers.Count; i++)
        {
            if (LockedPlayer != CurrentPlayers[i] && CurrentPlayers[i].Iterator == LockedPlayer.Iterator)
            {
                CurrentPlayers[i].Iterator = getNextFreeAvatarID(CurrentPlayers[i].Iterator, 1);
                temp = characterAvatars[CurrentPlayers[i].Iterator].transform.position;
                CurrentPlayers[i].GetFrame().transform.position = temp;
            }
        }
    }

    public void StartGame()
    {
        readyToStart = true;
        for (var i = 0; i < CurrentPlayers.Count; i++)
        {
            if (CurrentPlayers[i].getLockedStatus() == false)
            {
                Debug.Log(CurrentPlayers[i].getPlayer() + " hasn't chosen an Avatar yet");
                readyToStart = false;
            }
        }
        if (CurrentPlayers.Count >= 2 && readyToStart)
        {
            GameControl.instance.SetPlayerList(CurrentPlayers);
            GameControl.instance.resetPlayersLeftInGame();
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("You need at least 2 Players you got " + CurrentPlayers.Count);
        }
    }

    public void UnLockAvatar(Player player)
    {
        for (var i = 0; i < CurrentPlayers.Count; i++)
        {
            if (CurrentPlayers[i] == player)
            {
                CurrentPlayers[i].setLockedStatus(false);
                var temp = characterAvatars[player.Iterator].GetComponent<SpriteRenderer>().color;
                temp.a = 1f;
                characterAvatars[player.Iterator].GetComponent<SpriteRenderer>().color = temp;
                characterAvatars[player.Iterator].lockStatus = false;
            }
        }
    }
}

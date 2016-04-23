using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelection : MonoBehaviour {

    private bool player1Set = false;
    private bool player2Set = false;
    private bool player3Set = false;
    private bool player4Set = false;

    private CharacterAvatar currentAvatarP1;
    private CharacterAvatar currentAvatarP2;
    private CharacterAvatar currentAvatarP3;
    private CharacterAvatar currentAvatarP4;

    public Image[] selectSprites;
    public CharacterAvatar[] characterAvatars;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
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

    void SetPlayer(InputEnum input)
    {
        Player temp = new Player();
        temp.setController(input);
        GameControl.instance.AddPlayer(temp);
    }

    void SetCurrentCharacter(PlayerEnum player)
    {
        switch (player)
        {
            case PlayerEnum.Player1:
                break;
            case PlayerEnum.Player2:
                break;
            case PlayerEnum.Player3:
                break;
            case PlayerEnum.Player4:
                break;
        }

    }

}

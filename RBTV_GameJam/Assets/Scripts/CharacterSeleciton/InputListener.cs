using UnityEngine;
using System.Collections;

public class InputListener : MonoBehaviour
{
    private  Player player = new Player();
    private InputEnum joypad;

    private CharacterSelection characterSelection;
    private bool waitWithInput = false;
	// Use this for initialization
	void Start ()
	{
	    characterSelection = GetComponent<CharacterSelection>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (player != null)
	    {
            if (Input.GetAxis(player.getJoyPad().ToString()+"Horizontal") < -0.9 && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.changeAvatarSelection(player, -1);
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if (Input.GetAxis(player.getJoyPad().ToString()+"Horizontal") > 0.9 && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.changeAvatarSelection(player, 1);
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if (Input.GetButtonDown(player.getJoyPad().ToString() + "Jump") && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.LockAvatar(player.getPlayer());
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if (Input.GetButtonDown(player.getJoyPad().ToString() + "Dash") && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.StartGame();
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if (Input.GetButtonDown(player.getJoyPad().ToString() + "Throw") && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.UnLockAvatar(player.getPlayer());
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
        }
	}

    private void ResetWaitWithInput()
    {
        waitWithInput = false;
    }

    public void setPlayer(Player x)
    {
        Debug.Log("Player set!" + x.getPlayer().ToString());
        this.player = x;
    }

    public Player getPlayer()
    {
        return this.player;
    }
}

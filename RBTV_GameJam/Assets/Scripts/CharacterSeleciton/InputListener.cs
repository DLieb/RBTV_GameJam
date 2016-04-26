using UnityEngine;
using System.Collections;

public class InputListener : MonoBehaviour
{
    private  Player player = new Player();

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
            if ((Input.GetAxis(player.getJoyPad().ToString()+"Horizontal") < -0.9  
                || (player.getJoyPad() == InputEnum.Key1 && Input.GetKey(KeyCode.LeftArrow)) || (player.getJoyPad() == InputEnum.Key2 && Input.GetKey(KeyCode.A))) && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.changeAvatarSelection(player, -1);
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if ((Input.GetAxis(player.getJoyPad().ToString()+"Horizontal") > 0.9
                || (player.getJoyPad() == InputEnum.Key1 && Input.GetKey(KeyCode.RightArrow)) || (player.getJoyPad() == InputEnum.Key2 && Input.GetKey(KeyCode.D))) && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.changeAvatarSelection(player, 1);
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if ((Input.GetButtonDown(player.getJoyPad().ToString() + "Jump") 
                || (player.getJoyPad() == InputEnum.Key1 && Input.GetKey(KeyCode.UpArrow))|| (player.getJoyPad() == InputEnum.Key2 && Input.GetKey(KeyCode.W))) && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.LockAvatar(player);
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if ((Input.GetButtonDown(player.getJoyPad().ToString() + "Dash") 
                || (player.getJoyPad() == InputEnum.Key1 && Input.GetKey(KeyCode.RightShift)) || (player.getJoyPad() == InputEnum.Key2 && Input.GetKey(KeyCode.LeftShift))) && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.StartGame();
                }
                waitWithInput = true;
                Invoke("ResetWaitWithInput", 0.2f);
            }
            if ((Input.GetButtonDown(player.getJoyPad().ToString() + "Throw")
                || (player.getJoyPad() == InputEnum.Key1 && Input.GetKey(KeyCode.RightControl)) || (player.getJoyPad() == InputEnum.Key2 && Input.GetKey(KeyCode.LeftControl))) && !waitWithInput)
            {
                if (characterSelection)
                {
                    characterSelection.UnLockAvatar(player);
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
        //Debug.Log("Player set!" + x.getPlayer().ToString());
        this.player = x;
    }

    public Player getPlayer()
    {
        return this.player;
    }
}

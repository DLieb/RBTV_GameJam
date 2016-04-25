using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CharacterAvatar : MonoBehaviour
{

    public GameObject characterPrefab;
    public string avatarName;
    //private Image avatar;
    private Vector2 initialPosition;
	// Use this for initialization
	void Start ()
	{
	    //avatar = GetComponent<Image>();
	    initialPosition = transform.position;
	}

    public Vector2 GetInitialPosition()
    {
        return initialPosition;
    }

    public GameObject getCharacterPrefab()
    {
        if (characterPrefab)
        {
            return this.characterPrefab;
        }
        else
        {
            Debug.Log("No character Object set");
            return this.characterPrefab;
        }
    }
}

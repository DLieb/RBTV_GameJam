using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CharacterAvatar : MonoBehaviour
{

    public GameObject characterPrefab;
    private Image avatar;
	// Use this for initialization
	void Start ()
	{
	    avatar = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
	
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

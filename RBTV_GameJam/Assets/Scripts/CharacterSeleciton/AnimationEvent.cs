using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour {

    public void DestroyObject()
    {
		Destroy(this.gameObject);
    }
	public void DeactivateObject()
	{
		this.gameObject.SetActive(false);
	}

}

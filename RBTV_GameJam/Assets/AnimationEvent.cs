using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour {

    public void DestroyObject()
    {
        this.gameObject.SetActive(false);
    }

}

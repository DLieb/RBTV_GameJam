using UnityEngine;
using System.Collections;

public class TogglePlatformsController : MonoBehaviour {

    public GameObject[] gameObjects;

    public float toggleTimeMin = 2f;
    public float toggleTimeMax = 4f;

	// Use this for initialization
	void Start () {
        StartCoroutine(toggleWindows());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator toggleWindows()
    {
        //print(gameObjects.Length);
        int randomWindowIndex = Random.Range(0, gameObjects.Length);
        //print("random window has index " + randomWindowIndex);
        float random = Random.Range(toggleTimeMin, toggleTimeMax);

        for (float i = 0; i < random; i+=random) {
            //print("enable/disable sth " + !gameObjects[randomWindowIndex].activeSelf);
            gameObjects[randomWindowIndex].SetActive(!gameObjects[randomWindowIndex].activeSelf);

            yield return new WaitForSeconds(random);
        }
        StartCoroutine(toggleWindows());
    }

}

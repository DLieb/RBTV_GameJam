using UnityEngine;
using System.Collections;

public class PeanutSpawnScript : MonoBehaviour {

	public GameObject peanut;

    public float throwForce = 500;
    public float nutSpawnDistanceX = 1.01f;
    public float nutSpawnDistanceY = 0.2f;
    

    public void throwPeanut(float x, float y, Vector2 force, GameObject prefab , string playerWhoThrow)
    {
        if (prefab == null)
        {
            prefab = peanut;
        }
        GameObject throwPeanut = spawnPeanut(x, y, prefab);

        throwPeanut.GetComponent<Rigidbody2D>().AddForce(force);
        PeanutController pController = throwPeanut.GetComponent<PeanutController>();
        pController.wasThrown = true;
        pController.playerWhoHasThrown = playerWhoThrow;

    }

    private GameObject spawnPeanut(float x, float y, GameObject prefab)
    {
        return Instantiate(prefab, new Vector2(x,y), transform.rotation) as GameObject;
    }

    public void spawnPeanutRandomLocation()
    {
        //get random x, get random y
        //Random rnd = new Random();
        bool spawnPointFound = false;
        int spawnX = 1;
        int spawnY = 1;
        while (!spawnPointFound)
        {
            spawnX = Random.Range(-18, 18);
            spawnY = Random.Range(-9, 9);
            Collider2D temp = Physics2D.OverlapPoint(new Vector2(spawnX, spawnY));
            if (temp == null)
            {
                spawnPointFound = true;
            } else
            {
               // Debug.Log("peanut spawning failed");
            }
        }

        spawnPeanut(spawnX, spawnY, peanut);
    }
}

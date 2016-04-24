using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPowerUps : MonoBehaviour
{
    public float minSpawnTime;
    public float maxSpawntime;
    public List<GameObject> PowerUps;
	// Use this for initialization
	void Start ()
	{
	    spawnPowerUpRandomLocation();
	}
	

    public void spawnPowerUpRandomLocation()
    {
        int powerUp = Random.Range(0, PowerUps.Count);

        Random rnd = new Random();
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
            }
            else
            {
            }
        }

        spawnPowerUp(new Vector2(spawnX, spawnY),PowerUps[powerUp] );
    }

    void spawnPowerUp(Vector2 position, GameObject prefab)
    {
        Instantiate(prefab, position, Quaternion.identity);
        StartCoroutine(waitForNewPowerUp());
    }

    IEnumerator waitForNewPowerUp()
    {
        float temp = Random.Range(minSpawnTime,maxSpawntime);
        yield return new WaitForSeconds(temp);
        spawnPowerUpRandomLocation();
    }
}

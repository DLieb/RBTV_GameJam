using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{

    public float PowerTime=5;
    public GameObject PowerChar;
    public GameObject Attack;

    public GameObject GetPowerChar()
    {
        return this.PowerChar;
    }

    public float GetPowerTime()
    {
        return PowerTime;
    }
    public GameObject GetAttack()
    {
        return Attack;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PowerUPTransform>().transformPower(this.Attack,this.PowerChar,this.PowerTime);
            Destroy(this.gameObject);
        }
    }
}

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
}

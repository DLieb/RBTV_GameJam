using UnityEngine;
using System.Collections;

public class DestroyAttackItem : MonoBehaviour
{

    void OnCollisionEnter2D()
    {
        Destroy(this.gameObject);
    }
}

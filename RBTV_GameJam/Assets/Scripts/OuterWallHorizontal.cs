using UnityEngine;
using System.Collections;

public class OuterWallHorizontal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(coll)
        print("collision detected");
        print(collision.gameObject.tag);
        collision.transform.position = new Vector2(collision.transform.position.x , collision.transform.position.y * -1);
    }
}

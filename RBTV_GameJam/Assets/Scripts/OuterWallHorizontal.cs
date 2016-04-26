using UnityEngine;
using System.Collections;

public class OuterWallHorizontal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(coll)
        //print("collision detected");
        //print(collision.gameObject.tag);
        float y = -collision.transform.position.y;
        if (collision.transform.position.y < 0)
        {
            y -= 1;
        }
        else
        {
            y += 1;
        }
        collision.transform.position = new Vector2(collision.transform.position.x , y);
    }
}

using UnityEngine;
using System.Collections;

public class OuterWallCollision : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision detected");
        print(collision.gameObject.tag);
        float x = -collision.transform.position.x;
        if (collision.transform.position.x < 0)
        {
            x -= 1;
        }
        else
        {
            x += 1;
        }
        collision.transform.position = new Vector2(x, collision.transform.position.y);
    }
}

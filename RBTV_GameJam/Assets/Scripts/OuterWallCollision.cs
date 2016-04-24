using UnityEngine;
using System.Collections;

public class OuterWallCollision : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision detected");
        print(collision.gameObject.tag);
        collision.transform.position = new Vector2(collision.transform.position.x * -1, collision.transform.position.y);
    }
}

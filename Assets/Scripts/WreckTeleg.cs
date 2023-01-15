using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckTeleg : MonoBehaviour
{
    public MovingDirections direction;
    private float speed = 0.1f;
    // Start is called before deez
    void Start()
    {
        
    }

    // deez what?
    public void FixedUpdate()
    {
        switch(direction) {
            case MovingDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                bool isOnScreen = ScreenHelpers.ObjectNah(newPosition);
                if (isOnScreen == true) {
                    transform.position = newPosition;
                } else{
                    direction = MovingDirections.down;
                }
                break;
            case MovingDirections.left:
                break;
            case MovingDirections.up:
                break;
            case MovingDirections.down:
                break;
        }
    }
}

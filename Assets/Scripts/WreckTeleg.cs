using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckTeleg : MonoBehaviour
{
    public MovingDirections direction;
    private float speed = 0.1f;
    public SpriteRenderer shipRenderer;
    private float halfside = 0.0f;
    private float evilHP = 20.0f;
    // Start is called before deez
    void Start()
    {
        halfside = shipRenderer.sprite.bounds.size.y/2;
    }

    // deez what?
    public void FixedUpdate()
    {
        switch(direction) {
            case MovingDirections.right:
                Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y, 0);
                Vector3 checkPosition = new Vector3(transform.position.x + speed + halfside, transform.position.y, 0);
                bool isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if (isOnScreen == true) {
                    transform.position = newPosition;
                } else{
                    if(transform.position.y > 0){
                        direction = MovingDirections.down;
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else {
                        direction = MovingDirections.up;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                break;
            case MovingDirections.left:
                newPosition = new Vector3(transform.position.x - speed, transform.position.y, 0);
                checkPosition = new Vector3(transform.position.x - speed - halfside, transform.position.y, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if (isOnScreen == true) {
                    transform.position = newPosition;
                } else{
                    if(transform.position.y > 0){
                            direction = MovingDirections.down;
                            transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else {
                        direction = MovingDirections.up;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                break;
            case MovingDirections.up:
                newPosition = new Vector3(transform.position.x, transform.position.y + speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y + speed + halfside, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if (isOnScreen == true) {
                    transform.position = newPosition;
                } else{
                    if(transform.position.x > 0){
                            direction = MovingDirections.left;
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else {
                        direction = MovingDirections.right;
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                }
                break;
            case MovingDirections.down:
                newPosition = new Vector3(transform.position.x, transform.position.y - speed, 0);
                checkPosition = new Vector3(transform.position.x, transform.position.y - speed - halfside, 0);
                isOnScreen = ScreenHelpers.ObjectNah(checkPosition);
                if (isOnScreen == true) {
                    transform.position = newPosition;
                } else{
                    if(transform.position.x > 0){
                            direction = MovingDirections.left;
                            transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else {
                        direction = MovingDirections.right;
                        transform.rotation = Quaternion.Euler(0, 0, 270);
                    }
                }
                break;
        }
    }
    void OnTriggerEnter2D( Collider2D col)
    {
        GameObject pew = col.gameObject;
        Pew pewScript = pew.GetComponent<Pew>();
        if (pewScript != null)
        {
            evilHP -= pewScript.pewDMG;
            if (evilHP <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(pew);
        }
    }
}

